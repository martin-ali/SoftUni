﻿using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Requests;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responses.Contracts;
using SIS.WebServer.Result;
using SIS.WebServer.Routing.Contracts;

namespace SIS.WebServer
{
    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, IServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        private IHttpRequest ReadRequest()
        {
            // PARSE REQUEST FROM BYTE DATA
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int numberOfBytesToRead = this.client.Receive(data.Array, SocketFlags.None);

                if (numberOfBytesToRead == 0)
                {
                    break;
                }

                var bytesAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesToRead);
                result.Append(bytesAsString);

                if (numberOfBytesToRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        private async Task<IHttpRequest> ReadRequestAsync()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                int bytesReadCount = await this.client.ReceiveAsync(data.Array, SocketFlags.None);

                if (bytesReadCount == 0)
                {
                    break;
                }

                var bytesText = Encoding.UTF8.GetString(data.Array, 0, bytesReadCount);
                result.Append(bytesText);

                if (bytesReadCount < 1024)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        public async Task ProcessRequestAsync()
        {
            try
            {
                var httpRequest = await this.ReadRequestAsync();

                if (httpRequest != null)
                {
                    Console.WriteLine($"Processing: {httpRequest.RequestMethod}{httpRequest.Path}...");

                    var httpResponse = this.HandleRequest(httpRequest);

                    await this.PrepareResponseAsync(httpResponse);
                }
            }
            catch (BadRequestException exception)
            {
                await this.PrepareResponseAsync(
                    new TextResult(
                        exception.ToString(),
                        HttpResponseStatusCode.BadRequest));
            }
            catch (Exception exception)
            {
                await this.PrepareResponseAsync(
                    new TextResult(
                        exception.ToString(),
                        HttpResponseStatusCode.InternalServerError));
            }
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            // EXECUTE FUNCTION FOR CURRENT REQUEST -> RETURNS RESPONSE
            if (!this.serverRoutingTable.Contains(httpRequest.RequestMethod, httpRequest.Path))
            {
                return new TextResult($"Route with method {httpRequest.RequestMethod} and path \"{httpRequest.Path}\" not found.", HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Get(httpRequest.RequestMethod, httpRequest.Path).Invoke(httpRequest);
        }

        private void PrepareResponse(IHttpResponse httpResponse)
        {
            // PREPARES RESPONSE -> MAPS IT TO BYTE DATA
            byte[] byteSegments = httpResponse.GetBytes();

            this.client.Send(byteSegments, SocketFlags.None);
        }

        private async Task PrepareResponseAsync(IHttpResponse httpResponse)
        {
            byte[] bytes = httpResponse.GetBytes();

            await this.client.SendAsync(bytes, SocketFlags.None);
        }

        public void ProcessRequest()
        {
            IHttpResponse httpResponse = null;

            try
            {
                IHttpRequest httpRequest = this.ReadRequest();

                if (httpRequest != null)
                {
                    Console.WriteLine($"Processing: {httpRequest.RequestMethod} {httpRequest.Path}...");

                    httpResponse = this.HandleRequest(httpRequest);
                }
            }
            catch (BadRequestException e)
            {
                httpResponse = new TextResult(e.Message, HttpResponseStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                httpResponse = new TextResult(e.Message, HttpResponseStatusCode.InternalServerError);
            }

            this.PrepareResponse(httpResponse);
            this.client.Shutdown(SocketShutdown.Both);
        }
    }
}

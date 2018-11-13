using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace _09_http_server
{
    class HttpServer
    {
        private static readonly string WebRoot = "web";

        private static readonly Dictionary<string, string> PagePathByUrl = new Dictionary<string, string>()
        {
            [""] = Path.Combine(WebRoot, "index.html"),
            ["info"] = Path.Combine(WebRoot, "info.html"),
            ["error"] = Path.Combine(WebRoot, "error.html")
        };

        static void Main()
        {
            var listener = new HttpListener();

            listener.Prefixes.Add("http://localhost:5000/");

            listener.Start();

            Console.WriteLine("Server started");

            while (true)
            {
                var context = listener.GetContext();

                var request = context.Request;
                var response = context.Response;

                var resource = request.Url.LocalPath.Substring(1);
                var pagePath = PagePathByUrl["error"];
                byte[] pageToServe = null;

                if (resource == "info")
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    pagePath = PagePathByUrl[resource];
                    var content = string.Format(File.ReadAllText(pagePath), DateTime.Now, Environment.ProcessorCount);

                    pageToServe = Encoding.UTF8.GetBytes(content);
                }
                else if (resource == "stop")
                {
                    response.StatusCode = (int)HttpStatusCode.Accepted;
                    response.OutputStream.Close();

                    break;
                }
                else if (PagePathByUrl.ContainsKey(resource))
                {
                    response.StatusCode = (int)HttpStatusCode.OK;
                    pagePath = PagePathByUrl[resource];

                    pageToServe = File.ReadAllBytes(pagePath);
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Redirect("/error");
                }

                var output = response.OutputStream;
                output.Write(pageToServe);

                output.Close();
                Console.WriteLine($"Request handled on {resource}");
            }

            listener.Close();
            Console.WriteLine("Server stopped");
        }
    }
}

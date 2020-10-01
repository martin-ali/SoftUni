namespace SIS.Demo
{
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Result;

    public class HomeController
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            var content = "<h1>Hello, web world!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}
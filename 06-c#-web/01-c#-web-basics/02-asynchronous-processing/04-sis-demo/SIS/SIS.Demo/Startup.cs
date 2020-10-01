namespace SIS.Demo
{
    using SIS.HTTP.Enums;
    using SIS.WebServer;
    using SIS.WebServer.Routing;

    class Startup
    {
        static void Main()
        {
            var serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(
                HttpRequestMethod.Get,
                "/",
                request => new HomeController().Index(request)
            );

            var server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}

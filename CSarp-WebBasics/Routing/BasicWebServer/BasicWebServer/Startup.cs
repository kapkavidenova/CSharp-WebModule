using BasicWebServer.Server.Responses;
using BasiWebServer.Server;

namespace BasicWebServer.Demo
{
    public class Startup
    {
        public static void Main()
            => new HttpServer(routes => routes
            .MapGet("/",new TextResponse("Hello from the server."))
            .MapGet("/HTML",new HtmlResponse("<h1>HTML response</h1"))
            .MapGet("/Redirect", new RedirectResponse("https://softuni.org/")))       
            .Start();      
    }
}

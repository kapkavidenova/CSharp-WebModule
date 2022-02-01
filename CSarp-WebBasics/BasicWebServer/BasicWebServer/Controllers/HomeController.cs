using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System.Linq;
using System.Text;
using System.Web;

namespace BasicWebServer.Demo.Controllers
{
    public class HomeController : Controller
    {
        private const string DownloadForm = @"<form action='/Content' method='POST'>
                <input type='submit' value
                ='Download Sites Content'/>
        </form>";

        private const string FileName = "content.txt";

        private const string HtmlForm = @"<form action='/HTML' method='POST'>
            Name: <input type='text' name=Name'/>
            Age: <input type='number' name='Age'/>
            <input type='submit' value='Save' />
        </form>";

        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index() => Text("Hello from the server!");

        public Response Redirect() => Redirect("https://softuni.bg");

        public Response Html() => Html(HomeController.HtmlForm);

        public Response HtmlFormPost()
        {
            var sb = new StringBuilder();

            foreach (var (key, value) in this.Request.Form)
            {
                sb.AppendLine($"{key} - {value}");
            }

            return Text(sb.ToString());
        }

        public Response Content() => Html(DownloadForm);
        public Response DownloadContent() => File(FileName);

        public Response Cookies()
        {
            if (this.Request.Cookies.Any(c => c.Name !=
           BasicWebServer.Server.HTTP.Session.SessionCookieName))
            {
                var cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in this.Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText.Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");
                    cookieText.Append("</tr>");
                    cookieText.Append("</table>");

                    return Html(cookieText.ToString());

                }

            }
                var cookies = new CookieCollection();
                cookies.Add("My-Cookie", "My-cookie");
                cookies.Add("My-Second-Cookie", "My-Second-Value");

                return Html("<h1>Cookies set!</h1>", cookies);
        }
        public Response Session()
        {
            var sessionExists = Request.Session
                .ContainsKey(Server.HTTP.Session.SessionCurrentDateKey);

            var bodyText = "";

            if (sessionExists)
            {
                var currentDate = Request.Session[Server.HTTP.Session.SessionCurrentDateKey];

                bodyText = $"Stored date: {currentDate}!";
            }
            else
            {
                bodyText = "Current date stored!";
            }

            return Text(bodyText);
        }
    }
}

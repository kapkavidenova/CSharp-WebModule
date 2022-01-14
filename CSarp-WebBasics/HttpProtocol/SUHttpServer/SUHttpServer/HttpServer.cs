using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SUHttpServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string _ipAddress, int _port)
        {
            this.ipAddress = IPAddress.Parse(_ipAddress);
            this.port = _port;
            serverListener = new TcpListener(ipAddress, port);
        }

        public void Start()
        {
            this.serverListener.Start();

            Console.WriteLine($"Server started on port{port}.");
            Console.WriteLine("Listening for requests.");

            while (true)
            {
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                string request = ReadRequest(networkStream);
             
                Console.WriteLine(request);

                WriteResponse(networkStream, "Hello World");
                //connection.Close();
            }

        }

        private void WriteResponse(NetworkStream networkStream, string content)
        {
            int contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK
Content-Type:text/plain;charset=UTF-8
Content-Length:{contentLength}

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            networkStream.Write(responseBytes, 0, responseBytes.Length);//Use the network stream to send the response bytes to the browser
        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];
            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);
                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is too large.");
                }
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();


        }
    }
}

using System.Net;
using System.Net.Sockets;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

// Uncomment this block to pass the first stage
TcpListener server = new TcpListener(IPAddress.Any, 6379);
server.Start();

byte[] bytes = new byte[256];

while (true)
{
    using TcpClient client = server.AcceptTcpClient();
    NetworkStream stream = client.GetStream();

    int i;

    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
    {
        string response = "+PONG\r\n";
        byte[] data = System.Text.Encoding.ASCII.GetBytes(response);
        stream.Write(data, 0, data.Length);
    }
}

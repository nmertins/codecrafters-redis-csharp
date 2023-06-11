using System.Net;
using System.Net.Sockets;

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");

// Uncomment this block to pass the first stage
TcpListener server = new TcpListener(IPAddress.Any, 6379);
server.Start();

TcpClient client = server.AcceptTcpClient();
NetworkStream stream = client.GetStream();

string response = "+PONG\r\n";
Byte[] data = System.Text.Encoding.ASCII.GetBytes(response);

stream.Write(data, 0, data.Length);
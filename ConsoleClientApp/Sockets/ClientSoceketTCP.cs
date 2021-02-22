using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleClientApp.Sockets {
	public class ClientSoceketTCP : BaseClientSocket {

		public ClientSoceketTCP() : base(SocketType.Stream, ProtocolType.Tcp) { }

		public override void RunClientSocket() {
			try {
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Connect(IpEndPoint);

				Console.Write("Enter the message: ");
				string message = Console.ReadLine();
				byte[] data = Encoding.Unicode.GetBytes(message);
				socket.Send(data);

				data = new byte[256];
				StringBuilder builder = new StringBuilder();
				int bytes = 0;

				do {
					bytes = socket.Receive(data, data.Length, 0);
					builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
				} while (socket.Available > 0);
				Console.WriteLine("Response from server: " + builder);

				socket.Shutdown(SocketShutdown.Both);
				socket.Close();
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
	}
}

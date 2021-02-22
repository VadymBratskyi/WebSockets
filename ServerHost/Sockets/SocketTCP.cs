using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ServerHost.Sockets {
	public class SocketTCP : BaseSocket {

		public SocketTCP(): base(SocketType.Stream, ProtocolType.Tcp) { }

		public override void RunSocket() {
			try {
				SocketApp.Bind(IpEndPoint);
				SocketApp.Listen(10);
				Console.WriteLine("Server started. Connected..");

				while (true) {
					Socket handler = SocketApp.Accept();
					StringBuilder builder = new StringBuilder();
					int bytes = 0;
					byte[] data = new byte[256];

					do {
						bytes = handler.Receive(data);
						builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
					} while (handler.Available > 0);

					Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder);

					string messageResponse = "Meessage send.";
					data = Encoding.Unicode.GetBytes(messageResponse);
					handler.Send(data);
					handler.Shutdown(SocketShutdown.Both);
					handler.Close();
				}
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
	}
}

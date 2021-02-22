using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ConsoleClientApp.Sockets {
	public class ClientSocketUDP : BaseClientSocket {

		public ClientSocketUDP() : base(SocketType.Dgram, ProtocolType.Udp) { }

		public override void RunClientSocket() {
			try {
				Console.Write("Enter the message: ");
				while (true) {
					string message = Console.ReadLine();

					byte[] data = Encoding.Unicode.GetBytes(message);
					ClientSocketApp.SendTo(data, IpEndPoint);


				}
			}
			catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
			finally {
				Close();
			}
		}
	}
}

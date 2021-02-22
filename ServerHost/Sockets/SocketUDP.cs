using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerHost.Sockets {
	public class SocketUDP : BaseSocket {

		public SocketUDP(): base(SocketType.Dgram, ProtocolType.Udp) {}

		public override void RunSocket() {
			try {
				SocketApp.Bind(IpEndPoint);
				Console.WriteLine("Server started. Connected..");

				while (true) {
					StringBuilder builder = new StringBuilder();
					int bytes = 0;
					byte[] data = new byte[256];
					EndPoint remoteIp = new IPEndPoint(IPAddress.Any, 0);

					do {
						bytes = SocketApp.ReceiveFrom(data, ref remoteIp);
						builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
					} while (SocketApp.Available > 0);

					IPEndPoint remoteFullIp = remoteIp as IPEndPoint;
					Console.WriteLine("{0}:{1} - {2}", remoteFullIp.Address.ToString(),
												   remoteFullIp.Port, builder.ToString());
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

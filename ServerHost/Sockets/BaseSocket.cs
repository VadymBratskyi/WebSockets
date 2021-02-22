using ServerHost.Interfaceses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerHost.Sockets {
	public abstract class BaseSocket : ISocket {

		public int Port { get; set; }
		public IPEndPoint IpEndPoint { get; set; }
		public Socket SocketApp { get; set; }

		public BaseSocket(SocketType socketType, ProtocolType protocolType) {
			Port = 8005;
			IpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
			SocketApp = new Socket(AddressFamily.InterNetwork, socketType, protocolType);
		}

		public abstract void RunSocket();

		public void Close() {
			SocketApp.Shutdown(SocketShutdown.Both);
			SocketApp.Close();
			SocketApp = null;
		}
	}
}

using ConsoleClientApp.Interfaceses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleClientApp.Sockets {
	public abstract class BaseClientSocket : IClientSocket {
		public int Port { get; set; }
		public Socket ClientSocketApp { get; set; }
		public IPEndPoint IpEndPoint { get; set; }

		public BaseClientSocket(SocketType socketType, ProtocolType protocolType) {
			Port = 8005;
			IpEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), Port);
			ClientSocketApp = new Socket(AddressFamily.InterNetwork, socketType, protocolType);
		}

		public abstract void RunClientSocket();

		public void Close() {
			ClientSocketApp.Shutdown(SocketShutdown.Both);
			ClientSocketApp.Close();
			ClientSocketApp = null;
		}
	}
}

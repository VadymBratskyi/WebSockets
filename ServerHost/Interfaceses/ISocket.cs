using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerHost.Interfaceses {
	public interface ISocket {

		public int Port { get; set; }

		public IPEndPoint IpEndPoint { get; set; }

		public Socket SocketApp { get; set; }

		public void RunSocket();
		public void Close();

	}
}

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleClientApp.Interfaceses {
	public interface IClientSocket {

		public int Port { get; set; }

		public IPEndPoint IpEndPoint { get; set; }

		public Socket ClientSocketApp { get; set; }

		public void RunClientSocket();

		public void Close();

	}
}

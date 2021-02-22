using ServerHost.Interfaceses;
using ServerHost.Sockets;
using System;
using System.IO;
using System.Net;

namespace ServerHost {
	class Program {
		static void Main(string[] args) {

			//ISocket testSocket = new SocketTCP();
			ISocket testSocket = new SocketUDP();
			testSocket.RunSocket();

			Console.ReadKey();
		}
	}
}

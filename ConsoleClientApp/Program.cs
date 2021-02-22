using ConsoleClientApp.Interfaceses;
using ConsoleClientApp.Sockets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleClientApp {
	class Program {
		static void Main(string[] args) {

			//IClientSocket clientSocket = new ClientSoceketTCP();
			IClientSocket clientSocket = new ClientSocketUDP();
			clientSocket.RunClientSocket();
		}
	}
}

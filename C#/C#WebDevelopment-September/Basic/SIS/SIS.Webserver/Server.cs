﻿namespace SIS.WebServer
{
	using System;
	using System.Net;
	using System.Net.Sockets;
	using System.Threading.Tasks;
	using Webserver.Api;

	public class Server
	{
		private const string LocalhostIpAddress = "127.0.0.1";

		private readonly int port;

		private readonly TcpListener listener;

		private readonly IHttpHandlingContext handlersContext;

		private bool isRunning;

		public Server(int port, IHttpHandlingContext handlersContext)
		{
			this.port = port;
			this.listener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);
			this.handlersContext = handlersContext;
		}

		public void Run()
		{
			this.listener.Start();
			this.isRunning = true;

			Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{this.port}");
			while (this.isRunning)
			{
				var client = this.listener.AcceptSocketAsync().GetAwaiter().GetResult();
				Task.Run(() => this.Listen(client));
			}
		}

		public async void Listen(Socket client)
		{
			var connectionHandler = new ConnectionHandler(client, this.handlersContext);
			await connectionHandler.ProcessRequestAsync();
		}
	}
}
﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Wifinian
{
	public partial class App : Application
	{
		private AppKeeper _keeper;
		private AppController _controller;

		protected override async void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			_keeper = new AppKeeper(e);
			if (!_keeper.Start())
			{
				this.Shutdown(0); // This shutdown is expected behavior.
				return;
			}

			_controller = new AppController(_keeper);
			await _controller.InitiateAsync();

			//this.MainWindow = new MainWindow();
			//this.MainWindow.Show();
		}

		protected override void OnExit(ExitEventArgs e)
		{
			_controller?.Dispose();
			_keeper?.Dispose();

			base.OnExit(e);
		}
	}
}
using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace OpcLabsBugWindowService
{
	public partial class Service1 : ServiceBase
	{

		public Service1()
		{
			InitializeComponent();
		}

		protected override void OnStart( string[] args )
		{
			Client.Start();
		}

		protected override void OnStop()
		{

		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpcLabsBugWindowService
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
#if ( DEBUG && !DebugSetup )
			Application.Run( new FormDebug() );
			//EndIgnoreMerge
#else
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[]
			{
				new Service1()
			};
			ServiceBase.Run( ServicesToRun );
#endif

		}

	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpcLabsBugWindowService
{
	public partial class FormDebug : Form
	{
		public FormDebug()
		{
			InitializeComponent();
			Client.Start();
		}
	}
}

using System;
using System.Windows.Forms;

namespace 激光快速测量系统
{

	internal static class Program
	{

		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}

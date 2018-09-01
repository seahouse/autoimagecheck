using System;

namespace 激光快速测量系统
{

	public class global1
	{



		public static double Xta1
		{
			get
			{
				return global1.m_xta1;
			}
			set
			{
				global1.m_xta1 = value;
			}
		}




		public static double Xoff1
		{
			get
			{
				return global1.m_xoff1;
			}
			set
			{
				global1.m_xoff1 = value;
			}
		}




		public static double Yoff1
		{
			get
			{
				return global1.m_yoff1;
			}
			set
			{
				global1.m_yoff1 = value;
			}
		}


		private static double m_xta1 = 89.91;


		private static double m_xoff1 = 0.4811;


		private static double m_yoff1 = 0.1615;
	}
}

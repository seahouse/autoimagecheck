using System;
using System.Configuration;

namespace 激光快速测量系统
{
    class Global
    {
        static Global()
        {
            ResultPath = DefaultResultPath;
        }

        enum CoordinateEnum
        {
            X_OFF, Y_OFF, ANGLE
        }
        public static double Angle
        {
            get
            {
                var tmp = Read(CoordinateEnum.ANGLE.ToString());
                return Convert.ToDouble(tmp);
            }
            set
            {
                Write(CoordinateEnum.ANGLE.ToString(), value.ToString());
            }
        }

        public static double XOff
        {
            get
            {
                var tmp = Read(CoordinateEnum.X_OFF.ToString());
                return Convert.ToDouble(tmp);
            }
            set
            {
                Write(CoordinateEnum.X_OFF.ToString(), value.ToString());
            }
        }

        public static double YOff
        {
            get
            {
                var tmp = Read(CoordinateEnum.Y_OFF.ToString());
                return Convert.ToDouble(tmp);
            }
            set
            {
                Write(CoordinateEnum.Y_OFF.ToString(), value.ToString());
            }
        }

        public const string DefaultResultPath = @"C:\PLFM\RESULTS";

        public static string ResultPath { get; set; }

        public static string TempPDFFolder
        {
            get
            {
                var tmp = Read("PDF_TMP_FOLDER");
                return tmp;
            }
        }

        static Configuration GetConfig()
        {
            return ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
        static string Read(string key)
        {
            var config = GetConfig();
            var ret = config.AppSettings.Settings[key].Value;
            return ret;
        }
        static void Write(string key, string value)
        {
            var config = GetConfig();
            var tmp = config.AppSettings.Settings[key];
            if (tmp.Value != value)
            {
                tmp.Value = value;
                config.Save();
            }
        }
    }
}
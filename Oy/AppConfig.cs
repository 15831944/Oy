using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using AutoCADCommands;

namespace Oy.CAD2006.lib
{
    class AppConfig
    {
        private static string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(AssemblyName + ".dll");
        public static string[] ExcelColumnName => config.AppSettings.Settings["ExcelColumnName"].Value.Split(',');
        public static string[] ProjectInfoName => config.AppSettings.Settings["ProjectInfoName"].Value.Split(',');
        public static string DefaultFont => config.AppSettings.Settings["DefaultFont"].Value;
        public static double DefaultColWidth =>Double.Parse(config.AppSettings.Settings["DefaultColWidth"].Value);
        public static double LargerColWidth => Double.Parse(config.AppSettings.Settings["LargerColWidth"].Value);
        public static double DefaultRowHeight => Double.Parse(config.AppSettings.Settings["DefaultRowHeight"].Value);
        public static string CoordinatePrecision => config.AppSettings.Settings["CoordinatePrecision"].Value;
        public static string DistencePrecision => config.AppSettings.Settings["DistencePrecision"].Value;


        public AppConfig()
        {
            // Get the configuration file.
            var s = config.AppSettings.Settings.AllKeys;

            config.AppSettings.Settings.Add("asd", "das");
            Interaction.WriteLine(config.AppSettings.Settings["asd"].Value);

        }

        public static void Update(string Key, string Value)
        {
            config.AppSettings.Settings[Key].Value = Value;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(AssemblyName);
        }


    }
}

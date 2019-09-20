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
        //private static string AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
        private static string AssemblyName = "Oy";
        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(AssemblyName + ".dll");
        private static readonly KeyValueConfigurationCollection Settings = config.AppSettings.Settings;

        // 项目信息
        public static string[] ProjectInfoName => Settings["ProjectInfoName"].Value.Split(',');
       
        // Excel列名
        public static string[] ExcelColumnName => Settings["ExcelColumnName"].Value.Split(',');
        
        // 默认字体
        public static string DefaultFont => Settings["DefaultFont"].Value;
        
        // Excel默认列宽
        public static double DefaultColWidth =>Double.Parse(Settings["DefaultColWidth"].Value);
        
        // Excel大号列宽
        public static double LargerColWidth => Double.Parse(Settings["LargerColWidth"].Value);
        
        // Excel默认行高
        public static double DefaultRowHeight => Double.Parse(Settings["DefaultRowHeight"].Value);
        
        // XY坐标-小数点保留位数
        public static string CoordinatePrecision => Settings["CoordinatePrecision"].Value;
        
        // 距离-小数点保留位数
        public static string DistencePrecision => Settings["DistencePrecision"].Value;

        // 面积-小数点保留位数
        public static int AreaPrecision =>Int32.Parse(Settings["AreaPrecision"].Value);

        //多段线重复点距离
        public static Double ReduceVertexEpsilon => Double.Parse(Settings["ReduceVertexEpsilon"].Value);

        //侧边距(厘米)
        public static decimal SideMargin => decimal.Parse(Settings["SideMargin"].Value);





        /// 更新配置文件，不存在则添加
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public static void Update(string Key, string Value)
        {
            if (Settings[Key] == null)
                Settings.Add(Key, Value);
            else
                Settings[Key].Value = Value;

            //保存
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(AssemblyName);
        }

        public static string Search(string Key)
        {
            return Settings[Key].Value;
        }
    }
}
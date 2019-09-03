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
        private static readonly Configuration config = ConfigurationManager.OpenExeConfiguration(AssemblyName + ".dll");
        
        // 项目信息
        public static string[] ProjectInfoName => config.AppSettings.Settings["ProjectInfoName"].Value.Split(',');
       
        // Excel列名
        public static string[] ExcelColumnName => config.AppSettings.Settings["ExcelColumnName"].Value.Split(',');
        
        // 默认字体
        public static string DefaultFont => config.AppSettings.Settings["DefaultFont"].Value;
        
        // Excel默认列宽
        public static double DefaultColWidth =>Double.Parse(config.AppSettings.Settings["DefaultColWidth"].Value);
        
        // Excel大号列宽
        public static double LargerColWidth => Double.Parse(config.AppSettings.Settings["LargerColWidth"].Value);
        
        // Excel默认行高
        public static double DefaultRowHeight => Double.Parse(config.AppSettings.Settings["DefaultRowHeight"].Value);
        
        // XY坐标-小数点保留位数
        public static string CoordinatePrecision => config.AppSettings.Settings["CoordinatePrecision"].Value;
        
        // 距离-小数点保留位数
        public static string DistencePrecision => config.AppSettings.Settings["DistencePrecision"].Value;

        // 面积-小数点保留位数
        public static int AreaPrecision =>Int32.Parse(config.AppSettings.Settings["AreaPrecision"].Value);

        //多段线重复点距离
        public static Double ReduceVertexEpsilon => Double.Parse(config.AppSettings.Settings["ReduceVertexEpsilon"].Value);





        /// 更新配置文件，不存在则添加
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public static void Update(string Key, string Value)
        {
            if (config.AppSettings.Settings[Key] == null)
                config.AppSettings.Settings.Add(Key, Value);
            else
                config.AppSettings.Settings[Key].Value = Value;

            //保存
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(AssemblyName);
        }

        public static string Search(string Key)
        {
            return config.AppSettings.Settings[Key].Value;
        }
    }
}
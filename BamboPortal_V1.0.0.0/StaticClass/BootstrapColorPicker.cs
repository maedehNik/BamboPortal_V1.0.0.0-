using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BamboPortal_V1._0._0._0.StaticClass
{
    public static class BootstrapColorPicker
    {
        public static string GetbootstrapColorRandom()
        {
            Random r = new Random();
            BootstrapColorEnums randomcolor = (BootstrapColorEnums)r.Next(0, 4);
            return Enum.GetName(typeof(BootstrapColorEnums), randomcolor);
        }
        public static string GetbootstrapColorRandomByCounter(int i)
        {
            
            BootstrapColorEnums randomcolor = (BootstrapColorEnums)(i%5);
            return Enum.GetName(typeof(BootstrapColorEnums), randomcolor);
        }
        public static string GetbootstrapColorByTag(BootstrapColorEnums colortag)
        {
            return Enum.GetName(typeof(BootstrapColorEnums), colortag);
        }
    }
}
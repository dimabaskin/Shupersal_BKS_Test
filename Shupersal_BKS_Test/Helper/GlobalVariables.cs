using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Shupersal_BKS_Test.Helper
{
    public static class GlobalVariables
    {
        public static string UserLogInName = ConfigurationManager.AppSettings["UserLogInName"];
        public static string Password = ConfigurationManager.AppSettings["Password"];
        public static string UserName = ConfigurationManager.AppSettings["UserName"];



    }
}

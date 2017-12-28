using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BL
{
    public static class AppSettings
    {
        public static string LayoutFolder { get; set; }

        public static string FormLayoutFolder
        {
            get { return System.IO.Path.Combine(LayoutFolder, "Forms"); }
        }
        public static string GridLayoutFolder
        {
            get { return System.IO.Path.Combine(LayoutFolder, "Grids"); }
        }
        public static string ViewLayoutFolder
        {
            get { return System.IO.Path.Combine(LayoutFolder, "Views"); }
        }

        public static string MediaDirectory { get; set; }  
        public const string PrintOutsDirectory = "PrintOuts";
        public static string SavingPurposeDefaultText = "כללי";

        public static ConnectionSettings DataContextConnectionSettings { get; set; }
    }

    public class ConnectionSettings
    {
        public string DataSource { get; set; }
        public string InitialCatalog { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }


    }
}

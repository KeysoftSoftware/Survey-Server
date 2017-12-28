using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KF.Primitives.NonPersistent;


namespace Survey.Model
{

    #region QText
    [KF.Primitives.NonPersist]
    public partial class QTextDto : TBaseEntity<QText>
    {

        #region Fields
        public static class Fields
        {
            public static string langCode = "langCode";
            public static string text = "text";
            public static string textLong = "textLong";
            public static string textPopup = "textPopup";
            public static string textPrint = "textPrint";
            public static string textMobile = "textMobile";
            public static string picture = "picture";
        }
        #endregion

        #region Properties

        public string langCode { get; set; }
        public string text { get; set; }
        public string textLong { get; set; }
        public string textPopup { get; set; }
        public string textPrint { get; set; }
        public string textMobile { get; set; }
        public string picture { get; set; }
        #endregion

    }

    #endregion QText

}


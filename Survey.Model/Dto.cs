using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KF.Primitives.NonPersistent;


namespace Survey.Model
{

    #region Sheelon
    [KF.Primitives.NonPersist]
    public partial class SheelonDto : TBaseEntity<Sheelon>
    {

        #region Fields
        public static class Fields
        {
            public static string name = "name";
            public static string openning = "openning";
            public static string loginManagerId = "loginManagerId";
            public static string shared = "shared";
            public static string userId = "userId";
            public static string F1 = "F1";
            public static string F2 = "F2";
            public static string F3 = "F3";
        }
        #endregion

        #region Properties

        public string name { get; set; }
        public string openning { get; set; }
        public int loginManagerId { get; set; }
        public bool shared { get; set; }
        public int userId { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        #endregion

    }

    #endregion Sheelon

    #region SheelonRelease
    [KF.Primitives.NonPersist]
    public partial class SheelonReleaseDto : TBaseEntity<SheelonRelease>
    {

        #region Fields
        public static class Fields
        {
            public static string sheelon = "sheelon";
            public static string fromDate = "fromDate";
            public static string toDate = "toDate";
            public static string relaeaseVersion = "relaeaseVersion";
            public static string name = "name";
        }
        #endregion

        #region Properties

        public int sheelonId { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string relaeaseVersion { get; set; }
        public string name { get; set; }
        #endregion

    }

    #endregion SheelonRelease

    #region Question
    [KF.Primitives.NonPersist]
    public partial class QuestionDto : TBaseEntity<Question>
    {

        #region Fields
        public static class Fields
        {
            public static string categoryId = "categoryId";
            public static string name = "name";
            public static string qType = "qType";
            public static string editorType = "editorType";
            public static string comment = "comment";
            public static string qOptCount = "qOptCount";
            public static string maxAnswerCount = "maxAnswerCount";
        }
        #endregion

        #region Properties

        public int categoryId { get; set; }
        public string name { get; set; }
        public int qTypeId { get; set; }
        public string editorType { get; set; }
        public string comment { get; set; }
        public int qOptCount { get; set; }
        public int maxAnswerCount { get; set; }
        #endregion

    }

    #endregion Question

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

    #region PageNames
    [KF.Primitives.NonPersist]
    public partial class PageNamesDto : TBaseEntity<PageNames>
    {

        #region Fields
        public static class Fields
        {
            public static string sheelonId = "sheelonId";
            public static string pageNo = "pageNo";
            public static string name = "name";
            public static string langCode = "langCode";
        }
        #endregion

        #region Properties

        public int sheelonId { get; set; }
        public int pageNo { get; set; }
        public string name { get; set; }
        public string langCode { get; set; }
        #endregion

    }

    #endregion PageNames

    #region QuestionRelease
    [KF.Primitives.NonPersist]
    public partial class QuestionReleaseDto : TBaseEntity<QuestionRelease>
    {

        #region Fields
        public static class Fields
        {
            public static string qText = "qText";
            public static string fromDate = "fromDate";
            public static string question = "question";
            public static string minSelections = "minSelections";
            public static string rightanswer = "rightanswer";
        }
        #endregion

        #region Properties

        public int qTextId { get; set; }
        public DateTime fromDate { get; set; }
        public int questionId { get; set; }
        public int minSelections { get; set; }
        public int rightanswer { get; set; }
        #endregion

    }

    #endregion QuestionRelease

    #region OrgStruct
    [KF.Primitives.NonPersist]
    public partial class OrgStructDto : TBaseEntity<OrgStruct>
    {

        #region Fields
        public static class Fields
        {
            public static string name = "name";
            public static string description = "description";
            public static string parentOrgStruct = "parentOrgStruct";
            public static string levelNo = "levelNo";
            public static string levelType = "levelType";
            public static string parentId = "parentId";
        }
        #endregion

        #region Properties

        public string name { get; set; }
        public string description { get; set; }
        public int parentOrgStructId { get; set; }
        public int levelNo { get; set; }
        public int levelTypeId { get; set; }
        public int parentId { get; set; }
        #endregion

    }

    #endregion OrgStruct

}


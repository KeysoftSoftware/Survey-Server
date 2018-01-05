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
            public static string sheelonId = "sheelonId";
            public static string fromDate = "fromDate";
            public static string toDate = "toDate";
            public static string releaseVersion = "releaseVersion";
            public static string name = "name";
        }
        #endregion

        #region Properties
        public int sheelonId { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime? toDate { get; set; }
        public string releaseVersion { get; set; }
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
        }
        #endregion

        #region Properties
        public int categoryId { get; set; }
        public string name { get; set; }
        /// <summary>
        /// סוג שאלה
        /// </summary>
        public int qType { get; set; }
        /// <summary>
        /// אדיטור לממשק משתמש
        /// </summary>
        public string editorType { get; set; }
        public string comment { get; set; }
        /// <summary>
        /// מקסימום תשובות לבחירה במקרה שיש מרובה
        /// </summary>
        public int qOptCount { get; set; }

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

    #region SheelonQuestion
    [KF.Primitives.NonPersist]
    public partial class SheelonQuestionDto : TBaseEntity<SheelonQuestion>
    {

        #region Fields
        public static class Fields
        {
            public static string sheelonId = "sheelonId";
            public static string questionId = "questionId";
            public static string sortOrder = "sortOrder";
            public static string isMandatory = "isMandatory";
            public static string pageNo = "pageNo";
        }
        #endregion

        #region Properties
        public int sheelonId { get; set; }
        public int questionId { get; set; }
        public int sortOrder { get; set; }
        public bool isMandatory { get; set; }
        public int pageNo { get; set; }

        #endregion

    }

    #endregion SheelonQuestion

    #region SheelonFill
    [KF.Primitives.NonPersist]
    public partial class SheelonFillDto : TBaseEntity<SheelonFill>
    {

        #region Fields
        public static class Fields
        {
            public static string sheelonReleaseId = "sheelonReleaseId";
            public static string respId = "respId";
            public static string userId = "userId";
            public static string langCode = "langCode";
            public static string depId = "depId";
            public static string period = "period";
            public static string isFinished = "isFinished";
            public static string lastPage = "lastPage";
            public static string lastLangCode = "lastLangCode";
        }
        #endregion

        #region Properties
        /// <summary>
        /// קישור לגרסת השאלון
        /// </summary>
        public int sheelonReleaseId { get; set; }
        public int respId { get; set; }
        public int userId { get; set; }
        /// <summary>
        /// שפת מילוי השאלון
        /// </summary>
        public string langCode { get; set; }
        public int depId { get; set; }
        public int period { get; set; }
        public bool isFinished { get; set; }
        public int lastPage { get; set; }
        public string lastLangCode { get; set; }

        #endregion

    }

    #endregion SheelonFill

    #region QRelease
    [KF.Primitives.NonPersist]
    public partial class QReleaseDto : TBaseEntity<QRelease>
    {

        #region Fields
        public static class Fields
        {
            public static string qTextId = "qTextId";
            public static string fromDate = "fromDate";
            public static string questionId = "questionId";
            public static string minSelections = "minSelections";
            public static string rightanswer = "rightanswer";
        }
        #endregion

        #region Properties
        /// <summary>
        /// קישור לכל הטקסטים
        /// </summary>
        public int qTextId { get; set; }
        /// <summary>
        /// גירסה נכונה מתאריך
        /// </summary>
        public DateTime fromDate { get; set; }
        /// <summary>
        /// קישור להגדרת שאלה
        /// </summary>
        public int questionId { get; set; }
        /// <summary>
        /// מינימום בחירה
        /// </summary>
        public int minSelections { get; set; }
        /// <summary>
        /// מה התשובה הנכונה
        /// </summary>
        public int rightanswer { get; set; }

        #endregion

    }

    #endregion QRelease

    #region QType
    [KF.Primitives.NonPersist]
    public partial class QTypeDto : TBaseEntity<QType>
    {

        #region Fields
        public static class Fields
        {
            public static string typeId = "typeId";
            public static string editor = "editor";
        }
        #endregion

        #region Properties
        public int typeId { get; set; }
        public string editor { get; set; }

        #endregion

    }

    #endregion QType

    #region OrgStruct
    [KF.Primitives.NonPersist]
    public partial class OrgStructDto : TBaseEntity<OrgStruct>
    {

        #region Fields
        public static class Fields
        {
            public static string name = "name";
            public static string description = "description";
            public static string parentOrgStructId = "parentOrgStructId";
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

    #region QOption
    [KF.Primitives.NonPersist]
    public partial class QOptionDto : TBaseEntity<QOption>
    {

        #region Fields
        public static class Fields
        {
            public static string qTextId = "qTextId";
            public static string value = "value";
            public static string hasNoInput = "hasNoInput";
        }
        #endregion

        #region Properties
        public int qTextId { get; set; }
        public double value { get; set; }
        public bool hasNoInput { get; set; }

        #endregion

    }

    #endregion QOption

    #region QReleaseOpt
    [KF.Primitives.NonPersist]
    public partial class QReleaseOptDto : TBaseEntity<QReleaseOpt>
    {

        #region Fields
        public static class Fields
        {
            public static string questionReleaseId = "questionReleaseId";
            public static string sortOrder = "sortOrder";
            public static string qOptionId = "qOptionId";
        }
        #endregion

        #region Properties
        public int questionReleaseId { get; set; }
        public int sortOrder { get; set; }
        public int qOptionId { get; set; }

        #endregion

    }

    #endregion QReleaseOpt

    #region SheelonQHiding
    [KF.Primitives.NonPersist]
    public partial class SheelonQHidingDto : TBaseEntity<SheelonQHiding>
    {

        #region Fields
        public static class Fields
        {
            public static string sheelonId = "sheelonId";
            public static string sourceQuestionId = "sourceQuestionId";
            public static string targetQuestionId = "targetQuestionId";
            public static string sourceQuestionAnswer = "sourceQuestionAnswer";
            public static string hideFlag = "hideFlag";
        }
        #endregion

        #region Properties
        public int sheelonId { get; set; }
        /// <summary>
        /// שאלת המקור אשר תשובה שלה תגרום לטריגר
        /// </summary>
        public int sourceQuestionId { get; set; }
        /// <summary>
        /// שאלת היעד להסתרה
        /// </summary>
        public int targetQuestionId { get; set; }
        /// <summary>
        /// התשובה שתביא להסתרה
        /// </summary>
        public double sourceQuestionAnswer { get; set; }
        /// <summary>
        /// האם להסתיר
        /// </summary>
        public bool hideFlag { get; set; }

        #endregion

    }

    #endregion SheelonQHiding

}


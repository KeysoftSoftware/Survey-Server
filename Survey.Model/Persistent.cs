using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KF.Primitives;
using KF.Interfaces;
using DevExpress.Xpo;


namespace Survey.Model
{

    #region Sheelon
    public partial class Sheelon : ModelBase
    {

        #region Constructor
        public Sheelon(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region name
        private string _name;

        public string name
        {
            get { return _name; }
            set { SetValue<string>("name", ref _name, value); }
        }
        #endregion

        #region openning
        private string _openning;

        public string openning
        {
            get { return _openning; }
            set { SetValue<string>("openning", ref _openning, value); }
        }
        #endregion

        #region loginManagerId
        private int _loginManagerId;

        public int loginManagerId
        {
            get { return _loginManagerId; }
            set { SetValue<int>("loginManagerId", ref _loginManagerId, value); }
        }
        #endregion

        #region shared
        private bool _shared;

        public bool shared
        {
            get { return _shared; }
            set { SetValue<bool>("shared", ref _shared, value); }
        }
        #endregion

        #region userId
        private int _userId;

        public int userId
        {
            get { return _userId; }
            set { SetValue<int>("userId", ref _userId, value); }
        }
        #endregion

        #region F1
        private string _F1;

        public string F1
        {
            get { return _F1; }
            set { SetValue<string>("F1", ref _F1, value); }
        }
        #endregion

        #region F2
        private string _F2;

        public string F2
        {
            get { return _F2; }
            set { SetValue<string>("F2", ref _F2, value); }
        }
        #endregion

        #region F3
        private string _F3;

        public string F3
        {
            get { return _F3; }
            set { SetValue<string>("F3", ref _F3, value); }
        }
        #endregion

        #endregion

    }

    #endregion Sheelon

    #region SRelease
    public partial class SRelease : ModelBase
    {

        #region Constructor
        public SRelease(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region sheelonId
        private int _sheelonId;

        public int sheelonId
        {
            get { return _sheelonId; }
            set { SetValue<int>("sheelonId", ref _sheelonId, value); }
        }
        #endregion

        #region fromDate
        private DateTime _fromDate;

        public DateTime fromDate
        {
            get { return _fromDate; }
            set { SetValue<DateTime>("fromDate", ref _fromDate, value); }
        }
        #endregion

        #region toDate
        private DateTime? _toDate;

        public DateTime? toDate
        {
            get { return _toDate; }
            set { SetValue<DateTime?>("toDate", ref _toDate, value); }
        }
        #endregion

        #region releaseVersion
        private string _releaseVersion;

        public string releaseVersion
        {
            get { return _releaseVersion; }
            set { SetValue<string>("releaseVersion", ref _releaseVersion, value); }
        }
        #endregion

        #region name
        private string _name;

        public string name
        {
            get { return _name; }
            set { SetValue<string>("name", ref _name, value); }
        }
        #endregion

        #endregion

    }

    #endregion SRelease

    #region Question
    public partial class Question : ModelBase
    {

        #region Constructor
        public Question(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region categoryId
        private int _categoryId;

        public int categoryId
        {
            get { return _categoryId; }
            set { SetValue<int>("categoryId", ref _categoryId, value); }
        }
        #endregion

        #region name
        private string _name;

        public string name
        {
            get { return _name; }
            set { SetValue<string>("name", ref _name, value); }
        }
        #endregion

        #region comment
        private string _comment;

        public string comment
        {
            get { return _comment; }
            set { SetValue<string>("comment", ref _comment, value); }
        }
        #endregion

        #endregion

    }

    #endregion Question

    #region QText
    public partial class QText : ModelBase
    {

        #region Constructor
        public QText(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region langCode
        private string _langCode;

        public string langCode
        {
            get { return _langCode; }
            set { SetValue<string>("langCode", ref _langCode, value); }
        }
        #endregion

        #region text
        private string _text;

        public string text
        {
            get { return _text; }
            set { SetValue<string>("text", ref _text, value); }
        }
        #endregion

        #region textLong
        private string _textLong;

        public string textLong
        {
            get { return _textLong; }
            set { SetValue<string>("textLong", ref _textLong, value); }
        }
        #endregion

        #region textPopup
        private string _textPopup;

        public string textPopup
        {
            get { return _textPopup; }
            set { SetValue<string>("textPopup", ref _textPopup, value); }
        }
        #endregion

        #region textPrint
        private string _textPrint;

        public string textPrint
        {
            get { return _textPrint; }
            set { SetValue<string>("textPrint", ref _textPrint, value); }
        }
        #endregion

        #region textMobile
        private string _textMobile;

        public string textMobile
        {
            get { return _textMobile; }
            set { SetValue<string>("textMobile", ref _textMobile, value); }
        }
        #endregion

        #region picture
        private string _picture;

        public string picture
        {
            get { return _picture; }
            set { SetValue<string>("picture", ref _picture, value); }
        }
        #endregion

        #endregion

    }

    #endregion QText

    #region PageNames
    public partial class PageNames : ModelBase
    {

        #region Constructor
        public PageNames(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region sheelonId
        private int _sheelonId;

        public int sheelonId
        {
            get { return _sheelonId; }
            set { SetValue<int>("sheelonId", ref _sheelonId, value); }
        }
        #endregion

        #region pageNo
        private int _pageNo;

        public int pageNo
        {
            get { return _pageNo; }
            set { SetValue<int>("pageNo", ref _pageNo, value); }
        }
        #endregion

        #region name
        private string _name;

        public string name
        {
            get { return _name; }
            set { SetValue<string>("name", ref _name, value); }
        }
        #endregion

        #region langCode
        private string _langCode;

        public string langCode
        {
            get { return _langCode; }
            set { SetValue<string>("langCode", ref _langCode, value); }
        }
        #endregion

        #endregion

    }

    #endregion PageNames

    #region SQRelease
    public partial class SQRelease : ModelBase
    {

        #region Constructor
        public SQRelease(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region sReleaseId
        private int _sReleaseId;

        public int sReleaseId
        {
            get { return _sReleaseId; }
            set { SetValue<int>("sReleaseId", ref _sReleaseId, value); }
        }
        #endregion

        #region qReleaseId
        private int _qReleaseId;

        public int qReleaseId
        {
            get { return _qReleaseId; }
            set { SetValue<int>("qReleaseId", ref _qReleaseId, value); }
        }
        #endregion

        #region pageNo
        private int _pageNo;

        public int pageNo
        {
            get { return _pageNo; }
            set { SetValue<int>("pageNo", ref _pageNo, value); }
        }
        #endregion

        #region isMandatory
        private bool _isMandatory;

        public bool isMandatory
        {
            get { return _isMandatory; }
            set { SetValue<bool>("isMandatory", ref _isMandatory, value); }
        }
        #endregion

        #region sortOrder
        private int _sortOrder;

        public int sortOrder
        {
            get { return _sortOrder; }
            set { SetValue<int>("sortOrder", ref _sortOrder, value); }
        }
        #endregion

        #endregion

    }

    #endregion SQRelease

    #region SFill
    public partial class SFill : ModelBase
    {

        #region Constructor
        public SFill(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region sheelonReleaseId
        private int _sheelonReleaseId;
        /// <summary>
        /// קישור לגרסת השאלון
        /// </summary>

        public int sheelonReleaseId
        {
            get { return _sheelonReleaseId; }
            set { SetValue<int>("sheelonReleaseId", ref _sheelonReleaseId, value); }
        }
        #endregion

        #region respId
        private int _respId;

        public int respId
        {
            get { return _respId; }
            set { SetValue<int>("respId", ref _respId, value); }
        }
        #endregion

        #region userId
        private int _userId;

        public int userId
        {
            get { return _userId; }
            set { SetValue<int>("userId", ref _userId, value); }
        }
        #endregion

        #region langCode
        private string _langCode;
        /// <summary>
        /// שפת מילוי השאלון
        /// </summary>

        public string langCode
        {
            get { return _langCode; }
            set { SetValue<string>("langCode", ref _langCode, value); }
        }
        #endregion

        #region depId
        private int _depId;

        public int depId
        {
            get { return _depId; }
            set { SetValue<int>("depId", ref _depId, value); }
        }
        #endregion

        #region period
        private int _period;

        public int period
        {
            get { return _period; }
            set { SetValue<int>("period", ref _period, value); }
        }
        #endregion

        #region isFinished
        private bool _isFinished;

        public bool isFinished
        {
            get { return _isFinished; }
            set { SetValue<bool>("isFinished", ref _isFinished, value); }
        }
        #endregion

        #region lastPage
        private int _lastPage;

        public int lastPage
        {
            get { return _lastPage; }
            set { SetValue<int>("lastPage", ref _lastPage, value); }
        }
        #endregion

        #region lastLangCode
        private string _lastLangCode;

        public string lastLangCode
        {
            get { return _lastLangCode; }
            set { SetValue<string>("lastLangCode", ref _lastLangCode, value); }
        }
        #endregion

        #endregion

    }

    #endregion SFill

    #region Answer
    public partial class Answer : ModelBase
    {

        #region Constructor
        public Answer(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region sheelonFillId
        private int _sheelonFillId;
        /// <summary>
        /// קוד מילוי שאלון
        /// </summary>

        public int sheelonFillId
        {
            get { return _sheelonFillId; }
            set { SetValue<int>("sheelonFillId", ref _sheelonFillId, value); }
        }
        #endregion

        #region questionReleaseId
        private int _questionReleaseId;
        /// <summary>
        /// קישור לגרסת השאלה
        /// </summary>

        public int questionReleaseId
        {
            get { return _questionReleaseId; }
            set { SetValue<int>("questionReleaseId", ref _questionReleaseId, value); }
        }
        #endregion

        #region textValue
        private string _textValue;

        public string textValue
        {
            get { return _textValue; }
            set { SetValue<string>("textValue", ref _textValue, value); }
        }
        #endregion

        #region dateValue
        private DateTime _dateValue;

        public DateTime dateValue
        {
            get { return _dateValue; }
            set { SetValue<DateTime>("dateValue", ref _dateValue, value); }
        }
        #endregion

        #region numberValue
        private double _numberValue;

        public double numberValue
        {
            get { return _numberValue; }
            set { SetValue<double>("numberValue", ref _numberValue, value); }
        }
        #endregion

        #region boolValue
        private string _boolValue;

        public string boolValue
        {
            get { return _boolValue; }
            set { SetValue<string>("boolValue", ref _boolValue, value); }
        }
        #endregion

        #endregion

    }

    #endregion Answer

    #region QRelease
    public partial class QRelease : ModelBase
    {

        #region Constructor
        public QRelease(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region questionId
        private int _questionId;
        /// <summary>
        /// קישור להגדרת שאלה
        /// </summary>

        public int questionId
        {
            get { return _questionId; }
            set { SetValue<int>("questionId", ref _questionId, value); }
        }
        #endregion

        #region fromDate
        private DateTime _fromDate;
        /// <summary>
        /// גירסה נכונה מתאריך
        /// </summary>

        public DateTime fromDate
        {
            get { return _fromDate; }
            set { SetValue<DateTime>("fromDate", ref _fromDate, value); }
        }
        #endregion

        #region toDate
        private DateTime _toDate;
        /// <summary>
        /// \
        /// </summary>

        public DateTime toDate
        {
            get { return _toDate; }
            set { SetValue<DateTime>("toDate", ref _toDate, value); }
        }
        #endregion

        #region qTextId
        private int _qTextId;
        /// <summary>
        /// קישור לכל הטקסטים
        /// </summary>

        public int qTextId
        {
            get { return _qTextId; }
            set { SetValue<int>("qTextId", ref _qTextId, value); }
        }
        #endregion

        #region maxOptCount
        private int _maxOptCount;
        /// <summary>
        /// מספר בחירות
        /// </summary>

        public int maxOptCount
        {
            get { return _maxOptCount; }
            set { SetValue<int>("maxOptCount", ref _maxOptCount, value); }
        }
        #endregion

        #region minSelections
        private int _minSelections;
        /// <summary>
        /// מינימום בחירות
        /// </summary>

        public int minSelections
        {
            get { return _minSelections; }
            set { SetValue<int>("minSelections", ref _minSelections, value); }
        }
        #endregion

        #region rightanswer
        private int _rightanswer;
        /// <summary>
        /// מה התשובה הנכונה
        /// </summary>

        public int rightanswer
        {
            get { return _rightanswer; }
            set { SetValue<int>("rightanswer", ref _rightanswer, value); }
        }
        #endregion

        #region qTypeId
        private int _qTypeId;
        /// <summary>
        /// סןג הרכיב להצגה בממשק משתמש
        /// </summary>

        public int qTypeId
        {
            get { return _qTypeId; }
            set { SetValue<int>("qTypeId", ref _qTypeId, value); }
        }
        #endregion

        #endregion

    }

    #endregion QRelease

    #region QType
    public partial class QType : ModelBase
    {

        #region Constructor
        public QType(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region typeId
        private int _typeId;

        public int typeId
        {
            get { return _typeId; }
            set { SetValue<int>("typeId", ref _typeId, value); }
        }
        #endregion

        #region editor
        private string _editor;

        public string editor
        {
            get { return _editor; }
            set { SetValue<string>("editor", ref _editor, value); }
        }
        #endregion

        #endregion

    }

    #endregion QType

    #region OrgStruct
    public partial class OrgStruct : ModelBase
    {

        #region Constructor
        public OrgStruct(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region name
        private string _name;

        public string name
        {
            get { return _name; }
            set { SetValue<string>("name", ref _name, value); }
        }
        #endregion

        #region description
        private string _description;

        public string description
        {
            get { return _description; }
            set { SetValue<string>("description", ref _description, value); }
        }
        #endregion

        #region parentOrgStructId
        private int _parentOrgStructId;

        public int parentOrgStructId
        {
            get { return _parentOrgStructId; }
            set { SetValue<int>("parentOrgStructId", ref _parentOrgStructId, value); }
        }
        #endregion

        #region levelNo
        private int _levelNo;

        public int levelNo
        {
            get { return _levelNo; }
            set { SetValue<int>("levelNo", ref _levelNo, value); }
        }
        #endregion

        #region levelType
        private LOV _levelType;

        public LOV levelType
        {
            get { return _levelType; }
            set { SetValue<LOV>("levelType", ref _levelType, value); }
        }
        #endregion

        #region parentId
        private int _parentId;

        public int parentId
        {
            get { return _parentId; }
            set { SetValue<int>("parentId", ref _parentId, value); }
        }
        #endregion

        #endregion

    }

    #endregion OrgStruct

    #region QOption
    public partial class QOption : ModelBase
    {

        #region Constructor
        public QOption(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region qTextId
        private int _qTextId;

        public int qTextId
        {
            get { return _qTextId; }
            set { SetValue<int>("qTextId", ref _qTextId, value); }
        }
        #endregion

        #region value
        private double _value;

        public double value
        {
            get { return _value; }
            set { SetValue<double>("value", ref _value, value); }
        }
        #endregion

        #region hasNoInput
        private bool _hasNoInput;

        public bool hasNoInput
        {
            get { return _hasNoInput; }
            set { SetValue<bool>("hasNoInput", ref _hasNoInput, value); }
        }
        #endregion

        #endregion

    }

    #endregion QOption

    #region QReleaseOption
    public partial class QReleaseOption : ModelBase
    {

        #region Constructor
        public QReleaseOption(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region qReleaseId
        private int _qReleaseId;

        public int qReleaseId
        {
            get { return _qReleaseId; }
            set { SetValue<int>("qReleaseId", ref _qReleaseId, value); }
        }
        #endregion

        #region sortOrder
        private int _sortOrder;

        public int sortOrder
        {
            get { return _sortOrder; }
            set { SetValue<int>("sortOrder", ref _sortOrder, value); }
        }
        #endregion

        #region qOptionId
        private int _qOptionId;

        public int qOptionId
        {
            get { return _qOptionId; }
            set { SetValue<int>("qOptionId", ref _qOptionId, value); }
        }
        #endregion

        #endregion

    }

    #endregion QReleaseOption

    #region SQHiding
    public partial class SQHiding : ModelBase
    {

        #region Constructor
        public SQHiding(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region sheelonId
        private int _sheelonId;

        public int sheelonId
        {
            get { return _sheelonId; }
            set { SetValue<int>("sheelonId", ref _sheelonId, value); }
        }
        #endregion

        #region sourceQuestionId
        private int _sourceQuestionId;
        /// <summary>
        /// שאלת המקור אשר תשובה שלה תגרום לטריגר
        /// </summary>

        public int sourceQuestionId
        {
            get { return _sourceQuestionId; }
            set { SetValue<int>("sourceQuestionId", ref _sourceQuestionId, value); }
        }
        #endregion

        #region targetQuestionId
        private int _targetQuestionId;
        /// <summary>
        /// שאלת היעד להסתרה
        /// </summary>

        public int targetQuestionId
        {
            get { return _targetQuestionId; }
            set { SetValue<int>("targetQuestionId", ref _targetQuestionId, value); }
        }
        #endregion

        #region sourceQuestionAnswer
        private double _sourceQuestionAnswer;
        /// <summary>
        /// התשובה שתביא להסתרה
        /// </summary>

        public double sourceQuestionAnswer
        {
            get { return _sourceQuestionAnswer; }
            set { SetValue<double>("sourceQuestionAnswer", ref _sourceQuestionAnswer, value); }
        }
        #endregion

        #region hideFlag
        private bool _hideFlag;
        /// <summary>
        /// האם להסתיר
        /// </summary>

        public bool hideFlag
        {
            get { return _hideFlag; }
            set { SetValue<bool>("hideFlag", ref _hideFlag, value); }
        }
        #endregion

        #endregion

    }

    #endregion SQHiding

    #region HidingTest
    public partial class HidingTest : ModelBase
    {

        #region Constructor
        public HidingTest(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region name
        private string _name;

        public string name
        {
            get { return _name; }
            set { SetValue<string>("name", ref _name, value); }
        }
        #endregion

        #endregion

    }

    #endregion HidingTest

}


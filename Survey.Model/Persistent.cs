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

    #region SheelonRelease
    public partial class SheelonRelease : ModelBase
    {

        #region Constructor
        public SheelonRelease(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region sheelon
        private Sheelon _sheelon;
        public Sheelon sheelon
        {
            get { return _sheelon; }
            set { SetValue<Sheelon>("sheelon", ref _sheelon, value); }
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

        #region relaeaseVersion
        private string _relaeaseVersion;
        public string relaeaseVersion
        {
            get { return _relaeaseVersion; }
            set { SetValue<string>("relaeaseVersion", ref _relaeaseVersion, value); }
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

    #endregion SheelonRelease

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

        #region qType
        private QType _qType;
        public QType qType
        {
            get { return _qType; }
            set { SetValue<QType>("qType", ref _qType, value); }
        }
        #endregion

        #region editorType
        private string _editorType;
        public string editorType
        {
            get { return _editorType; }
            set { SetValue<string>("editorType", ref _editorType, value); }
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

        #region qOptCount
        private int _qOptCount;
        public int qOptCount
        {
            get { return _qOptCount; }
            set { SetValue<int>("qOptCount", ref _qOptCount, value); }
        }
        #endregion

        #region maxAnswerCount
        private int _maxAnswerCount;
        public int maxAnswerCount
        {
            get { return _maxAnswerCount; }
            set { SetValue<int>("maxAnswerCount", ref _maxAnswerCount, value); }
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

    #region SheelonQuestion
    public partial class SheelonQuestion : ModelBase
    {

        #region Constructor
        public SheelonQuestion(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region sheelon
        private Sheelon _sheelon;
        public Sheelon sheelon
        {
            get { return _sheelon; }
            set { SetValue<Sheelon>("sheelon", ref _sheelon, value); }
        }
        #endregion

        #region question
        private Question _question;
        public Question question
        {
            get { return _question; }
            set { SetValue<Question>("question", ref _question, value); }
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

        #region isMandatory
        private bool _isMandatory;
        public bool isMandatory
        {
            get { return _isMandatory; }
            set { SetValue<bool>("isMandatory", ref _isMandatory, value); }
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

        #endregion

    }

    #endregion SheelonQuestion

    #region SheelonFill
    public partial class SheelonFill : ModelBase
    {

        #region Constructor
        public SheelonFill(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region sheelonRelease
        private SheelonRelease _sheelonRelease;
        public SheelonRelease sheelonRelease
        {
            get { return _sheelonRelease; }
            set { SetValue<SheelonRelease>("sheelonRelease", ref _sheelonRelease, value); }
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

    #endregion SheelonFill

    #region Answer
    public partial class Answer : ModelBase
    {

        #region Constructor
        public Answer(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region SheelonFill
        private SheelonFill _SheelonFill;
        public SheelonFill SheelonFill
        {
            get { return _SheelonFill; }
            set { SetValue<SheelonFill>("SheelonFill", ref _SheelonFill, value); }
        }
        #endregion

        #region questionRelease
        private QuestionRelease _questionRelease;
        public QuestionRelease questionRelease
        {
            get { return _questionRelease; }
            set { SetValue<QuestionRelease>("questionRelease", ref _questionRelease, value); }
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

        #region date
        private DateTime _date;
        public DateTime date
        {
            get { return _date; }
            set { SetValue<DateTime>("date", ref _date, value); }
        }
        #endregion

        #region number
        private double _number;
        public double number
        {
            get { return _number; }
            set { SetValue<double>("number", ref _number, value); }
        }
        #endregion

        #endregion

    }

    #endregion Answer

    #region QuestionRelease
    public partial class QuestionRelease : ModelBase
    {

        #region Constructor
        public QuestionRelease(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region qText
        private QText _qText;
        public QText qText
        {
            get { return _qText; }
            set { SetValue<QText>("qText", ref _qText, value); }
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

        #region question
        private Question _question;
        public Question question
        {
            get { return _question; }
            set { SetValue<Question>("question", ref _question, value); }
        }
        #endregion

        #region minSelections
        private int _minSelections;
        public int minSelections
        {
            get { return _minSelections; }
            set { SetValue<int>("minSelections", ref _minSelections, value); }
        }
        #endregion

        #region rightanswer
        private int _rightanswer;
        public int rightanswer
        {
            get { return _rightanswer; }
            set { SetValue<int>("rightanswer", ref _rightanswer, value); }
        }
        #endregion

        #endregion

    }

    #endregion QuestionRelease

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

        #region parentOrgStruct
        private OrgStruct _parentOrgStruct;
        public OrgStruct parentOrgStruct
        {
            get { return _parentOrgStruct; }
            set { SetValue<OrgStruct>("parentOrgStruct", ref _parentOrgStruct, value); }
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

}


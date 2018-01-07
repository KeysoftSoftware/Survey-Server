using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Views
{
    #region View_QRelease
    public partial class View_QRelease : XPLiteObject
    {
        public View_QRelease(Session prmSession)
    : base(prmSession)
        {

        }

        int fId;
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>(nameof(Id), ref fId, value); }
        }
        int fquestionId;
        public int questionId
        {
            get { return fquestionId; }
            set { SetPropertyValue<int>(nameof(questionId), ref fquestionId, value); }
        }
        DateTime ffromDate;
        public DateTime fromDate
        {
            get { return ffromDate; }
            set { SetPropertyValue<DateTime>(nameof(fromDate), ref ffromDate, value); }
        }
        DateTime ftoDate;
        public DateTime toDate
        {
            get { return ftoDate; }
            set { SetPropertyValue<DateTime>(nameof(toDate), ref ftoDate, value); }
        }
        string ftext;
        public string text
        {
            get { return ftext; }
            set { SetPropertyValue<string>(nameof(text), ref ftext, value); }
        }
        string ftextLong;
        public string textLong
        {
            get { return ftextLong; }
            set { SetPropertyValue<string>(nameof(textLong), ref ftextLong, value); }
        }
        string ftextPopup;
        public string textPopup
        {
            get { return ftextPopup; }
            set { SetPropertyValue<string>(nameof(textPopup), ref ftextPopup, value); }
        }
        string ftextPrint;
        public string textPrint
        {
            get { return ftextPrint; }
            set { SetPropertyValue<string>(nameof(textPrint), ref ftextPrint, value); }
        }
        string ftextMobile;
        public string textMobile
        {
            get { return ftextMobile; }
            set { SetPropertyValue<string>(nameof(textMobile), ref ftextMobile, value); }
        }
        string fpicture;
        public string picture
        {
            get { return fpicture; }
            set { SetPropertyValue<string>(nameof(picture), ref fpicture, value); }
        }
        int fmaxOptCount;
        public int maxOptCount
        {
            get { return fmaxOptCount; }
            set { SetPropertyValue<int>(nameof(maxOptCount), ref fmaxOptCount, value); }
        }
        int fminSelections;
        public int minSelections
        {
            get { return fminSelections; }
            set { SetPropertyValue<int>(nameof(minSelections), ref fminSelections, value); }
        }
        int frightanswer;
        public int rightanswer
        {
            get { return frightanswer; }
            set { SetPropertyValue<int>(nameof(rightanswer), ref frightanswer, value); }
        }
    }

    #endregion

    #region View_Sheelon
    public partial class View_Sheelon : XPLiteObject
    {
        public View_Sheelon(Session prmSession): base(prmSession)
        {

        }

        int fId;
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>(nameof(Id), ref fId, value); }
        }
        string fCode;
        public string Code
        {
            get { return fCode; }
            set { SetPropertyValue<string>(nameof(Code), ref fCode, value); }
        }
        bool fIsActive;
        public bool IsActive
        {
            get { return fIsActive; }
            set { SetPropertyValue<bool>(nameof(IsActive), ref fIsActive, value); }
        }
        string fCreatedBy;
        public string CreatedBy
        {
            get { return fCreatedBy; }
            set { SetPropertyValue<string>(nameof(CreatedBy), ref fCreatedBy, value); }
        }
        DateTime fCreatedOn;
        public DateTime CreatedOn
        {
            get { return fCreatedOn; }
            set { SetPropertyValue<DateTime>(nameof(CreatedOn), ref fCreatedOn, value); }
        }
        string fLastUpdateBy;
        public string LastUpdateBy
        {
            get { return fLastUpdateBy; }
            set { SetPropertyValue<string>(nameof(LastUpdateBy), ref fLastUpdateBy, value); }
        }
        DateTime fVersion;
        public DateTime Version
        {
            get { return fVersion; }
            set { SetPropertyValue<DateTime>(nameof(Version), ref fVersion, value); }
        }
        string fname;
        public string name
        {
            get { return fname; }
            set { SetPropertyValue<string>(nameof(name), ref fname, value); }
        }
        string fopenning;
        public string openning
        {
            get { return fopenning; }
            set { SetPropertyValue<string>(nameof(openning), ref fopenning, value); }
        }
        int floginManagerId;
        public int loginManagerId
        {
            get { return floginManagerId; }
            set { SetPropertyValue<int>(nameof(loginManagerId), ref floginManagerId, value); }
        }
        bool fshared;
        public bool shared
        {
            get { return fshared; }
            set { SetPropertyValue<bool>(nameof(shared), ref fshared, value); }
        }
        int fuserId;
        public int userId
        {
            get { return fuserId; }
            set { SetPropertyValue<int>(nameof(userId), ref fuserId, value); }
        }
        string fF1;
        public string F1
        {
            get { return fF1; }
            set { SetPropertyValue<string>(nameof(F1), ref fF1, value); }
        }
        string fF2;
        public string F2
        {
            get { return fF2; }
            set { SetPropertyValue<string>(nameof(F2), ref fF2, value); }
        }
        string fF3;
        public string F3
        {
            get { return fF3; }
            set { SetPropertyValue<string>(nameof(F3), ref fF3, value); }
        }
        int fReleaseCount;
        public int ReleaseCount
        {
            get { return fReleaseCount; }
            set { SetPropertyValue<int>(nameof(ReleaseCount), ref fReleaseCount, value); }
        }
    }

    #endregion

    #region View_SQRelease
    public partial class View_SQRelease : XPLiteObject
    {
        public View_SQRelease(Session prmSession) : base(prmSession)
        {

        }

        int fId;
        [Key]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>(nameof(Id), ref fId, value); }
        }
        string freleaseVersion;
        public string releaseVersion
        {
            get { return freleaseVersion; }
            set { SetPropertyValue<string>(nameof(releaseVersion), ref freleaseVersion, value); }
        }
        string fname;
        public string name
        {
            get { return fname; }
            set { SetPropertyValue<string>(nameof(name), ref fname, value); }
        }
        int fsReleaseId;
        public int sReleaseId
        {
            get { return fsReleaseId; }
            set { SetPropertyValue<int>(nameof(sReleaseId), ref fsReleaseId, value); }
        }
        int fquestionId;
        public int questionId
        {
            get { return fquestionId; }
            set { SetPropertyValue<int>(nameof(questionId), ref fquestionId, value); }
        }
        int fpageNo;
        public int pageNo
        {
            get { return fpageNo; }
            set { SetPropertyValue<int>(nameof(pageNo), ref fpageNo, value); }
        }
        bool fisMandatory;
        public bool isMandatory
        {
            get { return fisMandatory; }
            set { SetPropertyValue<bool>(nameof(isMandatory), ref fisMandatory, value); }
        }
        int fsortOrder;
        public int sortOrder
        {
            get { return fsortOrder; }
            set { SetPropertyValue<int>(nameof(sortOrder), ref fsortOrder, value); }
        }
        string ftext;
        public string text
        {
            get { return ftext; }
            set { SetPropertyValue<string>(nameof(text), ref ftext, value); }
        }
        string fpicture;
        public string picture
        {
            get { return fpicture; }
            set { SetPropertyValue<string>(nameof(picture), ref fpicture, value); }
        }
        int fmaxOptCount;
        public int maxOptCount
        {
            get { return fmaxOptCount; }
            set { SetPropertyValue<int>(nameof(maxOptCount), ref fmaxOptCount, value); }
        }
        int fminSelections;
        public int minSelections
        {
            get { return fminSelections; }
            set { SetPropertyValue<int>(nameof(minSelections), ref fminSelections, value); }
        }
        int frightanswer;
        public int rightanswer
        {
            get { return frightanswer; }
            set { SetPropertyValue<int>(nameof(rightanswer), ref frightanswer, value); }
        }

        int fqTypeId;
        public int qTypeId
        {
            get { return fqTypeId; }
            set { SetPropertyValue<int>(nameof(qTypeId), ref fqTypeId, value); }
        }

        string ftextLong;
        public string textLong
        {
            get { return ftextLong; }
            set { SetPropertyValue<string>(nameof(textLong), ref ftextLong, value); }
        }
        string ftextPopup;
        public string textPopup
        {
            get { return ftextPopup; }
            set { SetPropertyValue<string>(nameof(textPopup), ref ftextPopup, value); }
        }
        string ftextPrint;
        public string textPrint
        {
            get { return ftextPrint; }
            set { SetPropertyValue<string>(nameof(textPrint), ref ftextPrint, value); }
        }
        string ftextMobile;
        public string textMobile
        {
            get { return ftextMobile; }
            set { SetPropertyValue<string>(nameof(textMobile), ref ftextMobile, value); }
        }
    }

    #endregion

    #region View_QReleaseOption
    public partial class View_QReleaseOption : XPLiteObject
    {
        public View_QReleaseOption(Session prmSession) : base(prmSession)
        {

        }
        int fId;
        [Key]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue<int>(nameof(Id), ref fId, value); }
        }
        int fqReleaseId;
        public int qReleaseId
        {
            get { return fqReleaseId; }
            set { SetPropertyValue<int>(nameof(qReleaseId), ref fqReleaseId, value); }
        }
        double fvalue;
        public double value
        {
            get { return fvalue; }
            set { SetPropertyValue<double>(nameof(value), ref fvalue, value); }
        }

        int fsortOrder;
        public int sortOrder
        {
            get { return fsortOrder; }
            set { SetPropertyValue<int>(nameof(sortOrder), ref fsortOrder, value); }
        }
        bool fhasNoInput;
        public bool hasNoInput
        {
            get { return fhasNoInput; }
            set { SetPropertyValue<bool>(nameof(hasNoInput), ref fhasNoInput, value); }
        }
        string ftext;
        public string text
        {
            get { return ftext; }
            set { SetPropertyValue<string>(nameof(text), ref ftext, value); }
        }
        string fpicture;
        public string picture
        {
            get { return fpicture; }
            set { SetPropertyValue<string>(nameof(picture), ref fpicture, value); }
        }
        string ftextPrint;
        public string textPrint
        {
            get { return ftextPrint; }
            set { SetPropertyValue<string>(nameof(textPrint), ref ftextPrint, value); }
        }
        string ftextLong;
        public string textLong
        {
            get { return ftextLong; }
            set { SetPropertyValue<string>(nameof(textLong), ref ftextLong, value); }
        }
        string ftextPopup;
        public string textPopup
        {
            get { return ftextPopup; }
            set { SetPropertyValue<string>(nameof(textPopup), ref ftextPopup, value); }
        }
        string ftextMobile;
        public string textMobile
        {
            get { return ftextMobile; }
            set { SetPropertyValue<string>(nameof(textMobile), ref ftextMobile, value); }
        }
    }

    #endregion
}

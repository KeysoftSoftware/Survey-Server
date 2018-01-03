using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KF.Services;
using KF.Primitives;
using KF.Interfaces;
using Survey.Model;

namespace Survey.BL.Services.Persistent
{

    #region Sheelon
    public partial class SheelonService : KF.Services.EntityService<Sheelon>
    {
        public SheelonService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region SheelonRelease
    public partial class SheelonReleaseService : KF.Services.EntityService<SheelonRelease>
    {
        public SheelonReleaseService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region Question
    public partial class QuestionService : KF.Services.EntityService<Question>
    {
        public QuestionService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QText
    public partial class QTextService : KF.Services.EntityService<QText>
    {
        public QTextService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region PageNames
    public partial class PageNamesService : KF.Services.EntityService<PageNames>
    {
        public PageNamesService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region SheelonQuestion
    public partial class SheelonQuestionService : KF.Services.EntityService<SheelonQuestion>
    {
        public SheelonQuestionService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region SheelonFill
    public partial class SheelonFillService : KF.Services.EntityService<SheelonFill>
    {
        public SheelonFillService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region Answer
    public partial class AnswerService : KF.Services.EntityService<Answer>
    {
        public AnswerService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QRelease
    public partial class QReleaseService : KF.Services.EntityService<QRelease>
    {
        public QReleaseService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QType
    public partial class QTypeService : KF.Services.EntityService<QType>
    {
        public QTypeService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region OrgStruct
    public partial class OrgStructService : KF.Services.EntityService<OrgStruct>
    {
        public OrgStructService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QOption
    public partial class QOptionService : KF.Services.EntityService<QOption>
    {
        public QOptionService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QReleaseOpt
    public partial class QReleaseOptService : KF.Services.EntityService<QReleaseOpt>
    {
        public QReleaseOptService(UserSession us) : base(us)
        {
        }
    }
    #endregion

}


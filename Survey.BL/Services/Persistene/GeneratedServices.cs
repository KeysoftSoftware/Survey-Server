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

    #region SRelease
    public partial class SReleaseService : KF.Services.EntityService<SRelease>
    {
        public SReleaseService(UserSession us) : base(us)
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

    #region SQRelease
    public partial class SQReleaseService : KF.Services.EntityService<SQRelease>
    {
        public SQReleaseService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region SFill
    public partial class SFillService : KF.Services.EntityService<SFill>
    {
        public SFillService(UserSession us) : base(us)
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

    #region QReleaseOption
    public partial class QReleaseOptionService : KF.Services.EntityService<QReleaseOption>
    {
        public QReleaseOptionService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region SQHiding
    public partial class SQHidingService : KF.Services.EntityService<SQHiding>
    {
        public SQHidingService(UserSession us) : base(us)
        {
        }
    }
    #endregion

}


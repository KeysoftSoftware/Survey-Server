using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KF.Services;
using KF.Primitives;
using KF.Interfaces;
using Survey.Model;

namespace Survey.BL.Services.Dto
{

    #region Sheelon
    public partial class SheelonDtoService : DynamicFormEntityService<SheelonDto>
    {
        public SheelonDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region SRelease
    public partial class SReleaseDtoService : DynamicFormEntityService<SReleaseDto>
    {
        public SReleaseDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region Question
    public partial class QuestionDtoService : DynamicFormEntityService<QuestionDto>
    {
        public QuestionDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QText
    public partial class QTextDtoService : DynamicFormEntityService<QTextDto>
    {
        public QTextDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region PageNames
    public partial class PageNamesDtoService : DynamicFormEntityService<PageNamesDto>
    {
        public PageNamesDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region SQRelease
    public partial class SQReleaseDtoService : DynamicFormEntityService<SQReleaseDto>
    {
        public SQReleaseDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region SFill
    public partial class SFillDtoService : DynamicFormEntityService<SFillDto>
    {
        public SFillDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QRelease
    public partial class QReleaseDtoService : DynamicFormEntityService<QReleaseDto>
    {
        public QReleaseDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QType
    public partial class QTypeDtoService : DynamicFormEntityService<QTypeDto>
    {
        public QTypeDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region OrgStruct
    public partial class OrgStructDtoService : DynamicFormEntityService<OrgStructDto>
    {
        public OrgStructDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QOption
    public partial class QOptionDtoService : DynamicFormEntityService<QOptionDto>
    {
        public QOptionDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region QReleaseOption
    public partial class QReleaseOptionDtoService : DynamicFormEntityService<QReleaseOptionDto>
    {
        public QReleaseOptionDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region SQHiding
    public partial class SQHidingDtoService : DynamicFormEntityService<SQHidingDto>
    {
        public SQHidingDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

    #region HidingTest
    public partial class HidingTestDtoService : DynamicFormEntityService<HidingTestDto>
    {
        public HidingTestDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

}


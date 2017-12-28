﻿using System;
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

    #region SheelonRelease
    public partial class SheelonReleaseDtoService : DynamicFormEntityService<SheelonReleaseDto>
    {
        public SheelonReleaseDtoService(UserSession us) : base(us)
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

    #region QuestionRelease
    public partial class QuestionReleaseDtoService : DynamicFormEntityService<QuestionReleaseDto>
    {
        public QuestionReleaseDtoService(UserSession us) : base(us)
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

}

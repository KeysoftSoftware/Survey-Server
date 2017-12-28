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

    #region QText
    public partial class QTextDtoService : DynamicFormEntityService<QTextDto>
    {
        public QTextDtoService(UserSession us) : base(us)
        {
        }
    }
    #endregion

}


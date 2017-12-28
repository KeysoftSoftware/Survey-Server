using KF.Services;
using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BL.Services.Dto
{
    class CommonServices
    {
        #region LOV
        public partial class LOVDtoService : DynamicFormEntityService<LOVDto>
        {
            public LOVDtoService(UserSession us) : base(us)
            {
            }
        }
        #endregion

        #region User
        public partial class UserDtoService : DynamicFormEntityService<UserDto>
        {
            public UserDtoService(UserSession us) : base(us)
            {
            }
        }
        #endregion

        #region Relation
        public partial class RelationDtoService : DynamicFormEntityService<RelationDto>
        {
            public RelationDtoService(UserSession us) : base(us)
            {
            }
        }
        #endregion
    }
}

using KF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BL.Services.Grids
{
    public class GridsService : KF.Services.DynamicGridService
    {
        #region GridService
        public GridsService(UserSession userSession)
            : base(userSession, AppSettings.GridLayoutFolder, ServiceUtils.GetTypeByName, ServiceUtils.GetServiceType)
        {
        }
        #endregion

        #region GetGridLayoutCall
        public void GetGridLayoutCall(APICall call)
        {
            var entityName = call.GetParameters<string>("entityName");
            var layoutCode = call.GetParameters<string>("layoutCode");

            var layout = LoadLayout(entityName, call, layoutCode);

            call.callResult.Add("layout", layout);
            call.isSuccess = true;
        }
        #endregion
    }
}

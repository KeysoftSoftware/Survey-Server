using KF.Primitives;
using KF.Services;
using KF.Interfaces;
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


        #region OnAfterLoadLayout
        protected override void OnAfterLoadLayout(string key, GridLayout layout, IAPICall call)
        {
            if (key == "sheelon")
            {
                var ctx = DataManager.GetDBContext();

                //var existCol = layout.columns.Where(s => s.dataField == "Code").FirstOrDefault();
                //if (existCol == null)
                    var dgc = new dataGridColumn("F1");
                    dgc.caption = "F1";
                    //dgc.allowEditing = true;
                    layout.columns.Add(dgc);
            }
            base.OnAfterLoadLayout(key, layout, call);
        }
        #endregion


    }
}

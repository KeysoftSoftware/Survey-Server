using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BL.Services.Persistene
{
    public partial class SheelonService
    {

        #region GetSheelonReleaseByDate
        internal static SRelease GetSheelonReleaseByDate(DataManager.DataContext ctx, int sheelonId, DateTime date)
        {
            return ctx.GetAll<SRelease>().Where(s => s.fromDate >= date && s.toDate <= date).FirstOrDefault();
        } 
        #endregion

    }
}

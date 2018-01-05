using Survey.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace Survey.API.Controllers
{
    public class View_SheelonController : BaseODataController
    {


        // GET: odata/View_Sheelon
        [EnableQuery]
        public IQueryable<View_Sheelon> GetView_Sheelon()
        {
            var us =  base.UserSession;
            if (us.Env.user == null) return null;
            var ctx = BL.DataManager.GetDBContext();
            return ctx.GetAll<View_Sheelon>();
        }

        // GET: odata/View_Employee(5)
        //[EnableQuery]
        //public SingleResult<View_Sheelon> GetView_Sheelon([FromODataUri] int key)
        //{
        //    return SingleResult.Create(db.View_Sheelon.Where(view_Employee => view_Employee.Id == key));
        //}

    }

   
}
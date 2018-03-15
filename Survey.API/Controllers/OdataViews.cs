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
            var us = base.UserSession;
            if (us.Env.user == null) return null;
            var ctx = BL.DataManager.GetDBContext();
            var res = ctx.GetAll<View_Sheelon>();
            return res;
        }
    }


    public class View_HidingController : BaseODataController
    {
        // GET: odata/View_Hiding
        [EnableQuery]
        public IQueryable<View_Sheelon> GetView_Hiding()
        {
            var us = base.UserSession;
            if (us.Env.user == null) return null;
            var ctx = BL.DataManager.GetDBContext();
            //var res = ctx.GetAll<View_Sheelon>();

            //can i use some list?
            //List<View_Sheelon> res = new List<View_Sheelon>();
            //View_Sheelon v = new View_Sheelon(null);
            //v.Id = 1;
            //v.name = "test name";
            //res.Add(v);
            //return res.AsQueryable();

            // string str = "EXEC GetRList_ '" + Env.userToken + "','" + JsonConvert.SerializeObject(settings) + "'";
            string str = "SELECT * FROM hidingTest";
            try
            {
                var result = ctx.ExecuteQuery<View_Sheelon>(str);
                //var ddd = ctx.ExecuteQuery<t_questionnarie>(str).First();
                return result;
                //_UserSession.Response.data.Add(Constants.ResponseDataKeys.LIST, result.ToList());
            }
            catch (Exception e)
            {
                //FL.Error(e);
                return null;
            }





        }
    }


    public class View_QuestionController : BaseODataController
    {
        [EnableQuery]
        public IQueryable<View_Question> GetView_Question()
        {

            var us = base.UserSession;
            if (us.Env.user == null) return null;
            var ctx = BL.DataManager.GetDBContext();
            var res =  ctx.GetAll<View_Question>();
            return res;
        }
    }
}
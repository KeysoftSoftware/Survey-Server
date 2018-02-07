using System.Linq;
using System.Web.Http.OData;
using System.Web.Http;
using Survey.API.Controllers;
using static Survey.Model.Combos;
using Survey.Model;

namespace RT.API.Controllers
{
    #region TBankController
    public class TDsController : BaseODataController
    {
        [EnableQuery]
        public IQueryable<TDs> GetTDs()
        {
            var us = UserSession;
            if (us.Env.user == null) return null;
            var ctx = Survey.BL.DataManager.GetDBContext();
            var query = from obj in ctx.GetAll<LOV>()
                        where obj.IsActive && obj.parentTypeCode == "QCAT"
                        select new TDs()
                        {
                            Id = obj.Id,
                            name = obj.name
                        };
            var tt = query.ToList();
            return query;
        }

        [EnableQuery]
        public SingleResult<TDs> GetTDs([FromODataUri] int key)
        {
            var us = UserSession;
            if (us.Env.user == null) return null;
            var ctx = Survey.BL.DataManager.GetDBContext();
            var query = (from obj in ctx.GetAll<LOV>()
                         where obj.Id == key
                         select new TDs()
                         {
                             Id = obj.Id,
                             name = obj.name
                         });
            return SingleResult.Create(query);
        }
    }
    #endregion

}
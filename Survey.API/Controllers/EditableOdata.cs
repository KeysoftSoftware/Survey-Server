using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace Survey.API.Controllers
{
    #region LOVDtoController 
    public class LOVDtoController : BaseEditODataControler<LOVDto, LOV>
    {
        // GET: odata/TLOVParents
        [EnableQuery]
        public IQueryable<LOVDto> GetLOVDto()
        {
            var us = UserSession;
            var q = from obj in db.GetAll<LOV>()
                    select new LOVDto()
                    {
                        Id = obj.Id,
                        Code = obj.Code,
                        name = obj.name,
                        parentId = obj.parentId != 0 ? obj.parentId : 0,
                        companyId = obj.companyId,
                        isSystem = obj.isSystem
                    };

            var a = q.ToList();
            return q;
        }

        // GET: odata/LOVDto
        [EnableQuery]
        public LOVDto GetLOVDto([FromODataUri] int key)
        {
            var obj = GetById(key);
            return obj;
        }

        // POST: odata/LOVDto
        public IHttpActionResult Post(LOVDto lovParentDto)
        {
            return doPost(lovParentDto);
        }

        // PATCH: odata/LOVDto
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<LOVDto> patch)
        {
            return await Task.FromResult(doPatch(key, patch));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
    #endregion
}
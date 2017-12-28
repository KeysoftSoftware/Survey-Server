using KF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;
//using RT.BL.Activation;
using Survey.Model;
using KF.Primitives.NonPersistent;
using Survey.BL.Routing;
using Survey.BL.Services;
using Survey.BL.Services.Forms;
using Survey.BL.Services.Persistent;
using KF.Primitives;
using Survey.API.Controllers;

namespace Survey.API.Controllers
{
    public class BaseEditODataControler<T, TSource> : BaseODataController where T : TBaseEntity<TSource> where TSource : IBaseEntity
    {
        protected Survey.BL.DataManager.DataContext db = Survey.BL.DataManager.GetDBContext();

        //public IQueryable<T> getAll()
        //{
        //    var q = db.GetAll<TSource>();
        //    var col = new List<T>();
        //    foreach(var item in q)
        //    {
        //        var tItem = default(T);
        //        tItem.From(item);
        //        col.Add(tItem);
        //    }

        //    return col.AsQueryable();
        //}

        public T GetById(int id)
        {
            var entity = db.GetById<TSource>(id);

            T tEntity = Activator.CreateInstance<T>();
            tEntity.From(entity);
            return tEntity;
        }

        public IHttpActionResult doPost(T tEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            ActivateSave(tEntity);

            return Created(tEntity);
        }

        public IHttpActionResult doPatch(int key, Delta<T> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = db.GetById<TSource>(key);

            if (entity == null)
            {
                return NotFound();
            }

            T tEntity = Activator.CreateInstance<T>();
            patch.Patch(tEntity);

            var propNames = patch.GetChangedPropertyNames();

            var t = typeof(TSource);
            var tSrc = typeof(T);

            foreach (var fld in propNames)
            {
                var prop = t.GetProperty(fld);
                if (prop == null) continue;
                var propSrc = tSrc.GetProperty(fld);
                if (propSrc == null) continue;
                var value = propSrc.GetValue(tEntity);
                prop.SetValue(entity, value);
            }

            //tEntity.Id = key;

            var call = UpdateEntity(entity);
            if (!call.isSuccess)
            {
                //Content - Type: text / html; charset = utf - 8
                var content = new StringContent(call.msgs.toInlineText(), System.Text.Encoding.UTF32);
               // content.Headers.Add("Content-Type", "text/html");

                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = content,
                    ReasonPhrase = call.msgs.toInlineText()
                };
                throw new HttpResponseException(resp);
            }

            return Updated(tEntity);
        }

        protected KF.Services.APICall UpdateEntity(TSource entity)
        {
            var apiReq = new KF.Services.ApiRequest();
            apiReq.recivedStamp = DateTime.Now;

            var us = UserSession;
            var call = new KF.Services.APICall();
            apiReq.calls.Add(call);

            UserSession.Request = apiReq;

            RouteService.SaveFormDataInternal(UserSession, call, entity);
            return call;
        }
        protected void ActivateSave(T tEntity)
        {
            var apiReq = new KF.Services.ApiRequest();
            apiReq.recivedStamp = DateTime.Now;

            var us = UserSession;
            var call = new KF.Services.APICall();
            apiReq.calls.Add(call);

            UserSession.Request = apiReq;

            var srv = us.GetService<UserService>();
            var data = srv.GetEntityData(tEntity);

            var typeName = tEntity.GetType().Name;
            var inParams = new OnSaveParams() { entityName = typeName, id = 0, layoutCode = typeName, formData = data };

            var frmSrv = new FormsService(us);
            frmSrv.OnSaveData(inParams, call);

            //var session = us.DataContext.GetContext();
            //var prms = new object[] { session };
            //TSource entity = (TSource)Activator.CreateInstance(typeof(TSource),prms);
            //tEntity.To(entity);

            //RouteService.SaveFormDataInternal(UserSession, call, entity);
        }

    }
}
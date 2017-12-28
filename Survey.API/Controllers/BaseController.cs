using KF.Interfaces;
using KF.Primitives;
using KF.Services;
using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Survey.API.Controllers
{
    public class BaseController : ApiController
    {

        #region ResolveHeaders - API
        public static UserEnv ResolveHeaders(HttpRequestHeaders headers)
        {
            UserEnv result = new UserEnv();

            //result.IsAppAuthenticated = IsAppAuthenticated(headers);
            result.langCode = GetHeaderValue(headers, "currentlang");
            result.userToken = GetHeaderValue(headers, "Authorization");
            result.customerName = GetHeaderValue(headers, "company");

            if (!string.IsNullOrEmpty(result.userToken)) result.user = BL.Services.Auth.AuthService.GetUserFromToken(result.userToken);

            return result;
        }
        #endregion

        #region GetHeaderValue - API
        internal static string GetHeaderValue(HttpRequestHeaders headers, string key)
        {
            if (!headers.Contains(key)) return string.Empty;

            IEnumerable<string> headerValues = headers.GetValues(key);
            string value = headerValues.FirstOrDefault();

            return value;
        }
        #endregion

        #region UserSession
        private UserSession _UserSession;
        protected UserSession UserSession
        {
            get
            {
                if (_UserSession != null) return _UserSession;
                _UserSession = new UserSession(BL.DataManager.GetDBContext(), getUserEnvFromHeaders());
                return _UserSession;
            }
        }
        #endregion

        private string GetSiteId()
        {
            return string.Format("http://{0}/", Request.Headers.Referrer.Authority);
        }

        //#region SiteManager
        //protected Keyframe.Services.MultiSiteHandler SiteManager
        //{
        //    get { return WebApiApplication.SiteManager; }
        //}
        //#endregion

        #region getUserEnvFromHeaders
        private UserEnv getUserEnvFromHeaders(bool authenticate = true)
        {

            var userenv = ResolveHeaders(Request.Headers);
            if (string.IsNullOrEmpty(userenv.langCode)) userenv.langCode = "he";

            return userenv;
        }
        #endregion

        //#region GetSiteConfigFromRequest
        //private SiteConfig GetSiteConfigFromRequest()
        //{
        //    var siteId = string.Format("http://{0}/", Request.Headers.Referrer.Authority);

        //    var siteconfig = new SiteConfig();
        //    siteconfig.siteId = siteId;

        //    return siteconfig;
        //}
        //#endregion
    }
}

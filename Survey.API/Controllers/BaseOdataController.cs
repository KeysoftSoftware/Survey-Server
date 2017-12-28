using KF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http.OData;
using Survey.Model;
using Survey.Model.Query;

namespace Survey.API.Controllers
{
    public class BaseODataController : ODataController
    {

        protected SurveyDBEntities db = new SurveyDBEntities();

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

        #region getUserEnvFromHeaders
        private UserEnv getUserEnvFromHeaders(bool authenticate = true)
        {

            var userenv = ResolveHeaders(Request.Headers);
            if (string.IsNullOrEmpty(userenv.langCode)) userenv.langCode = "he";

            return userenv;
        }
        #endregion

        #region ResolveHeaders - API
        public UserEnv ResolveHeaders(HttpRequestHeaders headers)
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
        internal string GetHeaderValue(HttpRequestHeaders headers, string key)
        {
            if (!headers.Contains(key)) return string.Empty;

            IEnumerable<string> headerValues = headers.GetValues(key);
            string value = headerValues.FirstOrDefault();

            return value;
        }
        #endregion
    }
}
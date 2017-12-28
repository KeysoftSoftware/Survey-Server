using KF.Primitives;
using KF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using ZETT.BL.Activation;
using Unclassified.FieldLog;

using System.Collections;
using Survey.BL.Routing;

namespace Survey.API.Controllers
{
    public class CommonController : BaseController
    {
        #region ProcessCall
        [HttpPost]
        [Route("api/servicecall")]
        public object ProcessCall([FromBody] object data)
        {
            try
            {
                if (data == null)
                {
                    return new ApiResponse() { isSuccess = false };
                }

                UserSession.SetRequest(data.ToString());
                RouteService.ProcessRoute(UserSession);

                 return UserSession.Request;
            }
            catch (Exception e)
            {
                FL.Error(e);
                return new ApiResponse() { isSuccess = false };
            }
        }
        #endregion
  
    }
}

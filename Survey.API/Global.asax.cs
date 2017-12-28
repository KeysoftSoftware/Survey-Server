using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unclassified.FieldLog;

namespace Survey.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Force JSON responses on all requests
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());

            BL.Routing.RouteService.Create();
            //Api.Controllers.CommonController.BuildActivationMap();

            BL.AppSettings.LayoutFolder = Server.MapPath("Layouts");


            var settings = Survey.API.Properties.Settings.Default;
            BL.AppSettings.DataContextConnectionSettings = new BL.ConnectionSettings() { DataSource = settings.server, InitialCatalog = settings.db };

            FL.AcceptLogFileBasePath();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            CorsSupport.HandlePreflightRequest(HttpContext.Current);
        }
    }
}

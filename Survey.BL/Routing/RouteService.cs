using KF.Interfaces;
using KF.Services;
using Survey.BL.Services;
using Survey.BL.Services.Auth;
using Survey.BL.Services.Dto;
using Survey.BL.Services.Forms;
using Survey.BL.Services.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BL.Routing
{
    public class RouteService
    {
        private static Dictionary<string, Action<UserSession, APICall>> _RouteMap;

        //public const string RTDomain = "RTDomain";
        //public const string CustomerDomain = "CustomerDomain";
        //public const string EmployeeDomain = "EmployeeDomain";


        private RouteService()
        {

        }

        #region ProcessRoute
        public static void ProcessRoute(UserSession userSession)
        {
            foreach (var call in userSession.Request.calls)
            {
                var callAction = _RouteMap[call.methodName];

                if (callAction != null) callAction.Invoke(userSession, call);
            }

            var err = userSession.Request.calls.Where(s => s.isSuccess == false).Any();
            //userSession.Response.isSuccess = !err;//.calls = userSession.Request.calls;
        }
        #endregion


        #region AddRoute
        private void AddRoute(string callCode, Action<UserSession, APICall> method)
        {
            if (_RouteMap == null) _RouteMap = new Dictionary<string, Action<UserSession, APICall>>();
            if (_RouteMap.ContainsKey(callCode)) return;
            _RouteMap.Add(callCode, method);
        }
        #endregion

        #region Create
        public static void Create()
        {
            var srv = new RouteService();
            srv.AddRoute("runServiceFunction", RunServiceFunction);
            srv.AddRoute("login", LoginCall);
            srv.AddRoute("logout", LogoutCall);

            srv.AddRoute("getForm", GetForm);
            srv.AddRoute("validateField", ValidateField);
            srv.AddRoute("onPropertyChanged", OnPropertyChanged);
            srv.AddRoute("getGridLayout", GetGridLayout);

            srv.AddRoute("getFormLayout", GetFormLayout);
            srv.AddRoute("getEntityData", GetEntityData);
            srv.AddRoute("saveFormData", SaveFormData);

        }
        #endregion

        public static void RunServiceFunction(UserSession UserSession, APICall call)
        {
            var entityName = call.GetParameters<string>("entityName");
            var methodName = call.GetParameters<string>("methodName");

            var entityTypeName = ServiceUtils.GetEntityTypeName(entityName);
            Type type = ServiceUtils.GetTypeByName(entityTypeName);
            MethodInfo method = typeof(ServiceUtils).GetMethod("OnActivate");
            MethodInfo genericMethod = method.MakeGenericMethod(type);
            genericMethod.Invoke(new RouteService(), new object[] { UserSession, call, methodName});
        }

        public void OnActivate<T>(UserSession UserSession, APICall call, string methodName)
                where T : IBaseEntity
        {

            var serviceType = ServiceUtils.GetServiceType(typeof(T));
            var service = UserSession.GetServiceByType(serviceType);

            var mi = serviceType.GetMethod(methodName);
            if (mi != null)
            {
                object[] prm = new object[] { call };
                mi.Invoke(service, prm);
            }
        }


        #region Calls

        #region OnPropertyChanged
        public static void OnPropertyChanged(UserSession userSession, APICall call)
        {
            var service = new FormsService(userSession);
            service.OnPropertyChangedCall(call);
        }
        #endregion

        #region ValidateField
        public static void ValidateField(UserSession userSession, APICall call)
        {
            var service = new FormsService(userSession);
            service.ValidateFieldCall(call);
        }
        #endregion

        #region GetForm
        public static void GetForm(UserSession userSession, APICall call)
        {
            var service = new FormsService(userSession);
            service.GetFormCall(call);
        }
        #endregion

        #region GetFormLayout
        public static void GetFormLayout(UserSession userSession, APICall call)
        {
            var service = new FormsService(userSession);
            service.GetFormLayoutCall(call);
        }
        #endregion

        #region GetEntityData
        public static void GetEntityData(UserSession userSession, APICall call)
        {
            var service = new FormsService(userSession);
            service.GetEntityDataCall(call);
        }
        #endregion

        #region SaveFormData
        public static void SaveFormData(UserSession userSession, APICall call)
        {
            var service = new FormsService(userSession);
            service.SaveFormDataCall(call);
        }
        #endregion


        #region SaveFormDataInternal
        public static void SaveFormDataInternal<T>(UserSession userSession, APICall call, T entity) where T : IBaseEntity
        {
            var type = typeof(T);
            var srvType = ServiceUtils.GetServiceType(type);
            var srv = userSession.GetServiceByType(srvType);
            var data = srv.GetEntityData(entity);

            var service = new FormsService(userSession);
            service.SaveFormDataInternalCall(call, type, data, entity);
        }
        #endregion

        #region GetGridLayout
        public static void GetGridLayout(UserSession userSession, APICall call)
        {
            var service = new GridsService(userSession);
            service.GetGridLayoutCall(call);
        }
        #endregion

        #region LoginCall
        public static void LoginCall(UserSession userSession, APICall call)
        {
            var service = new AuthService(userSession);
            service.LoginCall(call);
        }
        #endregion

        #region LogoutCall
        public static void LogoutCall(UserSession userSession, APICall call)
        {
            var service = new AuthService(userSession);
            service.LoginCall(call);
        }
        #endregion



        #endregion
    }
}

using KF.Interfaces;
using KF.Primitives;
using KF.Services;
using KF.Utils;
using System;
using System.Collections.Generic;

namespace Survey.BL.Services.Forms
{
    public class FormsService : DynamicFormService
    {
        #region FormsService
        public FormsService(UserSession userSession)
            : base(userSession, AppSettings.FormLayoutFolder, ServiceUtils.GetTypeByName, ServiceUtils.GetServiceType)
        {
#if DEBUG 
            DoNoUseCaching = true;

#endif
        }
        #endregion

        #region GetForm
        public void GetFormCall(APICall call)
        {
            var entityName = call.GetParameters<string>("entityName");
            var layoutCode = call.GetParameters<string>("layoutCode");
            if (string.IsNullOrEmpty(layoutCode)) layoutCode = entityName;
            var id = call.GetParameters<Int64>("id");

            var layout = LoadLayout(entityName, call);
            var data = GetData(call, layoutCode, entityName, (int)id);

            call.callResult.Add("formLayout", layout);
            call.callResult.Add("formData", data);

            call.isSuccess = true;

        }
        #endregion

        #region GetEntityDataCall
        public void GetEntityDataCall(APICall call)
        {
            var entityName = call.GetParameters<string>("entityName");
            var layoutCode = call.GetParameters<string>("layoutCode");
            var id = call.GetParameters<Int64>("id");

            var res = GetData(call, layoutCode, entityName, (int)id);
            call.callResult.Add("formData", res);
            call.isSuccess = true;

        }
        #endregion

        #region ValidateFieldCall
        public void ValidateFieldCall(APICall call)
        {
            var entityName = call.GetParameters<string>("entityName");
            var layoutCode = call.GetParameters<string>("layoutCode");
            var id = call.GetParameters<Int64>("id");
            var fieldName = call.GetParameters<string>("fieldName");
            var newValue = call.GetParameters<object>("newValue");
            var dataObj = call.GetParameters<object>("data");
            var data = JsonUtils.Parse<Dictionary<string, object>>(dataObj.ToString());

            var inParams = new OnPropertyChangedParams() { entityName = entityName, fieldName = fieldName, id = (int)id, layoutCode = layoutCode, newValue = newValue, formData = data };
            ValidateField(inParams, call);
        }
        #endregion

        #region OnPropertyChangedCall
        internal void OnPropertyChangedCall(APICall call)
        {
            var entityName = call.GetParameters<string>("entityName");
            var layoutCode = call.GetParameters<string>("layoutCode");
            var id = call.GetParameters<Int64>("id");
            var fieldName = call.GetParameters<string>("fieldName");
            var newValue = call.GetParameters<object>("newValue");
            var dataObj = call.GetParameters<object>("data");
            var data = JsonUtils.Parse<Dictionary<string, object>>(dataObj.ToString());

            var inParams = new OnPropertyChangedParams() { entityName = entityName, fieldName = fieldName, id = (int)id, layoutCode = layoutCode, newValue = newValue, formData = data };

            OnPropertyChanged(inParams, call);
        }
        #endregion

        #region SaveFormDataCall
        public void SaveFormDataCall(APICall call)
        {
            var entityName = call.GetParameters<string>("entityName");
            var layoutCode = call.GetParameters<string>("layoutCode");
            var id = call.GetParameters<Int64>("id");
            var dataObj = call.GetParameters<object>("data");
            var data = JsonUtils.Parse<Dictionary<string, object>>(dataObj.ToString());

            var inParams = new OnSaveParams() { entityName = entityName, id = (int)id, layoutCode = layoutCode, formData = data };
            OnSaveData(inParams, call);
        }
        #endregion

        #region GetFormLayoutCall
        public void GetFormLayoutCall(APICall call)
        {
            var entityName = call.GetParameters<string>("entityName");
            var layoutCode = call.GetParameters<string>("layoutCode");
            if (string.IsNullOrEmpty(layoutCode)) layoutCode = entityName;

            var layout = LoadLayout(entityName, call);

            call.callResult.Add("formLayout", layout);
            call.isSuccess = true;

        }
        #endregion


        #region SaveFormDataInternalCall
        public void SaveFormDataInternalCall(APICall call, Type type,Dictionary<string,object> data, IBaseEntity entity)
        {
            var inParams = new OnSaveParams() { entityName = type.Name, id = entity.Id, layoutCode = type.Name, formData = data };
            OnSaveData(inParams, call);
        }
        #endregion

    }

}

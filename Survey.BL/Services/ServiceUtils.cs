using KF.Primitives;
using System;
using System.Linq;
using System.Reflection;

namespace Survey.BL.Services
{
    public static class ServiceUtils
    {
        #region GetEntityTypeName
        public static string GetEntityTypeName(string entityName)
        {
            return entityName;
        } 
        #endregion

        #region GetTypeByName
        internal static Type GetTypeByName(string typeName)
        {
            Type t = null;

            try
            {
                typeName = typeName.ToLower();
                var asm = Assembly.GetAssembly(typeof(Model.User));
                t = asm.DefinedTypes.Where(s => s.Name.ToLower() == typeName).FirstOrDefault();
                //t = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(x => Assembly.Load(x)).SelectMany(x => x.GetTypes()).First(x => x.FullName.ToUpper() == typeName.ToUpper());
            }
            catch (Exception)
            {

            }
            return t;
        }
        #endregion

        #region GetServiceType
        internal static Type GetServiceType(Type entityType)
        {
            var typeName = GetServiceName(entityType);

            Type serviceType = Type.GetType(typeName, false, true);
            return serviceType;
        }
        #endregion

        #region GetServiceName
        internal static string GetServiceName(Type entityType)
        {
            var nonPersistClass = entityType.GetCustomAttribute<NonPersistAttribute>(false);
            if (nonPersistClass != null) return string.Format("Survey.BL.Services.Dto.{0}Service", entityType.Name);
            return string.Format("Survey.BL.Services.Persistent.{0}Service", entityType.Name);
        }
        #endregion

    }
}

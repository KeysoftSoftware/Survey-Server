using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KF.Primitives.NonPersistent;
using Survey.Model;

namespace Survey.Model
{

    #region LOV
    [KF.Primitives.NonPersist]
    public partial class LOVDto : TBaseEntity<LOV>
    {

        #region Fields
        public static class Fields
        {
            public static string name = "name";
            public static string sortOrder = "sortOrder";
            public static string companyId = "companyId";
            public static string parentTypeCode = "parentTypeCode";
            public static string parentId = "parentId";
            public static string logicalParentId = "logicalParentId";
            public static string comment = "comment";
            public static string isSystem = "isSystem";
            public static string oldId = "oldId";
        }
        #endregion

        #region Properties

        public string name { get; set; }
        public int sortOrder { get; set; }
        public int companyId { get; set; }
        public string parentTypeCode { get; set; }
        public int parentId { get; set; }
        public int logicalParentId { get; set; }
        public string comment { get; set; }
        public bool isSystem { get; set; }
        public string oldId { get; set; }
        #endregion

    }

    #endregion LOV

    #region User
    [KF.Primitives.NonPersist]
    public partial class UserDto : TBaseEntity<User>
    {

        #region Fields
        public static class Fields
        {
            public static string userId = "userId";
            public static string password = "password";
            public static string salt = "salt";
            public static string accessToken = "accessToken";
            public static string displayName = "displayName";
            public static string role = "role";
            public static string lastLogin = "lastLogin";
        }
        #endregion

        #region Properties

        public string userId { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string accessToken { get; set; }
        public string displayName { get; set; }
        public string role { get; set; }
        public DateTime lastLogin { get; set; }
        #endregion

    }

    #endregion User

    #region Relation
    [KF.Primitives.NonPersist]
    public partial class RelationDto : TBaseEntity<Relation>
    {

        #region Fields
        public static class Fields
        {
            public static string relationTypeCode = "relationTypeCode";
            public static string sourceType = "sourceType";
            public static string sourceId = "sourceId";
            public static string targetType = "targetType";
            public static string targetId = "targetId";
        }
        #endregion

        #region Properties

        public string relationTypeCode { get; set; }
        public string sourceType { get; set; }
        public int sourceId { get; set; }
        public string targetType { get; set; }
        public int targetId { get; set; }
        #endregion

    }

    #endregion Relation

}


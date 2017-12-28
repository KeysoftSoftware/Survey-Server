using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KF.Primitives;
using KF.Interfaces;
using DevExpress.Xpo;


namespace Survey.Model
{

    #region LOV
    public partial class LOV : ModelBase
    {

        #region Constructor
        public LOV(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region name
        private string _name;
        public string name
        {
            get { return _name; }
            set { SetValue<string>("name", ref _name, value); }
        }
        #endregion

        #region sortOrder
        private int _sortOrder;
        public int sortOrder
        {
            get { return _sortOrder; }
            set { SetValue<int>("sortOrder", ref _sortOrder, value); }
        }
        #endregion

        #region companyId
        private int _companyId;
        public int companyId
        {
            get { return _companyId; }
            set { SetValue<int>("companyId", ref _companyId, value); }
        }
        #endregion

        #region parentTypeCode
        private string _parentTypeCode;
        public string parentTypeCode
        {
            get { return _parentTypeCode; }
            set { SetValue<string>("parentTypeCode", ref _parentTypeCode, value); }
        }
        #endregion

        #region parentId
        private int _parentId;
        public int parentId
        {
            get { return _parentId; }
            set { SetValue<int>("parentId", ref _parentId, value); }
        }
        #endregion

        #region logicalParentId
        private int _logicalParentId;
        public int logicalParentId
        {
            get { return _logicalParentId; }
            set { SetValue<int>("logicalParentId", ref _logicalParentId, value); }
        }
        #endregion

        #region comment
        private string _comment;
        public string comment
        {
            get { return _comment; }
            set { SetValue<string>("comment", ref _comment, value); }
        }
        #endregion

        #region isSystem
        private bool _isSystem;
        public bool isSystem
        {
            get { return _isSystem; }
            set { SetValue<bool>("isSystem", ref _isSystem, value); }
        }
        #endregion

        #region oldId
        private string _oldId;
        public string oldId
        {
            get { return _oldId; }
            set { SetValue<string>("oldId", ref _oldId, value); }
        }
        #endregion

        #endregion

    }

    #endregion LOV

    #region User
    public partial class User : ModelBase
    {

        #region Constructor
        public User(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region userId
        private string _userId;
        public string userId
        {
            get { return _userId; }
            set { SetValue<string>("userId", ref _userId, value); }
        }
        #endregion

        #region password
        private string _password;
        public string password
        {
            get { return _password; }
            set { SetValue<string>("password", ref _password, value); }
        }
        #endregion

        #region salt
        private string _salt;
        public string salt
        {
            get { return _salt; }
            set { SetValue<string>("salt", ref _salt, value); }
        }
        #endregion

        #region accessToken
        private string _accessToken;
        public string accessToken
        {
            get { return _accessToken; }
            set { SetValue<string>("accessToken", ref _accessToken, value); }
        }
        #endregion

        #region displayName
        private string _displayName;
        public string displayName
        {
            get { return _displayName; }
            set { SetValue<string>("displayName", ref _displayName, value); }
        }
        #endregion

        #region role
        private string _role;
        public string role
        {
            get { return _role; }
            set { SetValue<string>("role", ref _role, value); }
        }
        #endregion

        #region lastLogin
        private DateTime _lastLogin;
        public DateTime lastLogin
        {
            get { return _lastLogin; }
            set { SetValue<DateTime>("lastLogin", ref _lastLogin, value); }
        }
        #endregion

        #endregion

    }

    #endregion User

    #region Relation
    public partial class Relation : ModelBase
    {

        #region Constructor
        public Relation(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region relationTypeCode
        private string _relationTypeCode;
        public string relationTypeCode
        {
            get { return _relationTypeCode; }
            set { SetValue<string>("relationTypeCode", ref _relationTypeCode, value); }
        }
        #endregion

        #region sourceType
        private string _sourceType;
        public string sourceType
        {
            get { return _sourceType; }
            set { SetValue<string>("sourceType", ref _sourceType, value); }
        }
        #endregion

        #region sourceId
        private int _sourceId;
        public int sourceId
        {
            get { return _sourceId; }
            set { SetValue<int>("sourceId", ref _sourceId, value); }
        }
        #endregion

        #region targetType
        private string _targetType;
        public string targetType
        {
            get { return _targetType; }
            set { SetValue<string>("targetType", ref _targetType, value); }
        }
        #endregion

        #region targetId
        private int _targetId;
        public int targetId
        {
            get { return _targetId; }
            set { SetValue<int>("targetId", ref _targetId, value); }
        }
        #endregion

        #endregion

    }

    #endregion Relation

    #region DefaultValues
    public partial class DefaultValues : ModelBase
    {

        #region Constructor
        public DefaultValues(Session prmSession) : base(prmSession)
        {
        }
        #endregion

        #region Properties

        #region fieldName
        private string _fieldName;
        public string fieldName
        {
            get { return _fieldName; }
            set { SetValue<string>("fieldName", ref _fieldName, value); }
        }
        #endregion

        #region entityType
        private string _entityType;
        public string entityType
        {
            get { return _entityType; }
            set { SetValue<string>("entityType", ref _entityType, value); }
        }
        #endregion

        #region sourceTableName
        private string _sourceTableName;
        public string sourceTableName
        {
            get { return _sourceTableName; }
            set { SetValue<string>("sourceTableName", ref _sourceTableName, value); }
        }
        #endregion

        #region sourceId
        private int _sourceId;
        public int sourceId
        {
            get { return _sourceId; }
            set { SetValue<int>("sourceId", ref _sourceId, value); }
        }
        #endregion

        #region sourceCode
        private string _sourceCode;
        public string sourceCode
        {
            get { return _sourceCode; }
            set { SetValue<string>("sourceCode", ref _sourceCode, value); }
        }
        #endregion

        #endregion

    }

    #endregion DefaultValues

}


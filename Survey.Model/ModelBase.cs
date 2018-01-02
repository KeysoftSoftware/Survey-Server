using DevExpress.Xpo;
using KF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model
{

    #region ModelBase
    [NonPersistent]
    public class ModelBase : DevExpress.Xpo.XPBaseObject, IBaseEntity
    {
        public ModelBase()
        {
            IsActive = true;
        }
        public ModelBase(Session prmSession)
           : base(prmSession)
        {
            IsActive = true;
        }
        public ModelBase(UnitOfWork prmSession)
            : base(prmSession)
        {
            IsActive = true;
        }



        protected virtual void SetValue<T>(string prmPropertyName, ref T prmVariable, T prmNewValue)
        {
            SetPropertyValue<T>(prmPropertyName, ref prmVariable, prmNewValue);
        }

        public bool IsNonPersistent()
        {
            return false;
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            IsActive = true;

        }


        #region Id
        protected int _Id;
        [Key(AutoGenerate = true)]
        public int Id
        {
            get { return _Id; }
            set { SetValue("Id", ref _Id, value); }
        }
        #endregion Id

        #region Code
        protected string _Code;
        public string Code
        {
            get { return _Code; }
            set { SetValue("Code", ref _Code, value); }
        }
        #endregion Code

        #region IsActive
        protected bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set { SetValue("IsActive", ref _IsActive, value); }
        }
        #endregion IsActive

        #region IsDeleted
        protected bool _IsDeleted;
        public bool IsDeleted
        {
            get { return _IsDeleted; }
            set { SetValue("IsDeleted", ref _IsDeleted, value); }
        }
        #endregion IsDeleted

        #region CreatedBy
        protected string _CreatedBy;
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { SetValue("CreatedBy", ref _CreatedBy, value); }
        }
        #endregion CreatedBy

        #region CreatedOn
        protected DateTime _CreatedOn;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { SetValue("CreatedOn", ref _CreatedOn, value); }
        }
        #endregion CreatedOn

        #region LastUpdateBy
        protected string _LastUpdateBy;
        public string LastUpdateBy
        {
            get { return _LastUpdateBy; }
            set { SetValue("LastUpdateBy", ref _LastUpdateBy, value); }
        }
        #endregion LastUpdateBy

        #region Version
        protected DateTime _Version;
        public DateTime Version
        {
            get { return _Version; }
            set { SetValue("Version", ref _Version, value); }
        }
        #endregion Version

    }
    #endregion
}

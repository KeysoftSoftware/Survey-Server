using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using KF.Interfaces;
using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BL
{
    public class DataManager
    {
        private static XPDictionary _XPDictionary;

        public static void InitDAL()
        {
            string server = AppSettings.DataContextConnectionSettings.DataSource;
            string db = AppSettings.DataContextConnectionSettings.InitialCatalog;
            //string userid = UserID;//
            //string pw = PW;// RDXPBL.Properties.Settings.Default.PW;

            string conn = DevExpress.Xpo.DB.MSSqlConnectionProvider.GetConnectionString(server,db);
            _XPDictionary = new ReflectionDictionary();

            DevExpress.Xpo.DB.IDataStore store = DevExpress.Xpo.XpoDefault.GetConnectionProvider(conn, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);

            // initialize the XPO dictionary
            _XPDictionary.GetDataStoreSchema(typeof(Model.User).Assembly);

            // create a ThreadSafeDataLayer and store it in the XpoDefault.DataLayer static property
            DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.ThreadSafeDataLayer(_XPDictionary, store);

            // set XpoDefault.Session to null to prevent accidental use of XPO default session
            DevExpress.Xpo.XpoDefault.Session = null;


        }

        public static DataContext GetDBContext()
        {
            return new DataContext();
        }

        #region NewUnitOfWork
        public static UnitOfWork NewUnitOfWork
        {
            get
            {
                if (_XPDictionary == null) InitDAL();
                UnitOfWork u = new UnitOfWork(_XPDictionary);
                return u;
            }
        }
        #endregion NewUnitOfWork

        public class DataContext : IDataContext, IDisposable
        {
            UnitOfWork _session;
            public DataContext()
            {
                _session = NewUnitOfWork;
            }

            public IQueryable<T> GetAll<T>()
            {
                XPQuery<T> objs = _session.Query<T>();
                return objs;
            }

            public T GetById<T>(int id) where T : IBaseEntity
            {
                var obj = _session.GetObjectByKey<T>(id);
                return obj;
                //return GetAll<T>().Where(s => s.Id == id).FirstOrDefault();
            }

            #region GetByCode<T>
            public T GetByCode<T>(string code) where T : IBaseEntity
            {
                XPQuery<T> objs = _session.Query<T>();
                return objs.Where(s => s.Code == code).FirstOrDefault();
                //return GetAll<T>().Where(s => s.Code == code).FirstOrDefault();
            }
            #endregion

            public LOV GetLovByCode(string parentTypeCode, string code)
            {
                XPQuery<LOV> objs = _session.Query<LOV>();
                return objs.Where(s => s.parentTypeCode == parentTypeCode && s.Code == code).FirstOrDefault();
            }


            public object GetContext()
            {
                return this._session;
            }

            #region Save<T>
            public T Save<T>(T entity)
            {
                //                this.Add(entity);
                //_session.Save(entity);
                return entity;
            }
            #endregion

            public void Flush()
            {
                _session.FlushChanges();
            }

            public void RollBack()
            {
                _session.RollbackTransaction();
            }

            #region SaveChanges
            public IReportedMsgs SaveChanges()
            {
                var msgs = new KF.Primitives.ReportedMsgs();

                try
                {
                    _session.CommitChanges();
                }
                catch (Exception e)
                {
                    msgs.AddError(e.Message);
                }

                return msgs;
            }
            #endregion

            public void Delete<T>(object id)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                if (_session != null) _session.Dispose();
            }
        }

    }
}

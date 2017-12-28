using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KF.Services;
using Survey.Model;
using KF.Interfaces;

namespace Survey.BL.Services.Persistent
{
    public class LOVService : KF.Services.EntityService<LOV>
    {
        public LOVService(UserSession session) : base(session)
        {
        }

        #region AddLov
        public LOV AddLov(string code, string name, LOV parent = null, int logicalParentId = 0, int sortOrder = 0)
        {
            var ctx = _UserSession.DataContext as DataManager.DataContext;

            if (parent == null)
            {
                parent = ctx.GetByCode<LOV>(code);
                if (parent == null)
                {
                    parent = CreateInternal();
                    parent.Code = code;
                    parent.name = name;
                    parent = SaveInternal(parent, Msgs);
                    parent.companyId = 0;

                    if (Msgs.hasAnyError)
                    {

                    }

                    // to use the parent in child adding
                    _UserSession.SaveChanges();
                }

                return parent;

            }
            else
            {
                var child = ctx.GetAll<LOV>().Where(s => s.parentId == parent.Id && s.Code == code).FirstOrDefault();
                if (child == null)
                {
                    child = CreateInternal();
                    child.companyId = 0;
                    child.Code = code;
                    child.name = name;
                    child.sortOrder = sortOrder;
                    child.parentId = parent.Id;
                    child.parentTypeCode = parent.Code;
                    child.logicalParentId = logicalParentId;
                    child = SaveInternal(child, Msgs);
                    if (Msgs.hasAnyError)
                    {

                    }
                }

                return child;
            }

        }

        #endregion

        #region GetChilds
        public List<LOV> GetChilds(string parentTypeCode)
        {
            var ctx = _UserSession.DataContext as DataManager.DataContext;

            var list = ctx.GetAll<LOV>().Where(s => s.parentTypeCode == parentTypeCode).ToList();

            return list;
        }
        #endregion

        #region GetLOVByCode
        public LOV GetLovByCode(string parentTypeCode, string code)
        {
            var ctx = _UserSession.DataContext as DataManager.DataContext;

            var lov = ctx.GetAll<LOV>().Where(s => s.Code == code && s.parentTypeCode == parentTypeCode).FirstOrDefault();

            return lov;
        }
        #endregion


        #region OnCheckSaveRules
        protected override void OnCheckSaveRules(LOV entity, IReportedMsgs msgs)
        {
            base.OnCheckSaveRules(entity, msgs);

            string[] required = { "name" };
            Validations.Validate_Required(entity, required, msgs);
            if (msgs.hasAnyError) return;

        }
        #endregion
    }
}

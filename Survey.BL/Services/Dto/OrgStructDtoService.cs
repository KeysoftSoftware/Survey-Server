using KF.Primitives;
using KF.Services;
using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unclassified.FieldLog;

namespace Survey.BL.Services.Dto
{
    public partial class OrgStructDtoService
    {
        internal void GetNodesCall(UserSession userSession, APICall call)
        {
            var levelId = call.GetParameters<Int32>("key");
            ReportedMsgs msgs = new ReportedMsgs();

            var list = GetNodes(levelId, msgs);
            if (!msgs.hasAnyError)
            {
                call.isSuccess = true;
                call.callResult.Add("data", list);
            }
            else
            {
                call.isSuccess = false;
            }
        }

        public List<OrgStructDto> GetNodes(int levelId, ReportedMsgs msgs)
        {
            List<OrgStructDto> col = new List<OrgStructDto>();

            try
            {
                using (var ctx = DataManager.GetDBContext())
                {
                    IQueryable<OrgStruct> nodes;
                    if (levelId > 0)
                    {
                        nodes = ctx.GetAll<OrgStruct>().Where(s => s.parentId == levelId);
                    }
                    else
                    {
                        nodes = ctx.GetAll<OrgStruct>().Where(s => s.parentId == levelId);
                    }

                    foreach (var node in nodes)
                    {
                        var item = new OrgStructDto();
                        item.From(node);
                        item.childsCount = ctx.GetAll<OrgStruct>().Where(s => s.parentId == node.Id).Count();
                        col.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                FL.Error(e);
            }
            return col;
        }
    }
}


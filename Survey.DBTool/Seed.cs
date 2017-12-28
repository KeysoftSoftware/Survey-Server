using KF.Primitives;
using KF.Services;
using KF.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Survey.BL;
using Survey.BL.Services;
using Survey.BL.Services.Persistent;
using Survey.Model;
using Survey.BL.Common;

namespace Survey.DBTool
{
    class Seed
    {
        #region CreateDefaultData
        public static ReportedMsgs CreateDefaultData(UserSession us)
        {
            ReportedMsgs msgs = new ReportedMsgs();

            Add_Lovs(us, "../../Defaults/lovs.xml");
            //Add_Params(us, "../../Defaults/definitions.xml", msgs);
            AddMain(us, msgs);
            //AddUsers(us, msgs);
            return msgs;
        }

       
        #endregion

        #region Add_Lovs
        public static string Add_Lovs(UserSession us, string FilePath)
        {
            if (!File.Exists(FilePath)) return "";

            XmlDocument doc = new XmlDocument();
            doc.Load(FilePath);

            var lovService = us.GetService<LOVService>();

            XmlNodeList nlist = doc.SelectNodes("//EntityType/LOVParent");

            foreach (XmlElement node in nlist)
            {

                var Code = node.GetAttribute("Code");
                var Name = node.GetAttribute("Name");
                var isSystemStr = node.GetAttribute("isSystem");
                var ParentLogicalParentCode = node.GetAttribute("logicalParentCode");
                var parent = lovService.AddLov(Code, Name);
                if (isSystemStr == "true") parent.isSystem = true;

                if (node.HasChildNodes)
                {
                    XmlNodeList fields = node.GetElementsByTagName("LOV");
                    foreach (XmlElement field in fields)
                    {
                        var logicalParentId = 0;
                        var childCode = field.GetAttribute("Code");
                        var childName = field.GetAttribute("Name");
                        var sortOrder = field.GetAttribute<int>("sortOrder");
                        var logicalParentCode = field.GetAttribute("logicalParentCode");

                        if (!string.IsNullOrEmpty(logicalParentCode))
                        {
                            var obj = lovService.GetLovByCode(ParentLogicalParentCode, logicalParentCode);
                            if (obj != null) logicalParentId = obj.Id;
                        }

                        var child = lovService.AddLov(childCode, childName, parent, logicalParentId, sortOrder);
                    }
                }

                us.SaveChanges();
            }

            return "";
        }

        #endregion


        #region AddMain
        public static void AddMain(UserSession us, ReportedMsgs msgs)
        {
            using (var ctx = Survey.BL.DataManager.GetDBContext())
            {
                var userSrv = us.GetService<UserService>();

                var user = ctx.GetByCode<User>("system");
                if (user == null)
                {
                    userSrv.AddUser("system", "key0soft!$", "מערכת", "admin");
                    us.SaveChanges();
                }

                var lovSrv = us.GetService<LOVService>();

                //orgstruct
                var orgSTructSrv = us.GetService<OrgStructService>();
                var parent = orgSTructSrv.CreateInternal();
                parent.name = "תמורות";
                parent.parentId = 0;
                parent.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.COMPANY);
                parent.levelNo = 1;

                orgSTructSrv.SaveInternal(parent, msgs);
                us.FlushChanges();
                parent.Code = parent.Id.ToString();

                var child = orgSTructSrv.CreateInternal();

                if(parent != null)
                {
                    child.name = "הפצה";
                    child.parentId = parent.Id;
                    child.parentOrgStruct = parent;
                    child.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.DEPARTMENT);
                    orgSTructSrv.SaveInternal(parent, msgs);
                    us.FlushChanges();
                    child.Code = parent.Code + "-" + child.Id.ToString();

                    var depParent = child;
                    child = orgSTructSrv.CreateInternal();
                    child.name = "הפצה צפון";
                    child.parentId = depParent.Id;
                    child.parentOrgStruct = depParent;
                    child.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.DEPARTMENT);
                    orgSTructSrv.SaveInternal(parent, msgs);
                    us.FlushChanges();
                    child.Code = depParent.Code + "-" + child.Id.ToString();

                    child = orgSTructSrv.CreateInternal();
                    child.name = "הפצה דרום";
                    child.parentId = depParent.Id;
                    child.parentOrgStruct = depParent;
                    child.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.DEPARTMENT);
                    orgSTructSrv.SaveInternal(parent, msgs);
                    us.FlushChanges();
                    child.Code = depParent.Code + "-" + child.Id.ToString();


                    child = orgSTructSrv.CreateInternal();
                    child.name = "שיווק";
                    child.parentId = parent.Id;
                    child.parentOrgStruct = parent;
                    child.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.DEPARTMENT);
                    orgSTructSrv.SaveInternal(parent, msgs);
                    us.FlushChanges();
                    child.Code = parent.Id + "-" + child.Id.ToString();

                    child = orgSTructSrv.CreateInternal();
                    child.name = "הדרכה";
                    child.parentId = parent.Id;
                    child.parentOrgStruct = parent;
                    child.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.DEPARTMENT);
                    orgSTructSrv.SaveInternal(parent, msgs);
                    us.FlushChanges();

                    child.Code = parent.Id + "-" + child.Id.ToString();
                    us.FlushChanges();
                }
                us.SaveChanges();

                parent = orgSTructSrv.CreateInternal();
                parent.name = "קיסופט";
                parent.parentId = 0;
                parent.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.COMPANY);
                parent.levelNo = 1;

                orgSTructSrv.SaveInternal(parent, msgs);
                us.FlushChanges();
                parent.Code = parent.Id.ToString();
                us.SaveChanges();

                if (parent != null)
                {
                    child = orgSTructSrv.CreateInternal();
                    child.name = "פיתוח";
                    child.parentId = parent.Id;
                    child.parentOrgStruct = parent;
                    child.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.DEPARTMENT);
                    orgSTructSrv.SaveInternal(parent, msgs);
                    us.FlushChanges();
                    child.Code = parent.Code + "-" + child.Id.ToString();

                    child = orgSTructSrv.CreateInternal();
                    child.name = "תמיכה";
                    child.parentId = parent.Id;
                    child.parentOrgStruct = parent;
                    child.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.DEPARTMENT);
                    orgSTructSrv.SaveInternal(parent, msgs);
                    us.FlushChanges();
                    child.Code = parent.Id + "-" + child.Id.ToString();

                    child = orgSTructSrv.CreateInternal();
                    child.name = "הדרכה";
                    child.parentId = parent.Id;
                    child.parentOrgStruct = parent;
                    child.levelType = lovSrv.GetLovByCode(Constants.Lovs.LEVEL_TYPE, Constants.LevelTypes.DEPARTMENT);
                    orgSTructSrv.SaveInternal(parent, msgs);
                    us.FlushChanges();
                    child.Code = parent.Id + "-" + child.Id.ToString();
                    us.SaveChanges();

                }
            }
        }
        #endregion

    }
}

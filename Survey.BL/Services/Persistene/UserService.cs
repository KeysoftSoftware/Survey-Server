using KF.Services;
using Survey.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.BL.Services.Persistent
{
    public class UserService : KF.Services.EntityService<User>
    {
        public UserService(UserSession session) : base(session)
        {
        }

        #region AddUser
        public User AddUser(string userId, string pw, string displayName, string role)
        {
            var ctx = DataManager.GetDBContext();
            var user = ctx.GetAll<User>().Where(s => s.userId == userId).FirstOrDefault();
            if (user == null)
            {
                user = CreateInternal();
                user.userId = userId;
                user.salt = KF.Utils.SecurityHelper.CreateSalt();
                user.password = KF.Utils.SecurityHelper.GetHash(pw, user.salt);
                user.displayName = displayName;
                user.role = role;
                SaveInternal(user, Msgs);
                if (Msgs.hasAnyError)
                {

                }
            }
            return user;
        }
        #endregion
    }
}

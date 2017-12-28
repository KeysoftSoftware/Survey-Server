using Survey.Model;
using KF.Interfaces;
using KF.Services;
using KF.Utils;
using System;
using System.Linq;
using Unclassified.FieldLog;
using KF.Primitives;
using Survey.BL.Services.Persistent;

namespace Survey.BL.Services.Auth
{
    public class AuthService
    {
        UserSession _UserSession;

        #region AuthService
        public AuthService(UserSession settings)
        {
            _UserSession = settings;
        }
        #endregion

        internal void LoginCall(APICall call)
        {
            var userId = call.GetParameters<string>("userId");
            var pw = call.GetParameters<string>("pw");

#if DEBUG 
            if (userId == "system") pw = "key0soft!$";
#endif
            UserInfo userInfo;
            Login(call.msgs, userId, pw, out userInfo);

            if (!call.msgs.hasAnyError)
            {
                call.callResult.Add("userInfo", userInfo);
                call.isSuccess = true;
                return;
            }
        }

        #region Login
        private void Login(IReportedMsgs msgs, string loginId, string pw, out UserInfo userInfo)
        {
            userInfo = new UserInfo();

            var ctx = DataManager.GetDBContext();

            var user = ctx.GetAll<User>().Where(s => s.userId == loginId).FirstOrDefault();
            if (user == null)
            {
                msgs.AddLogicalError("User does not exist", "USER_NOT_EXIST");
                return;
            }

            var encPw = SecurityHelper.GetHash(pw, user.salt);
            if (user.password != encPw)
            {
                msgs.AddLogicalError("Password is not correct", "USER_WRONG_PW");
                return;
            }

            var accessToken = SecurityHelper.GetHash(DateTime.Now.Ticks.ToString(), user.salt);

            var userSrv = _UserSession.GetService<UserService>();
            var saveUser = userSrv.LoadInternal(user.Id);

            saveUser.lastLogin = DateTime.Now;
            saveUser.accessToken = accessToken;

            _UserSession.Save(saveUser);
            _UserSession.SaveChanges();

            userInfo.accessToken = accessToken;
            userInfo.currentRole = user.role; // ??
            userInfo.displayName = user.displayName;
        }
        #endregion

        public static void LogoutCall(UserSession userSession, APICall call)
        {
            var msgs = new ReportedMsgs();
            var service = new AuthService(userSession);
            service.Logout(msgs);
            call.isSuccess = !msgs.hasAnyError;
            if (msgs.hasAnyError) call.msgs = msgs;
        }

        #region Logout
        private void Logout(IReportedMsgs msgs)
        {
            if (_UserSession.Env.user == null) return;
            var accessToken = _UserSession.Env.userToken;

            var ctx = DataManager.GetDBContext();
            var user = ctx.GetAll<User>().Where(s => s.accessToken == accessToken).FirstOrDefault();
            if (user == null)
            {
                msgs.AddLogicalError("user not found!");
                return;
            }

            var userSrv = _UserSession.GetService<UserService>();
            var saveUser = userSrv.LoadInternal(user.Id);

            saveUser.accessToken = null;
            _UserSession.Save(saveUser);
            _UserSession.SaveChanges();
        }
        #endregion


        #region GetUserFromToken
        public static User GetUserFromToken(string accessToken)
        {
            var ctx = DataManager.GetDBContext();
            var user = ctx.GetAll<User>().Where(s => s.accessToken == accessToken).FirstOrDefault();
            if (user == null) throw new InvalidOperationException("User is not authenticated");
            return user;
        }
        #endregion

    }

    public class UserInfo
    {
        public string displayName;
        public string currentRole;
        public string accessToken;
    }




}

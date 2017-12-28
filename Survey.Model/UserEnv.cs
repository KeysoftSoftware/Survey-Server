using KF.Interfaces;
using KF.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model
{
    public class UserEnv : IUserEnv
    {
        public UserEnv()
        {
            userSessionData = new MetaDataBase();
        }

        public string langCode { get; set; }
        public string userToken { get; set; }
        public string customerName { get; set; }
        public string currentRole { get; set; }
        public IBaseEntity user { get; set; }

        public bool isAuthenticated => throw new NotImplementedException();

        public MetaDataBase userSessionData { get; set; }
      
        IMetaDataBase IUserEnv.userSessionData { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //IBaseEntity IUserEnv.user { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        

    }
}

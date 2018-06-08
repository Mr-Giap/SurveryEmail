using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.BaseBLL;
using DataAccessLayer.DAL;
using ValueObjects;

namespace BusinessLogicLayer.BLL
{
    class UserBLL : BaseUser<OUsers>
    {
        UserDAL abc = new UserDAL();
        public override List<OUsers> GetallUsers()
        {
            return abc.GetallUsers();
        }
        public override OUsers Checklogin(OUsers user)
        {
            return abc.Checklogin(user);
        }
        public override bool Delete(OUsers user)
        {
            return abc.Delete(user);
        }
        public override bool Insert(OUsers user)
        {
            return abc.Insert(user);
        }
        public override bool Update_Information(OUsers user)
        {
            return abc.Update_Information(user);
        }
        public override bool Update_Password(OUsers user)
        {
            return abc.Update_Password(user);
        }
    }
}

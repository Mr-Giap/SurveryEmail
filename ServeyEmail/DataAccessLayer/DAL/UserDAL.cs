using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.BaseDAL;
using DataAccessLayer.Model;
using ValueObjects;
namespace DataAccessLayer.DAL
{
    public class UserDAL:BaseUser<OUsers>
    {
        private StatusSurveyEntities db;
        public UserDAL()
        {
            db = new StatusSurveyEntities();
        }
        public override OUsers Checklogin(OUsers user)
        {
            OUsers nu = new OUsers();
            var checkuser = db.User_Checklogin(user.UserName, Encryptor.MD5Hash(user.Password)).FirstOrDefault();            
            if (checkuser!=null)
            {
                nu.IdUser = checkuser.IdUser;
                nu.UserName = checkuser.UserName;
                nu.Password = checkuser.Password;
                nu.FullName = checkuser.FullName;
                nu.Address = checkuser.Address;
                nu.Phone = checkuser.Phone;
                nu.Email = checkuser.Email;
                nu.IdRole = checkuser.IdRole;
                nu.IdGroup = checkuser.IdGroup;
                return nu;
            }
            else {
                return nu;
            }
        }
        public override List<OUsers> GetallUsers()
        {
            List<OUsers> listuser = new List<OUsers>();
            var list = db.User_Select_All();
            foreach (var item in list)
            {
                OUsers user = new OUsers();
                user.IdUser = item.IdUser;
                user.UserName = item.UserName;
                user.Password = item.Password;
                user.FullName = item.FullName;
                user.Address = item.Address;
                user.Phone = item.Phone;
                user.Email = item.Email;
                user.IdRole = item.IdRole;
                user.IdGroup = item.IdGroup;
                listuser.Add(user);
            }
            return listuser;
        }
        public override bool Insert(OUsers user)
        {
            db.User_Insert(user.IdUser, user.UserName, Encryptor.MD5Hash(user.Password), user.FullName, user.Address, user.Email, user.Phone, user.IdRole, user.IdGroup);
            return true;
        }
        public override bool Update_Information(OUsers user)
        {
            db.User_Update_Informatiom_Normal(user.IdUser, user.FullName, user.Address, user.Email, user.Phone);
            return true;
        }
        public override bool Update_Password(OUsers user)
        {
            db.User_Update_Password_Normal(user.IdUser, user.Password, user.IdRole);
            return true;
        }
        public override bool Delete(OUsers user)
        {
            db.User_Delete(user.IdUser);
            return true;
        }        
    }
}

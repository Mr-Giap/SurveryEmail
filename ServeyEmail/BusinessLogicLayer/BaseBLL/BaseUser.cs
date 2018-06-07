using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BaseBLL
{
    public class BaseUser<T>
    {
        public virtual T Checklogin(T user) { return user; }
        public virtual List<T> GetallUsers() { List<T> Listuser = new List<T>(); return Listuser; }
        public virtual bool Insert(T user) { return false; }
        public virtual bool Update_Information(T user) { return false; }
        public virtual bool Update_Password(T user) { return false; }
        public virtual bool Delete(T user) { return false; }

    }
}

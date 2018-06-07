using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BaseBLL
{
    public class BaseRole<T>
    {
        public virtual List<T> Getall() { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T role) { return false; }
        public virtual bool Update(T role) { return false; }
        public virtual bool Delete(T role) { return false; }
    }
}

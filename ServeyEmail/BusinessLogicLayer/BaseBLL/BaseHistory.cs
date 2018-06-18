using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BusinessLogicLayer.BaseBLL
{
    public class BaseHistory<T>
    {
        public virtual List<T> Getall() { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T his) { return false; }
        public virtual bool Update(T his) { return false; }
        public virtual bool Delete(T his) { return false; }
        public virtual List<T> Checkdate(DateTime date,Guid IdGroup) { List<T> list = new List<T>();return list; }
    }
}

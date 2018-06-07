﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseDAL
{
    public class BaseStatus<T>
    {
        public virtual List<T> Getall() { List<T> list = new List<T>(); return list; }
        public virtual bool Insert(T status) { return false; }
        public virtual bool Rename(T status) { return false; }
        public virtual bool Delete(T status) { return false; }
    }
}

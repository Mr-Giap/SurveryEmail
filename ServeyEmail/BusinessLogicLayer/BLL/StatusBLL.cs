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
    public class StatusBLL : BaseStatus<OStatus>
    {
        StatusDAL stt = new StatusDAL();
        public override List<OStatus> Getall()
        {
            return stt.Getall();
        }
        public override bool Delete(OStatus status)
        {
            return stt.Delete(status);
        }
        public override bool Insert(OStatus status)
        {
            return stt.Insert(status);
        }
        public override bool Rename(OStatus status)
        {
            return stt.Rename(status);
        }
        public override string Getname(int status)
        {
            return stt.Getname(status);
        }

    }
}

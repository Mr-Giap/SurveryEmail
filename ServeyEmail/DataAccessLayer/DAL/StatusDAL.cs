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
    public class StatusDAL:BaseStatus<OStatus>
    {
        private StatusSurveyEntities db;
        public StatusDAL()
        {
            db = new StatusSurveyEntities();
        }
        public override List<OStatus> Getall()
        {
            List<OStatus> listSta = new List<OStatus>();
            var list = db.Status_Select_All();
            foreach (var item in list)
            {
                OStatus stt = new OStatus();
                stt.IdStatus = item.IdStatus;
                stt.Name = item.Name;

                listSta.Add(stt);
            }
            return listSta;
        }
        public override bool Insert(OStatus status)
        {
            db.Status_Insert(status.IdStatus, status.Name);
            return true;
        }
        public override bool Rename(OStatus status)
        {
            db.Status_Rename(status.IdStatus, status.Name);
            return true;
        }
        public override bool Delete(OStatus status)
        {
            db.Status_Delete(status.IdStatus);
            return true;
        }
        public override string Getname(int idstatus)
        {
            string t;
            t = db.Status_Getname(idstatus).ToString();
            return t;
        }
    }
}

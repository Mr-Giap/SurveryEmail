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
     public class HistoryDAL:BaseHistory<OHistories>
    {
        private StatusSurveyEntities db;
        public HistoryDAL()
        {
            db = new StatusSurveyEntities();
        }
        public override List<OHistories> Getall()
        {
            List<OHistories> listHis = new List<OHistories>();
            var list = db.History_Select_All();
            foreach (var item in list)
            {
                OHistories his = new OHistories();
                his.IdHis = item.IdHis;
                his.IdStatus = item.IdStatus;
                his.CreationDate = item.CreationDate;
                his.Amount = item.Amount;
                his.IdGroup = item.IdGroup;

                listHis.Add(his);
            }
            return listHis;
        }
        public override bool Insert(OHistories his)
        {
            db.History_Insert(his.IdHis, his.CreationDate, his.IdStatus, his.IdGroup);
            return true;
        }
        public override bool Update(OHistories his)
        {
            db.History_Update(his.IdHis);
            return true;
        }
        public override bool Delete(OHistories his)
        {
            db.History_Delete(his.IdHis);
            return true;
        }
        public override List<OHistories> Checkdate(string date)
        {
            List<OHistories> list = new List<OHistories>();
           var List = db.History_Checkdate(date);
            foreach(var item in List)
            {
                OHistories a = new OHistories();
                a.IdStatus = item.IdStatus;
                a.Amount = item.Amount;
                list.Add(a);
            }

            return list;
        }
    }
}

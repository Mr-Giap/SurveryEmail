using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.BaseBLL;
using DataAccessLayer.DAL;
using ValueObjects;
using System.Collections;

namespace BusinessLogicLayer.BLL
{
    public class HistoryBLL : BaseHistory<OHistories>
    {
        HistoryDAL ht = new HistoryDAL();
        public override List<OHistories> Getall()
        {
            return ht.Getall();
        }
        public override bool Insert(OHistories his)
        {
            return ht.Insert(his);
        }
        public override bool Delete(OHistories his)
        {
            return ht.Delete(his);
        }
        public override bool Update(OHistories his)
        {
            return ht.Update(his);
        }
        public override List<OHistories> Checkdate(DateTime date)
        {
            return ht.Checkdate(date);
        }

    }
}

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
    class HistoryBLL : BaseHistory<OHistories>
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
    }
}

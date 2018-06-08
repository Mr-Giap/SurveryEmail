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
    class GroupBLL:BaseGroup<OGroups>
    {
        GroupDAL gr = new GroupDAL();
        public override List<OGroups> Getall()
        {
            return gr.Getall();
        }
        public override bool Delete(OGroups group)
        {
            return gr.Delete(group);

        }
        public override bool Insert(OGroups group)
        {
            return gr.Insert(group);
        }
        public override bool Update(OGroups group)
        {
            return gr.Update(group);
        }
    }
}

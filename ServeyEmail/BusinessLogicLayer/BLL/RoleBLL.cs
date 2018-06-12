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
    public class RoleBLL : BaseRole<ORules>
    {
        RoleDAL rule = new RoleDAL();
        public override List<ORules> Getall()
        {
            return rule.Getall();
        }
        public override bool Delete(ORules role)
        {
            return rule.Delete(role);
        }
        public override bool Insert(ORules role)
        {
            return rule.Insert(role);
        }
        public override bool Update(ORules role)
        {
            return rule.Update(role);
        }
    }
}

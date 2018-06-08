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
    public class RoleDAL:BaseRole<ORules>
    {
        private StatusSurveyEntities db;
        public RoleDAL()
        {
            db = new StatusSurveyEntities();
        }
        public override bool Insert(ORules role)
        {
            db.Role_Insert(role.IdRole, role.Name);
            return true;
        }
        public override List<ORules> Getall()
        {
            List<ORules> listRole = new List<ORules>();
            var list = db.Role_Select_All();
            foreach (var item in list)
            {
                ORules role = new ORules();
                role.IdRole = item.IdRole;
                role.Name = item.Name;

                listRole.Add(role);
            }
            return listRole;
        }
        public override bool Update(ORules role)
        {
            db.Role_Update(role.IdRole, role.Name);
            return true;
        }
        public override bool Delete(ORules role)
        {
            db.Role_Delete(role.IdRole);
            return true;
        }
    }
}

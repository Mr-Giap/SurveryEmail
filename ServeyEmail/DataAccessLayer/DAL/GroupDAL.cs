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
    public class GroupDAL:BaseGroup<OGroups>
    {
        private StatusSurveyEntities db;
        public GroupDAL()
        {
            db = new StatusSurveyEntities();
        }
        public override bool Insert(OGroups group)
        {
            db.Group_Insert(group.IdGroup, group.Name, group.Contents);
            return true;
        }
        public override List<OGroups> Getall()
        {
            List<OGroups> listGroup = new List<OGroups>();
            var list = db.Group_Select_All();
            foreach (var item in list)
            {
                OGroups gr = new OGroups();
                gr.IdGroup = item.IdGroup;
                gr.Name = item.Name;
                gr.Contents = item.Contents;

                listGroup.Add(gr);
            }
            return listGroup;
        }
        public override bool Update(OGroups group)
        {
            db.Group_Update(group.IdGroup, group.Name, group.Contents);
            return true;
        }
        public override bool Delete(OGroups group)
        {
            db.Group_Delete(group.IdGroup);
            return true;
        }    }
}

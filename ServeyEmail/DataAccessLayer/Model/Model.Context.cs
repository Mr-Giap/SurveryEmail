﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class StatusSurveyEntities : DbContext
    {
        public StatusSurveyEntities()
            : base("name=StatusSurveyEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<History> History { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    
        public virtual int Group_Delete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Group_Delete", idParameter);
        }
    
        public virtual int Group_Insert(Nullable<System.Guid> id, string name, string content)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var contentParameter = content != null ?
                new ObjectParameter("content", content) :
                new ObjectParameter("content", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Group_Insert", idParameter, nameParameter, contentParameter);
        }
    
        public virtual ObjectResult<Group_Select_All_Result> Group_Select_All()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Group_Select_All_Result>("Group_Select_All");
        }
    
        public virtual int Group_Update(Nullable<System.Guid> id, string name, string content)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(System.Guid));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var contentParameter = content != null ?
                new ObjectParameter("content", content) :
                new ObjectParameter("content", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Group_Update", idParameter, nameParameter, contentParameter);
        }
    
        public virtual int History_Delete(Nullable<System.Guid> idhis)
        {
            var idhisParameter = idhis.HasValue ?
                new ObjectParameter("idhis", idhis) :
                new ObjectParameter("idhis", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("History_Delete", idhisParameter);
        }
    
        public virtual int History_Insert(Nullable<System.Guid> idhis, Nullable<System.DateTime> date, Nullable<int> idstatus, Nullable<System.Guid> idgroup)
        {
            var idhisParameter = idhis.HasValue ?
                new ObjectParameter("idhis", idhis) :
                new ObjectParameter("idhis", typeof(System.Guid));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var idstatusParameter = idstatus.HasValue ?
                new ObjectParameter("idstatus", idstatus) :
                new ObjectParameter("idstatus", typeof(int));
    
            var idgroupParameter = idgroup.HasValue ?
                new ObjectParameter("idgroup", idgroup) :
                new ObjectParameter("idgroup", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("History_Insert", idhisParameter, dateParameter, idstatusParameter, idgroupParameter);
        }
    
        public virtual ObjectResult<History_Select_All_Result> History_Select_All()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<History_Select_All_Result>("History_Select_All");
        }
    
        public virtual int History_Update(Nullable<System.Guid> idhis)
        {
            var idhisParameter = idhis.HasValue ?
                new ObjectParameter("idhis", idhis) :
                new ObjectParameter("idhis", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("History_Update", idhisParameter);
        }
    
        public virtual int Role_Delete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Role_Delete", idParameter);
        }
    
        public virtual int Role_Insert(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Role_Insert", idParameter, nameParameter);
        }
    
        public virtual ObjectResult<Role_Select_All_Result> Role_Select_All()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Role_Select_All_Result>("Role_Select_All");
        }
    
        public virtual int Role_Update(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Role_Update", idParameter, nameParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int Status_Delete(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Status_Delete", idParameter);
        }
    
        public virtual int Status_Insert(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Status_Insert", idParameter, nameParameter);
        }
    
        public virtual int Status_Rename(Nullable<int> id, string name)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Status_Rename", idParameter, nameParameter);
        }
    
        public virtual ObjectResult<Status_Select_All_Result> Status_Select_All()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Status_Select_All_Result>("Status_Select_All");
        }
    
        public virtual ObjectResult<User_Checklogin_Result> User_Checklogin(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_Checklogin_Result>("User_Checklogin", usernameParameter, passwordParameter);
        }
    
        public virtual int User_Delete(Nullable<System.Guid> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("User_Delete", idParameter);
        }
    
        public virtual int User_Insert(Nullable<System.Guid> id, string username, string pass, string fullname, string address, string email, string phone, Nullable<int> idrole, Nullable<System.Guid> idgroup)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var fullnameParameter = fullname != null ?
                new ObjectParameter("fullname", fullname) :
                new ObjectParameter("fullname", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var idroleParameter = idrole.HasValue ?
                new ObjectParameter("idrole", idrole) :
                new ObjectParameter("idrole", typeof(int));
    
            var idgroupParameter = idgroup.HasValue ?
                new ObjectParameter("idgroup", idgroup) :
                new ObjectParameter("idgroup", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("User_Insert", idParameter, usernameParameter, passParameter, fullnameParameter, addressParameter, emailParameter, phoneParameter, idroleParameter, idgroupParameter);
        }
    
        public virtual ObjectResult<User_Select_All_Result> User_Select_All()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_Select_All_Result>("User_Select_All");
        }
    
        public virtual int User_Update_Informatiom_Normal(Nullable<System.Guid> id, string fullname, string address, string email, string phone)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var fullnameParameter = fullname != null ?
                new ObjectParameter("fullname", fullname) :
                new ObjectParameter("fullname", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("User_Update_Informatiom_Normal", idParameter, fullnameParameter, addressParameter, emailParameter, phoneParameter);
        }
    
        public virtual int User_Update_Password_Normal(Nullable<System.Guid> id, string pass, Nullable<int> idrole)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var passParameter = pass != null ?
                new ObjectParameter("pass", pass) :
                new ObjectParameter("pass", typeof(string));
    
            var idroleParameter = idrole.HasValue ?
                new ObjectParameter("idrole", idrole) :
                new ObjectParameter("idrole", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("User_Update_Password_Normal", idParameter, passParameter, idroleParameter);
        }
    
        public virtual int User_Update_Permission(Nullable<System.Guid> id, Nullable<int> idrole)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(System.Guid));
    
            var idroleParameter = idrole.HasValue ?
                new ObjectParameter("idrole", idrole) :
                new ObjectParameter("idrole", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("User_Update_Permission", idParameter, idroleParameter);
        }
    
        public virtual ObjectResult<History_Checkdate_Result> History_Checkdate(Nullable<System.DateTime> date, Nullable<System.Guid> idg)
        {
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(System.DateTime));
    
            var idgParameter = idg.HasValue ?
                new ObjectParameter("Idg", idg) :
                new ObjectParameter("Idg", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<History_Checkdate_Result>("History_Checkdate", dateParameter, idgParameter);
        }
    
        public virtual ObjectResult<string> Status_Getname(Nullable<int> ids)
        {
            var idsParameter = ids.HasValue ?
                new ObjectParameter("ids", ids) :
                new ObjectParameter("ids", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Status_Getname", idsParameter);
        }
    }
}

//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class User
    {
        public System.Guid IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int IdRole { get; set; }
        public System.Guid IdGroup { get; set; }
        public Nullable<bool> CheckEmail { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Role Role { get; set; }
    }
}
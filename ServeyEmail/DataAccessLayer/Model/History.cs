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
    
    public partial class History
    {
        public System.Guid IdHis { get; set; }
        public System.DateTime CreationDate { get; set; }
        public int IdStatus { get; set; }
        public System.Guid IdGroup { get; set; }
        public Nullable<int> Amount { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Status Status { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BloodFinderMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppUser
    {
        public int AppUserID { get; set; }
        public string NameSurname { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> FK_City { get; set; }
        public Nullable<int> FK_Town { get; set; }
        public Nullable<int> FK_BloodGroup { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public string Guid { get; set; }
    }
}
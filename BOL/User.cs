//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string MachineId { get; set; }
        public System.DateTime DateStamp { get; set; }
        public string Email { get; set; }
        public bool locked { get; set; }
        public string deleted { get; set; }
        public string AddedBy { get; set; }
        public string UserDept { get; set; }
        public string HomeDirectory { get; set; }
    }
}
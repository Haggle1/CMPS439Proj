//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEPARTMENT
    {
        public DEPARTMENT()
        {
            this.GOODs = new HashSet<GOOD>();
            this.CUSTODIANs = new HashSet<CUSTODIAN>();
        }
    
        public int DepartmentId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<GOOD> GOODs { get; set; }
        public virtual ICollection<CUSTODIAN> CUSTODIANs { get; set; }
    }
}

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
    
    public partial class FARMER
    {
        public FARMER()
        {
            this.GOODs = new HashSet<GOOD>();
            this.FARMERS_MARKET = new HashSet<FARMERS_MARKET>();
        }
    
        public int VendorId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    
        public virtual ICollection<GOOD> GOODs { get; set; }
        public virtual ICollection<FARMERS_MARKET> FARMERS_MARKET { get; set; }
    }
}
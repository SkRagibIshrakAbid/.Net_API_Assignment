//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIintro.Models.databsae
{
    using System;
    using System.Collections.Generic;
    
    public partial class dept
    {
        public dept()
        {
            this.students = new HashSet<student>();
        }
    
        public int did { get; set; }
        public string dname { get; set; }
    
        public virtual ICollection<student> students { get; set; }
    }
}

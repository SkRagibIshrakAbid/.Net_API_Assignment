﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class APIassignmentEntities : DbContext
    {
        public APIassignmentEntities()
            : base("name=APIassignmentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<dept> depts { get; set; }
        public DbSet<student> students { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
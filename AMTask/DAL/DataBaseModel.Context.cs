﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mvc2Entities : DbContext
    {
        public mvc2Entities()
            : base("name=mvc2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dbo_t_User_PersonalDetails> dbo_t_User_PersonalDetails { get; set; }
        public virtual DbSet<dbo_t_Users> dbo_t_Users { get; set; }
    }
}

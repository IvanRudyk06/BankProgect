﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BankDB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bankDatabaseEntities : DbContext
    {
        public bankDatabaseEntities()
            : base("name=bankDatabaseEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Acount> Acount { get; set; }
        public virtual DbSet<AcountType> AcountType { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class mvc5_CricketEntities : DbContext
    {
        public mvc5_CricketEntities()
            : base("name=mvc5_CricketEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cricketer_Details> Cricketer_Details { get; set; }
        public virtual DbSet<Cricketer_ODI_Statistics> Cricketer_ODI_Statistics { get; set; }
        public virtual DbSet<Cricketer_Test_Statistics> Cricketer_Test_Statistics { get; set; }
        public virtual DbSet<Cricketer> Cricketers { get; set; }
    }
}
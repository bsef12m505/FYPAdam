﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdamDal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdamDatabaseEntities2 : DbContext
    {
        public AdamDatabaseEntities2()
            : base("name=AdamDatabaseEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product_Specification> Product_Specification { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<FeatureSentiment> FeatureSentiments { get; set; }
        public DbSet<Customer_AreaOfInterest> Customer_AreaOfInterest { get; set; }
    }
}

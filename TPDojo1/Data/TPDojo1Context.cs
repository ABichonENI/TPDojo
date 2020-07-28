using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BO;
using TPDojo1.Models;

namespace TPDojo1.Data
{
    public class TPDojo1Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TPDojo1Context() : base("name=TPDojo1Context")
        {
         }  
        
        
    

        public System.Data.Entity.DbSet<BO.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<BO.Arme> Armes { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samourai>().HasOptional(a=> a.Arme);
            modelBuilder.Entity<Samourai>().HasMany(m => m.ArtMartials).WithMany();
           ;

        }
    }
}

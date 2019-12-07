using iskurMVC_Eticaret.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iskurMVC_Eticaret.Data
{
    public class MVCE_TicaretDbContext : DbContext
    {
        public MVCE_TicaretDbContext() : base(@"server=TOPRAK\SQLEXPRESS; database=MVCE_Ticaret; uid=sa; pwd=123")
        {
            Database.SetInitializer<MVCE_TicaretDbContext>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
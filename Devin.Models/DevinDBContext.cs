namespace Devin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DevinDBContext : DbContext
    {
        //public DevinDBContext()
        //    : base("name=DevinConnectionString")
        //{
        //}

        public virtual DbSet<RoleSet> RoleSet { get; set; }
        public virtual DbSet<UserInfoSet> UserInfoSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

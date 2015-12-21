namespace Devin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DevinDBContext : DbContext
    {
        public DevinDBContext()           
            : base("name=DBContext")
        {
        }

        public virtual DbSet<dt_manager> dt_manager { get; set; }
        public virtual DbSet<dt_manager_log> dt_manager_log { get; set; }
        public virtual DbSet<dt_manager_role> dt_manager_role { get; set; }
        public virtual DbSet<dt_manager_role_value> dt_manager_role_value { get; set; }
        public virtual DbSet<dt_navigation> dt_navigation { get; set; }
        public virtual DbSet<dt_sms_template> dt_sms_template { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<dt_manager_role>()
                .HasMany(e => e.dt_manager)
                .WithOptional(e => e.dt_manager_role)
                .HasForeignKey(e => e.role_id);

            modelBuilder.Entity<dt_manager_role>()
                .HasMany(e => e.dt_manager_role_value)
                .WithOptional(e => e.dt_manager_role)
                .HasForeignKey(e => e.role_id);
        }
    }
}

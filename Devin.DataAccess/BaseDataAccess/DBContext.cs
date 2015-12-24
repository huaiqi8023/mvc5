using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devin.Models;

namespace Devin.DataAccess.BaseDataAccess
{
    public partial class DBContext : DbContext
    {
        private string _connectionString;
        public DBContext()
            : base("name=DBContext")
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ToString();
        }

        public virtual DbSet<dt_manager> dt_manager { get; set; }
        public virtual DbSet<dt_manager_log> dt_manager_log { get; set; }
        public virtual DbSet<dt_manager_role> dt_manager_role { get; set; }
        public virtual DbSet<dt_manager_role_value> dt_manager_role_value { get; set; }
        public virtual DbSet<dt_navigation> dt_navigation { get; set; }
        public virtual DbSet<dt_sms_template> dt_sms_template { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["DBContext"].ToString();
                }
                return _connectionString;
            }
        }
    }
}

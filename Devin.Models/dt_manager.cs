namespace Devin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dt_manager
    {
        public int id { get; set; }

        public int? role_id { get; set; }

        public int? role_type { get; set; }

        [StringLength(100)]
        public string user_name { get; set; }

        [StringLength(100)]
        public string password { get; set; }

        [StringLength(20)]
        public string salt { get; set; }

        [StringLength(50)]
        public string real_name { get; set; }

        [StringLength(30)]
        public string telephone { get; set; }

        [StringLength(30)]
        public string email { get; set; }

        public int? is_lock { get; set; }

        public DateTime? add_time { get; set; }

        public virtual dt_manager_role dt_manager_role { get; set; }
    }
}

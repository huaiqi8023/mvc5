namespace Devin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dt_manager_role_value
    {
        public int id { get; set; }

        public int? role_id { get; set; }

        [StringLength(100)]
        public string nav_name { get; set; }

        [StringLength(50)]
        public string action_type { get; set; }

        public virtual dt_manager_role dt_manager_role { get; set; }
    }
}

namespace Devin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dt_manager_log
    {
        public int id { get; set; }

        public int? user_id { get; set; }

        [StringLength(100)]
        public string user_name { get; set; }

        [StringLength(100)]
        public string action_type { get; set; }

        [StringLength(255)]
        public string remark { get; set; }

        [StringLength(30)]
        public string user_ip { get; set; }

        public DateTime? add_time { get; set; }
    }
}

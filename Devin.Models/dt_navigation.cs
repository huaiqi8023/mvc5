namespace Devin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dt_navigation
    {
        public int id { get; set; }

        public int? parent_id { get; set; }

        public int? channel_id { get; set; }

        [StringLength(50)]
        public string nav_type { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(100)]
        public string sub_title { get; set; }

        [StringLength(255)]
        public string icon_url { get; set; }

        [StringLength(255)]
        public string link_url { get; set; }

        public int? sort_id { get; set; }

        public byte? is_lock { get; set; }

        [StringLength(500)]
        public string remark { get; set; }

        [StringLength(500)]
        public string action_type { get; set; }

        public byte? is_sys { get; set; }
    }
}

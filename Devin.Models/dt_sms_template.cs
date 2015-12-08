namespace Devin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dt_sms_template
    {
        public int id { get; set; }

        [StringLength(100)]
        public string title { get; set; }

        [StringLength(50)]
        public string call_index { get; set; }

        [Column(TypeName = "ntext")]
        public string content { get; set; }

        public byte? is_sys { get; set; }
    }
}

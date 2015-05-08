namespace Devin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfoSet")]
    public partial class UserInfoSet
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        [StringLength(16)]
        public string Pwd { get; set; }
    }
}

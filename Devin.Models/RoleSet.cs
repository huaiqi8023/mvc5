namespace Devin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleSet")]
    public partial class RoleSet
    {
        public int Id { get; set; }

        public string RoleName { get; set; }
    }
}

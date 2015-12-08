namespace Devin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dt_manager_role
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dt_manager_role()
        {
            dt_manager = new HashSet<dt_manager>();
            dt_manager_role_value = new HashSet<dt_manager_role_value>();
        }

        public int id { get; set; }

        [StringLength(100)]
        public string role_name { get; set; }

        public byte? role_type { get; set; }

        public byte? is_sys { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dt_manager> dt_manager { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dt_manager_role_value> dt_manager_role_value { get; set; }
    }
}

namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KHOAHOC")]
    public partial class KHOAHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KHOAHOC()
        {
            LOPHOC = new HashSet<LOPHOC>();
        }

        [Key]
        public int IDkhoahoc { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string makhoahoc { get; set; }

        public int? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPHOC> LOPHOC { get; set; }
    }
}

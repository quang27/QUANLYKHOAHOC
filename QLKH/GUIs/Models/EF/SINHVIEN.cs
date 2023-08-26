namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SINHVIEN")]
    public partial class SINHVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SINHVIEN()
        {
            LOPSINHVIEN = new HashSet<LOPSINHVIEN>();
        }

        [Key]
        public int IDsinhvien { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(20)]
        public string telephone { get; set; }

        [StringLength(100)]
        public string address { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(350)]
        public string img { get; set; }

        public int? status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPSINHVIEN> LOPSINHVIEN { get; set; }
    }
}

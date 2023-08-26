namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOPHOC")]
    public partial class LOPHOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOPHOC()
        {
            LOPGIANGVIEN = new HashSet<LOPGIANGVIEN>();
            LOPSINHVIEN = new HashSet<LOPSINHVIEN>();
        }

        [Key]
        public int IDlophoc { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int? status { get; set; }

        public int? IDkhoahoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? start { get; set; }

        [Column(TypeName = "date")]
        public DateTime? finish { get; set; }

        public virtual KHOAHOC KHOAHOC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPGIANGVIEN> LOPGIANGVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOPSINHVIEN> LOPSINHVIEN { get; set; }
    }
}

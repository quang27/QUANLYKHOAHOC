namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOPSINHVIEN")]
    public partial class LOPSINHVIEN
    {
        public int ID { get; set; }

        public int? IDsinhvien { get; set; }

        public int? IDlophoc { get; set; }

        public virtual LOPHOC LOPHOC { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}

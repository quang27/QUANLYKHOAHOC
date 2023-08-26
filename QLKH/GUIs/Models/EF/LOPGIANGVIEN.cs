namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LOPGIANGVIEN")]
    public partial class LOPGIANGVIEN
    {
        public int ID { get; set; }

        public int? IDgiangvien { get; set; }

        public int? IDlophoc { get; set; }

        public virtual GIANGVIEN GIANGVIEN { get; set; }

        public virtual LOPHOC LOPHOC { get; set; }
    }
}

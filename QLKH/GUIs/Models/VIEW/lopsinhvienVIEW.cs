using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.VIEW
{
    public class lopsinhvienVIEW
    {
        public int ID { get; set; }

        public int? IDsinhvien { get; set; }

        public int? IDlophoc { get; set; }
        public string sinhvien { get; set; }
        public string lophoc { get; set;}
        public string giangvien { get; set; }
    }
}
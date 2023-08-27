using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.VIEW
{
    public class lopgiangvienVIEW
    {
        public int ID { get; set; }

        public int? IDgiangvien { get; set; }

        public int? IDlophoc { get; set; }
        public string giangvien { get; set; }
        public string lophoc { get; set; }
    }
}
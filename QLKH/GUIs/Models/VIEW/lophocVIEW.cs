using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GUIs.Models.VIEW
{
    public class lophocVIEW
    {
        public int IDlophoc { get; set; }

      
        public string name { get; set; }

        public int? status { get; set; }

        public int? IDkhoahoc { get; set; }

      
        public DateTime? start { get; set; }

       
        public DateTime? finish { get; set; }
        public string khoahoc { get; set; }
    }
}
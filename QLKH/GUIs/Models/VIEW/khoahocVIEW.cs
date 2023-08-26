using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GUIs.Models.VIEW
{
    public class khoahocVIEW
    {
        public int IDkhoahoc { get; set; }

 
        public string name { get; set; }

      
        public string makhoahoc { get; set; }

        public int? status { get; set; }
    }
}
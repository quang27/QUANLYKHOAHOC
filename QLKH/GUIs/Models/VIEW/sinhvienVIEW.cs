using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GUIs.Models.VIEW
{
    public class sinhvienVIEW
    {
        public int IDsinhvien { get; set; }

       
        public string name { get; set; }

        public string telephone { get; set; }

       
        public string address { get; set; }

        public DateTime? birthday { get; set; }

     
        public string img { get; set; }

        public int? status { get; set; }
    }
}
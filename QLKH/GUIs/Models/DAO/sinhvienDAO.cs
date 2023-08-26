using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class sinhvienDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(SINHVIEN item)
        {
            if (item.IDsinhvien == 0)
            {
                context.SINHVIEN.Add(item);
            }
            context.SaveChanges();
        }
        public SINHVIEN getItem(int id)
        {

            return context.SINHVIEN.Where(x => x.IDsinhvien == id).FirstOrDefault();
        }
        public sinhvienVIEW getItemView(int id)
        {

            var query = (from a in context.SINHVIEN
                         where a.IDsinhvien == id
                         select new sinhvienVIEW
                         {
                             IDsinhvien = a.IDsinhvien,
                             name = a.name,
                             telephone = a.telephone,
                             address = a.address,
                             birthday = a.birthday,
                             img = a.img,
                             status = a.status,                           
                         }).FirstOrDefault();
            return query;
        }

        public List<sinhvienVIEW> getList()
        {
            var query = (from a in context.SINHVIEN
                         select new sinhvienVIEW
                         {
                             IDsinhvien = a.IDsinhvien,
                             name = a.name,
                             telephone = a.telephone,
                             address = a.address,
                             birthday = a.birthday,
                             img = a.img,
                             status = a.status,
                         }).ToList();
            return query;
        }
        public List<sinhvienVIEW> Search(String name, int status, out int total, int index = 1, int size = 10)
        {
            var query = (from a in context.SINHVIEN
                         where (a.name.Contains(name) && (a.status == status))
                         select new sinhvienVIEW
                         {
                             IDsinhvien = a.IDsinhvien,
                             name = a.name,
                             telephone = a.telephone,
                             address = a.address,
                             birthday = a.birthday,
                             img = a.img,
                             status = a.status,
                         }).ToList();
            total = query.Count();
            var result = query.Skip((index - 1) * size).Take(size).ToList();
            return result;
        }
        public void Detele(int id)
        {
            SINHVIEN x = getItem(id);
            context.SINHVIEN.Remove(x);
            context.SaveChanges();
        }
    }
}
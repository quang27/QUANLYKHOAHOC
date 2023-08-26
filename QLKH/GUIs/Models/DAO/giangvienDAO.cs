using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class giangvienDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(GIANGVIEN item)
        {
            if (item.IDgiangvien == 0)
            {
                context.GIANGVIEN.Add(item);
            }
            context.SaveChanges();
        }
        public GIANGVIEN getItem(int id)
        {

            return context.GIANGVIEN.Where(x => x.IDgiangvien == id).FirstOrDefault();
        }
        public giangvienVIEW getItemView(int id)
        {

            var query = (from a in context.GIANGVIEN
                         where a.IDgiangvien == id
                         select new giangvienVIEW
                         {
                             IDgiangvien = a.IDgiangvien,
                             name = a.name,
                             telephone = a.telephone,
                             address = a.address,
                             birthday = a.birthday,
                             img = a.img,
                             status = a.status,
                         }).FirstOrDefault();
            return query;
        }

        public List<giangvienVIEW> getList()
        {
            var query = (from a in context.GIANGVIEN
                         select new giangvienVIEW
                         {
                             IDgiangvien = a.IDgiangvien,
                             name = a.name,
                             telephone = a.telephone,
                             address = a.address,
                             birthday = a.birthday,
                             img = a.img,
                             status = a.status,
                         }).ToList();
            return query;
        }
        public List<giangvienVIEW> Search(String name, int status, out int total, int index = 1, int size = 10)
        {
            var query = (from a in context.GIANGVIEN
                         where (a.name.Contains(name) && (a.status == status))
                         select new giangvienVIEW
                         {
                             IDgiangvien = a.IDgiangvien,
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
            GIANGVIEN x = getItem(id);
            context.GIANGVIEN.Remove(x);
            context.SaveChanges();
        }
    }
}
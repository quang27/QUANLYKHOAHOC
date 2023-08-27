using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class lopgiangvienDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(LOPGIANGVIEN item)
        {
            if (item.ID == 0)
            {
                context.LOPGIANGVIEN.Add(item);
            }
            context.SaveChanges();
        }
        public LOPGIANGVIEN getItem(int id)
        {

            return context.LOPGIANGVIEN.Where(x => x.ID == id).FirstOrDefault();
        }
        public lopgiangvienVIEW getItemView(int id)
        {

            var query = (from a in context.LOPGIANGVIEN
                         join b in context.GIANGVIEN on a.IDgiangvien equals b.IDgiangvien
                         join c in context.LOPHOC on a.IDlophoc equals c.IDlophoc
                         where a.ID == id
                         select new lopgiangvienVIEW
                         {
                             ID = a.ID,
                             IDgiangvien = a.IDgiangvien,
                             IDlophoc = a.IDlophoc,
                             giangvien = b.name,
                             lophoc = c.name,                             
                         }).FirstOrDefault();
            return query;
        }

        public List<lopgiangvienVIEW> getList()
        {
            var query = (from a in context.LOPGIANGVIEN
                         join b in context.GIANGVIEN on a.IDgiangvien equals b.IDgiangvien
                         join c in context.LOPHOC on a.IDlophoc equals c.IDlophoc
                         select new lopgiangvienVIEW
                         {
                             ID = a.ID,
                             IDgiangvien = a.IDgiangvien,
                             IDlophoc = a.IDlophoc,
                             giangvien = b.name,
                             lophoc = c.name,
                         }).ToList();
            return query;
        }
        public List<lopgiangvienVIEW> Search(int IDlophoc, out int total, int index = 1, int size = 10)
        {
            var query = (from a in context.LOPGIANGVIEN
                         join b in context.GIANGVIEN on a.IDgiangvien equals b.IDgiangvien
                         join c in context.LOPHOC on a.IDlophoc equals c.IDlophoc
                         where (a.IDlophoc==IDlophoc)
                         select new lopgiangvienVIEW
                         {
                             ID = a.ID,
                             IDgiangvien = a.IDgiangvien,
                             IDlophoc = a.IDlophoc,
                             giangvien = b.name,
                             lophoc = c.name,
                         }).ToList();
            total = query.Count();
            var result = query.Skip((index - 1) * size).Take(size).ToList();
            return result;
        }
        public void Detele(int id)
        {
            LOPGIANGVIEN x = getItem(id);
            context.LOPGIANGVIEN.Remove(x);
            context.SaveChanges();
        }
    }
}
using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class lopsinhvienDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(LOPSINHVIEN item)
        {
            if (item.ID == 0)
            {
                context.LOPSINHVIEN.Add(item);
            }
            context.SaveChanges();
        }
        public LOPSINHVIEN getItem(int id)
        {

            return context.LOPSINHVIEN.Where(x => x.ID == id).FirstOrDefault();
        }
        public lopsinhvienVIEW getItemView(int id)
        {

            var query = (from a in context.LOPSINHVIEN
                         join b in context.SINHVIEN on a.IDsinhvien equals b.IDsinhvien
                         join c in context.LOPHOC on a.IDlophoc equals c.IDlophoc                        
                         where a.ID == id
                         select new lopsinhvienVIEW
                         {
                             ID = a.ID,
                             IDsinhvien = a.IDsinhvien,                           
                             IDlophoc = a.IDlophoc,
                             sinhvien=b.name,
                           
                             lophoc = c.name,
                         }).FirstOrDefault();
            return query;
        }

        public List<lopsinhvienVIEW> getList()
        {
            var query = (from a in context.LOPSINHVIEN
                         join b in context.SINHVIEN on a.IDsinhvien equals b.IDsinhvien
                         join c in context.LOPHOC on a.IDlophoc equals c.IDlophoc
                        
                         select new lopsinhvienVIEW
                         {
                             ID = a.ID,
                             IDsinhvien = a.IDsinhvien,
                             IDlophoc = a.IDlophoc,
                             sinhvien = b.name,
                            
                             lophoc = c.name,
                         }).ToList();
            return query;
        }
        public List<lopsinhvienVIEW> Search(int IDlophoc, out int total, int index = 1, int size = 10)
        {
            var query = (from a in context.LOPSINHVIEN
                         join b in context.SINHVIEN on a.IDsinhvien equals b.IDsinhvien
                         join c in context.LOPHOC on a.IDlophoc equals c.IDlophoc
                        
                         where ((a.IDlophoc == IDlophoc)&&(c.IDlophoc==IDlophoc))
                         select new lopsinhvienVIEW
                         {
                             ID = a.ID,
                             IDsinhvien = a.IDsinhvien,
                             IDlophoc = a.IDlophoc,
                             sinhvien = b.name,
                           
                             lophoc = c.name,
                         }).ToList();
            total = query.Count();
            var result = query.Skip((index - 1) * size).Take(size).ToList();
            return result;
        }
        public void Detele(int id)
        {
            LOPSINHVIEN x = getItem(id);
            context.LOPSINHVIEN.Remove(x);
            context.SaveChanges();
        }
    }
}
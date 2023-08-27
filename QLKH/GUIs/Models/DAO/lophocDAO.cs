using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class lophocDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(LOPHOC item)
        {
            if (item.IDlophoc == 0)
            {
                context.LOPHOC.Add(item);
            }
            context.SaveChanges();
        }
        public LOPHOC getItem(int id)
        {

            return context.LOPHOC.Where(x => x.IDlophoc == id).FirstOrDefault();
        }
        public lophocVIEW getItemView(int id)
        {

            var query = (from a in context.LOPHOC
                         join b in context.KHOAHOC on a.IDkhoahoc equals b.IDkhoahoc
                         where a.IDlophoc == id
                         select new lophocVIEW
                         {

                             IDlophoc = a.IDlophoc,
                             name = a.name,
                             IDkhoahoc = a.IDkhoahoc,
                             start = a.start,
                             finish = a.finish,
                             khoahoc=b.name,                            
                             status = a.status,
                         }).FirstOrDefault();
            return query;
        }

        public List<lophocVIEW> getList()
        {
            var query = (from a in context.LOPHOC
                         join b in context.KHOAHOC on a.IDkhoahoc equals b.IDkhoahoc
                         select new lophocVIEW
                         {
                             IDlophoc = a.IDlophoc,
                             name = a.name,
                             IDkhoahoc = a.IDkhoahoc,
                             start = a.start,
                             finish = a.finish,
                             khoahoc = b.name,
                             status = a.status,
                         }).ToList();
            return query;
        }
        public List<lophocVIEW> Search(String name, int status,int IDkhoahoc, out int total, int index = 1, int size = 10)
        {
            var query = (from a in context.LOPHOC
                         join b in context.KHOAHOC on a.IDkhoahoc equals b.IDkhoahoc
                         where (a.name.Contains(name) && (a.status == status) &&(b.IDkhoahoc== IDkhoahoc))
                         select new lophocVIEW
                         {
                             IDlophoc = a.IDlophoc,
                             name = a.name,
                             IDkhoahoc = a.IDkhoahoc,
                             start = a.start,
                             finish = a.finish,
                             khoahoc = b.name,
                             status = a.status,
                         }).ToList();
            total = query.Count();
            var result = query.Skip((index - 1) * size).Take(size).ToList();
            return result;
        }
        public void Detele(int id)
        {
            LOPHOC x = getItem(id);
            context.LOPHOC.Remove(x);
            context.SaveChanges();
        }
    }
}
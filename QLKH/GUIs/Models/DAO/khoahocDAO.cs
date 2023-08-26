using GUIs.Models.EF;
using GUIs.Models.VIEW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GUIs.Models.DAO
{
    public class khoahocDAO
    {
        private dbContext context = new dbContext();
        public void InsertOrUpdate(KHOAHOC item)
        {
            if (item.IDkhoahoc == 0)
            {
                context.KHOAHOC.Add(item);
            }
            context.SaveChanges();
        }
        public KHOAHOC getItem(int id)
        {

            return context.KHOAHOC.Where(x => x.IDkhoahoc == id).FirstOrDefault();
        }
        public khoahocVIEW getItemView(int id)
        {

            var query = (from a in context.KHOAHOC
                         where a.IDkhoahoc == id
                         select new khoahocVIEW
                         {
                             IDkhoahoc = a.IDkhoahoc,
                             name = a.name,
                             makhoahoc = a.makhoahoc,                           
                             status = a.status,                    
                         }).FirstOrDefault();
            return query;
        }

        public List<khoahocVIEW> getList()
        {
            var query = (from a in context.KHOAHOC
                         select new khoahocVIEW
                         {
                             IDkhoahoc = a.IDkhoahoc,
                             name = a.name,
                             makhoahoc = a.makhoahoc,
                             status = a.status,
                         }).ToList();
            return query;
        }
        public List<khoahocVIEW> Search(String name, int status, out int total, int index = 1, int size = 10)
        {
            var query = (from a in context.KHOAHOC
                         where (a.name.Contains(name) && (a.status == status))
                         select new khoahocVIEW
                         {
                             IDkhoahoc = a.IDkhoahoc,
                             name = a.name,
                             makhoahoc = a.makhoahoc,
                             status = a.status,
                         }).ToList();
            total = query.Count();
            var result = query.Skip((index - 1) * size).Take(size).ToList();
            return result;
        }
        public void Detele(int id)
        {
            KHOAHOC x = getItem(id);
            context.KHOAHOC.Remove(x);
            context.SaveChanges();
        }
    }
}
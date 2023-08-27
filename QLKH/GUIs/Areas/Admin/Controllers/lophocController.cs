using GUIs.Models.DAO;
using GUIs.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    public class lophocController : Controller
    {
        // GET: Admin/lophoc
        public ActionResult Index()
        {
            List<Lopchung> pagesize = new List<Lopchung>();
            pagesize.Add(new Lopchung { ID = 10 });
            pagesize.Add(new Lopchung { ID = 20 });
            pagesize.Add(new Lopchung { ID = 30 });
            pagesize.Add(new Lopchung { ID = 40 });
            pagesize.Add(new Lopchung { ID = 50 });
            ViewBag.Pagesize = pagesize;
            khoahocDAO khoahoc = new khoahocDAO();
            ViewBag.listkhoahoc = khoahoc.getList();
            return View();
        }
        public JsonResult Create(string name, DateTime start, DateTime finish, int IDkhoahoc, int status)
        {

            lophocDAO lophocDAO = new lophocDAO();
            LOPHOC item = new LOPHOC();
            item.name = name;
            item.start = start;
            item.finish = finish;
            item.IDkhoahoc = IDkhoahoc;
            item.status = status;         
            lophocDAO.InsertOrUpdate(item);
            return Json(new { mess = "Thêm lớp học thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(int id, string name, DateTime start, DateTime finish, int IDkhoahoc, int status)
        {

            lophocDAO lophocDAO = new lophocDAO();
            var item = lophocDAO.getItem(id);
            item.name = name;
            item.start = start;
            item.finish = finish;
            item.IDkhoahoc = IDkhoahoc;
            item.status = status;
            lophocDAO.InsertOrUpdate(item);
            return Json(new { mess = "Chỉnh sửa lớp học thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowList(string name = "",int IDkhoahoc=1, int status = 1, int index = 1, int size = 10)
        {

            lophocDAO lophoc = new lophocDAO();
            int total = 0;

            var query = lophoc.Search(name, status, IDkhoahoc, out total, index, size);
            string text = "";

            foreach (var item in query)
            {
                text += "<tr>";
                text += "<td>" + item.IDlophoc + "</td>";
                text += "<td>" + item.name + "</td>";
                text += "<td>" + item.start + "</td>";
                text += "<td>" + item.finish + "</td>";
                text += "<td>" + item.khoahoc + "</td>";
                text += "<td>" + item.status + "</td>";              
                text += "<td>" +
                    "<a href='javacript:void(0)' data-toggle='modal' data-target='#update' data-whatever='" + item.IDlophoc + "'><i class='fa fa-edit'></i></a>" + "";

                text += " <a href='/Admin/lophoc/Delete/" + item.IDlophoc + "'><i class='fa fa-trash' aria-hidden='true'></i> </a></td>";
                text += "</tr>";
            }
            string page = Support.Support.InTrang(total, index, size);
            return Json(new { data = text, page = page }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            lophocDAO lophoc = new lophocDAO();
            lophoc.Detele(id);
            return RedirectToAction("Index");
        }
        public JsonResult getLophoc(int id)
        {
            lophocDAO lophoc = new lophocDAO();

            var query = lophoc.getItemView(id);

            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
    }
}
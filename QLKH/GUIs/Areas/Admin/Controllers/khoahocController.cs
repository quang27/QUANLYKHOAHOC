using GUIs.Models.DAO;
using GUIs.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    public class Lopchung
    {
        public int ID { set; get; }
        public string Name { set; get; }
    }
    public class khoahocController : Controller
    {
        // GET: Admin/khoahoc
        public ActionResult Index()
        {
            List<Lopchung> pagesize = new List<Lopchung>();
            pagesize.Add(new Lopchung { ID = 10 });
            pagesize.Add(new Lopchung { ID = 20 });
            pagesize.Add(new Lopchung { ID = 30 });
            pagesize.Add(new Lopchung { ID = 40 });
            pagesize.Add(new Lopchung { ID = 50 });
            ViewBag.Pagesize = pagesize;
            return View();
        }
        public JsonResult Create(string name,string makhoahoc, int status)
        {

            khoahocDAO khoahoc = new khoahocDAO();
            KHOAHOC item = new KHOAHOC();
            if (khoahoc.Kiemtra(makhoahoc) == true)
            {
                item.name = name;
                item.makhoahoc = makhoahoc;
                item.status = status;
                khoahoc.InsertOrUpdate(item);
                return Json(new { mess = "Thêm khóa học thành công" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { mess = "Thêm khóa học không thành công" }, JsonRequestBehavior.AllowGet);
        }

       
        public JsonResult Update(int id, string name, string makhoahoc, int status)
        {

            khoahocDAO khoahoc = new khoahocDAO();
            var item = khoahoc.getItem(id);
            item.name = name;
            item.makhoahoc = makhoahoc;
            item.status = status;
            khoahoc.InsertOrUpdate(item);
            return Json(new { mess = "Chỉnh sửa khóa học thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowList(string name = "", int status = 1, int index = 1, int size = 10)
        {

            khoahocDAO khoahoc = new khoahocDAO();
            int total = 0;

            var query = khoahoc.Search(name, status, out total, index, size);
            string text = "";

            foreach (var item in query)
            {
                text += "<tr>";
                text += "<td>" + item.IDkhoahoc + "</td>";
                text += "<td>" + item.name + "</td>";
                text += "<td>" + item.makhoahoc + "</td>";
                text += "<td>" + item.status + "</td>";
                

                text += "<td>" +
                    "<a href='javacript:void(0)' data-toggle='modal' data-target='#update' data-whatever='" + item.IDkhoahoc + "'><i class='fa fa-edit'></i></a>" + "";

                text += " <a href='/Admin/khoahoc/Delete/" + item.IDkhoahoc + "'><i class='fa fa-trash' aria-hidden='true'></i> </a></td>";
                text += "</tr>";
            }
            string page = Support.Support.InTrang(total, index, size);
            return Json(new { data = text, page = page }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            khoahocDAO x = new khoahocDAO();
            x.Detele(id);
            return RedirectToAction("Index");
        }
        public JsonResult getKhoahoc(int id)
        {
            khoahocDAO khoahoc = new khoahocDAO();

            var query = khoahoc.getItemView(id);
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
    }
}
using GUIs.Models.DAO;
using GUIs.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    public class lopsinhvienController : Controller
    {
        // GET: Admin/lopsinhvien
        public ActionResult Index()
        {
            List<Lopchung> pagesize = new List<Lopchung>();
            pagesize.Add(new Lopchung { ID = 10 });
            pagesize.Add(new Lopchung { ID = 20 });
            pagesize.Add(new Lopchung { ID = 30 });
            pagesize.Add(new Lopchung { ID = 40 });
            pagesize.Add(new Lopchung { ID = 50 });
            ViewBag.Pagesize = pagesize;
            lophocDAO lophoc=new lophocDAO();
            ViewBag.listlophoc = lophoc.getList();
            sinhvienDAO sinhvien=new sinhvienDAO();
            ViewBag.listsinhvien=sinhvien.getList();
            return View();
        }
        public JsonResult Create(int IDsinhvien, int  IDlophoc)
        {

           lopsinhvienDAO lopsinhvien=new lopsinhvienDAO(); 
            LOPSINHVIEN item = new LOPSINHVIEN();
            item.IDsinhvien = IDsinhvien;
            item.IDlophoc = IDlophoc;
           
            lopsinhvien.InsertOrUpdate(item);
            return Json(new { mess = "Thêm sinh viên vào lớp thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(int id, int IDsinhvien, int IDlophoc)
        {

            lopsinhvienDAO lopsinhvien = new lopsinhvienDAO();
            var item = lopsinhvien.getItem(id);
            item.IDsinhvien = IDsinhvien;
            item.IDlophoc = IDlophoc;

            lopsinhvien.InsertOrUpdate(item);
            return Json(new { mess = "Chỉnh sửa sinh viên trong lớp thành công" }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            lopsinhvienDAO lopsinhvien = new lopsinhvienDAO();
            lopsinhvien.Detele(id);
            return RedirectToAction("Index");
        }
        public JsonResult getLopsinhvien(int id)
        {
            lopsinhvienDAO lopsinhvien = new lopsinhvienDAO();
            var query = lopsinhvien.getItemView(id);
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowList(int IDlophoc, int index = 1, int size = 10)
        {

            lopsinhvienDAO lopsinhvien = new lopsinhvienDAO();
            int total = 0;

            var query = lopsinhvien.Search(IDlophoc, out total, index, size);
            string text = "";

            foreach (var item in query)
            {
                text += "<tr>";
                text += "<td>" + item.ID + "</td>";
                text += "<td>" + item.sinhvien + "</td>";
                text += "<td>" + item.lophoc + "</td>";
                            
                text += "<td>" +
                    "<a href='javacript:void(0)' data-toggle='modal' data-target='#update' data-whatever='" + item.ID + "'><i class='fa fa-edit'></i></a>" + "";

                text += " <a href='/Admin/lopsinhvien/Delete/" + item.ID + "'><i class='fa fa-trash' aria-hidden='true'></i> </a></td>";
                text += "</tr>";
            }
            string page = Support.Support.InTrang(total, index, size);
            return Json(new { data = text, page = page }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult getName(int id)
        {
            sinhvienDAO sinhvien = new sinhvienDAO();   
            var query = sinhvien.getItemView(id);
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }

    }
}
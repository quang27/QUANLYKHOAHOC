using GUIs.Models.DAO;
using GUIs.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    public class lopgiangvienController : Controller
    {
        // GET: Admin/lopgiangvien
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
            giangvienDAO giangvienDAO = new giangvienDAO(); 
            ViewBag.listgiangvien= giangvienDAO.getList();
            return View();
        }
        public JsonResult Create(int IDgiangvien, int IDlophoc)
        {

            lopgiangvienDAO lopgiangvien = new lopgiangvienDAO();
            LOPGIANGVIEN item = new LOPGIANGVIEN();
            item.IDgiangvien = IDgiangvien;
            item.IDlophoc = IDlophoc;           
            lopgiangvien.InsertOrUpdate(item);
            return Json(new { mess = "Thêm giảng viên vào lớp thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(int id, int IDgiangvien, int IDlophoc)
        {

            lopgiangvienDAO lopgiangvien = new lopgiangvienDAO();
            var item = lopgiangvien.getItem(id);
            item.IDgiangvien = IDgiangvien;
            item.IDlophoc = IDlophoc;
            lopgiangvien.InsertOrUpdate(item);
            return Json(new { mess = "Chỉnh sửa giảng viên trong lớp thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowList(int IDlophoc, int index = 1, int size = 10)
        {

            lopgiangvienDAO lopgiangvien = new lopgiangvienDAO();
            int total = 0;

            var query = lopgiangvien.Search(IDlophoc, out total, index, size);
            string text = "";

            foreach (var item in query)
            {
                text += "<tr>";
                text += "<td>" + item.ID + "</td>";
                text += "<td>" + item.giangvien + "</td>";
                text += "<td>" + item.lophoc + "</td>";
                            
                text += "<td>" +
                    "<a href='javacript:void(0)' data-toggle='modal' data-target='#update' data-whatever='" + item.ID + "'><i class='fa fa-edit'></i></a>" + "";

                text += " <a href='/Admin/lopgiangvien/Delete/" + item.ID + "'><i class='fa fa-trash' aria-hidden='true'></i> </a></td>";
                text += "</tr>";
            }
            string page = Support.Support.InTrang(total, index, size);
            return Json(new { data = text, page = page }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            lopgiangvienDAO lopgiangvien = new lopgiangvienDAO();
            lopgiangvien.Detele(id);
            return RedirectToAction("Index");
        }
        public JsonResult getLopgiangvien(int id)
        {
            lopgiangvienDAO lopgiangvien = new lopgiangvienDAO();

            var query = lopgiangvien.getItemView(id);
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
    }
}
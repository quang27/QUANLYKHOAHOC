using GUIs.Models.DAO;
using GUIs.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GUIs.Areas.Admin.Controllers
{
    public class sinhvienController : Controller
    {
        // GET: Admin/sinhvien
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
        public JsonResult Create(string name, string telephone, string address, DateTime birthday,string img,int status)
        {

            sinhvienDAO sinhvien = new sinhvienDAO();
            SINHVIEN item = new SINHVIEN();
            item.name = name;
            item.telephone = telephone;
            item.address = address;
            item.birthday = birthday;
            item.img = img;
            item.status = status;
            sinhvien.InsertOrUpdate(item);
            return Json(new { mess = "Thêm sinh viên thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(int id, string name, string telephone, string address, DateTime birthday, string img, int status)
        {

            sinhvienDAO sinhvien = new sinhvienDAO();
            var item = sinhvien.getItem(id);
            item.name = name;
            item.telephone = telephone;
            item.address = address;
            item.birthday = birthday;
            item.img = img;
            item.status = status;
            sinhvien.InsertOrUpdate(item);
            return Json(new { mess = "Chỉnh sửa sinh viên thành công" }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ShowList(string name = "", int status = 1, int index = 1, int size = 10)
        {

            sinhvienDAO sinhvien = new sinhvienDAO();
            int total = 0;

            var query = sinhvien.Search(name, status, out total, index, size);
            string text = "";

            foreach (var item in query)
            {
                text += "<tr>";
                text += "<td>" + item.IDsinhvien + "</td>";
                text += "<td>" + item.name + "</td>";
                text += "<td>" + item.telephone + "</td>";
                text += "<td>" + item.address + "</td>";
                text += "<td>" + item.birthday + "</td>";
                text += "<td>" + item.status + "</td>";
                text += "<td> <img src='" + item.img + "' style='width:40px;height:40px;' class='img-profile rounded-circle'/></td>";
                text += "<td>" +
                    "<a href='javacript:void(0)' data-toggle='modal' data-target='#update' data-whatever='" + item.IDsinhvien + "'><i class='fa fa-edit'></i></a>" + "";

                text += " <a href='/Admin/nhanvien/Delete/" + item.IDsinhvien + "'><i class='fa fa-trash' aria-hidden='true'></i> </a></td>";
                text += "</tr>";
            }
            string page = Support.Support.InTrang(total, index, size);
            return Json(new { data = text, page = page }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            sinhvienDAO sinhvien = new sinhvienDAO();
            sinhvien.Detele(id);
            return RedirectToAction("Index");
        }
        public JsonResult getSinhvien(int id)
        {
            sinhvienDAO sinhvien = new sinhvienDAO();

            var query = sinhvien.getItemView(id);
            return Json(new { data = query }, JsonRequestBehavior.AllowGet);
        }
    }
}
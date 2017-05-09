using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Tokenizer.Symbols;

using Model.DAO;
using Model.EF;

using PagedList;

using TimeKeeping.Common;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class NhanVienController : BaseController
    {
        private NhanVienDAO dao = new NhanVienDAO();
        
        // GET: Admin/TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List(string query, int page = 1, int pageSize = 10)
        {
            return Json(dao.GetListNhanVien(query, page, pageSize).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListChucVu()
        {
            var cv = new ChucVuDAO();
            return Json(cv.GetListChucVu(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListPhongBan()
        {
            var cv = new PhongBanDAO();
            return Json(cv.GetListPhongBan(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListHeSoLuong()
        {
            var cv = new LuongDAO();
            return Json(cv.GetListLuong(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(NhanVien pb)
        {
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByNhanVienID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(NhanVien pb)
        {
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(long ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/NhanVien
        //public ActionResult Index(string keyword, int page = 1, int pageSize = 10)
        //{
        //    var lstNhanVien = db.GetListNhanVien(keyword, page, pageSize);
        //    ViewBag.SearchString = keyword;
        //    return View((IPagedList<ViewNhanVien>)lstNhanVien);
        //}

        //public ActionResult Edit(long id)
        //{
        //    var nv = db.GetByNhanVienID(id);
        //    SetViewBagChucVu(nv.IDChucVu);
        //    SetViewBagLuong(nv.IDHeSoLuong);
        //    SetViewBagPhongBan(nv.IDPhongBan);
        //    return View(nv);
        //}

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    SetViewBagChucVu();
        //    SetViewBagLuong();
        //    SetViewBagPhongBan();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(NhanVien acc)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (db.Insert(acc))
        //        {
        //            return RedirectToAction("Index", "NhanVien");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Thêm mới thất bại");
        //        }
        //    }
        //    SetViewBagChucVu();
        //    SetViewBagLuong();
        //    SetViewBagPhongBan();
        //    return View("Create");
        //}

        //[HttpDelete]
        //public ActionResult Delete(long id)
        //{
        //    db.Delete(id);
        //    return RedirectToAction("Index");
        //}

        //public ActionResult Update(NhanVien nv)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (db.Update(nv))
        //        {
        //            return RedirectToAction("Index", "NhanVien");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Cập nhật thất bại");
        //        }
        //    }
        //    SetViewBagChucVu(nv.IDChucVu);
        //    SetViewBagLuong(nv.IDHeSoLuong);
        //    SetViewBagPhongBan(nv.IDPhongBan);
        //    return View("Edit");
        //}

        //private void SetViewBagChucVu(int? selected = null)
        //{
        //    ChucVuDAO dao = new ChucVuDAO();
        //    ViewBag.IDChucVu = new SelectList(dao.GetListChucVu(), "ID", "TenChucVu", selected);
        //}

        //private void SetViewBagPhongBan(int? selected = null)
        //{
        //    PhongBanDAO dao = new PhongBanDAO();
        //    ViewBag.IDPhongBan = new SelectList(dao.GetListPhongBan(), "ID", "TenPhongBan", selected);
        //}

        //private void SetViewBagLuong(int? selected = null)
        //{
        //    LuongDAO dao = new LuongDAO();
        //    ViewBag.IDHeSoLuong = new SelectList(dao.GetListLuong(), "ID", "HeSoLuong", selected);
        //}
    }
}

using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeKeeping.Common;
using PagedList;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        TaiKhoanDAO dao = new TaiKhoanDAO();
        // GET: Admin/TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Index(string keyword,int page = 1, int pageSize = 10)
        //{
        //    var lstTaiKhoan = dao.GetListTaiKhoan(keyword,page, pageSize);
        //    ViewBag.SearchString = keyword;
        //    return View((IPagedList<ViewTaiKhoan>)lstTaiKhoan);
        //}
        public JsonResult List(string query, int page = 1, int pageSize = 10)
        {
            return Json(dao.GetListTaiKhoan(query, page,pageSize).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListQuyen()
        {
            var x = new QuyenDAO();
            return Json(x.GetListQuyen(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListNhanVien()
        {
            var x = new NhanVienDAO();
            return Json(x.GetListNhanVien(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(TaiKhoan pb)
        {
            pb.MatKhau = Encryptor.MD5Hash(pb.MatKhau);
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByTaiKhoanID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(TaiKhoan pb)
        {
            pb.MatKhau = Encryptor.MD5Hash(pb.MatKhau);
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }

    }
}
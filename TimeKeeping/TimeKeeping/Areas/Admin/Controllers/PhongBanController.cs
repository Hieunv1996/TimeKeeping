using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model.DAO;
using Model.EF;

using PagedList;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class PhongBanController : BaseController
    {
        private PhongBanDAO dao = new PhongBanDAO();
        // GET: Admin/PhongBan
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult List(string keyword = "", int page = 1, int pageSize = 5)
        //{
        //    var lstNhanVien = dao.GetListPhongBan(keyword, page, pageSize);
        //    ViewBag.SearchString = keyword;
        //    return Json(lstNhanVien.ToList(), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult List(string query = "", int page = 1, int pageSize = 5)
        {
            return Json(dao.GetListPhongBan(query,page,pageSize).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(PhongBan pb)
        {
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByPhongBanID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(PhongBan pb)
        {
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}
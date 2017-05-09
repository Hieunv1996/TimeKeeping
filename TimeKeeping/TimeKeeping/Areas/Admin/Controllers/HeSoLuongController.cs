using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model.DAO;
using Model.EF;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class HeSoLuongController : BaseController
    {
        private LuongDAO dao = new LuongDAO();
        // GET: Admin/Luong
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List(string query, int page = 1, int pageSize = 10)
        {
            return Json(dao.GetListLuong(query, page, pageSize).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Luong pb)
        {
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByLuongID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Luong pb)
        {
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}
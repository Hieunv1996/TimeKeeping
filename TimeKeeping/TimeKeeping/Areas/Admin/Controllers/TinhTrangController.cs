using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model.DAO;
using Model.EF;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class TinhTrangController : BaseController
    {
        private TinhTrangDAO dao = new TinhTrangDAO();
        // GET: Admin/TinhTrang
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List(string query, int page = 1, int pageSize = 10)
        {
            return Json(dao.GetListTinhTrang(query, page, pageSize).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(TinhTrang pb)
        {
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByTinhTrangID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(TinhTrang pb)
        {
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}
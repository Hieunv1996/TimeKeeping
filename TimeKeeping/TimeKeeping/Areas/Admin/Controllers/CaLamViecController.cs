using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model.DAO;
using Model.EF;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class CaLamViecController : BaseController
    {
        private CaLamViecDAO dao = new CaLamViecDAO();
        // GET: Admin/CaLamViec
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List(string query, int page = 1, int pageSize = 10)
        {
            return Json(dao.GetListCaLamViec(query,page,pageSize).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(CaLamViec pb)
        {
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByCaLamViecID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(CaLamViec pb)
        {
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}
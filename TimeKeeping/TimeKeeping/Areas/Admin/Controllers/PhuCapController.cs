using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model.DAO;
using Model.EF;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class PhuCapController : Controller
    {
        PhuCapDAO dao = new PhuCapDAO();
        // GET: Admin/PhuCap
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ListChucVu()
        {
            var cv = new ChucVuDAO();
            return Json(cv.GetListChucVu(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult List(string query, int page = 1, int pageSize = 10)
        {
            return Json(dao.GetListPhuCap(query, page, pageSize), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(PhuCap pb)
        {
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByPhuCapID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(PhuCap pb)
        {
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}
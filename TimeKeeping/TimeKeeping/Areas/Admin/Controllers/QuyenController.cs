using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model.DAO;
using Model.EF;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class QuyenController : BaseController
    {
        QuyenDAO dao = new QuyenDAO();
        // GET: Admin/Quyen
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List(string query, int page = 1, int pageSize = 10)
        {
            return Json(dao.GetListQuyen(query, page, pageSize).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(Quyen pb)
        {
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByQuyenID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Quyen pb)
        {
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}
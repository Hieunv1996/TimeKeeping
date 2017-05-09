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
    public class ChucVuController : BaseController
    {
        private ChucVuDAO dao = new ChucVuDAO();

        // GET: Admin/NhanVien
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index(string keyword, int page = 1, int pageSize = 10)
        //{
        //    var listChucVu = db.GetListChucVu(keyword, page, pageSize);
        //    ViewBag.SearchString = keyword;
        //    return View((IPagedList<ChucVu>)listChucVu);
        //}

        public JsonResult List(string query, int page = 1, int pageSize = 10)
        {
            return Json(dao.GetListChucVu(query,page,pageSize), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(ChucVu pb)
        {
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByChucVuID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ChucVu pb)
        {
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}
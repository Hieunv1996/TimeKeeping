using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Model.DAO;
using Model.EF;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class ThuongPhatController : Controller
    {
        private ThuongPhatDAO dao = new ThuongPhatDAO();
        // GET: Admin/ThuongPhat
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ListNhanVien()
        {
            var x = new NhanVienDAO();
            return Json(x.GetListNhanVien(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult List(string query, int page = 1, int pageSize = 10)
        {
            return Json(dao.GetListThuongPhat(query, page, pageSize).ToList(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(ThuongPhat pb)
        {
            return Json(dao.Insert(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var pb = dao.GetByThuongPhatID(ID);
            return Json(pb, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ThuongPhat pb)
        {
            return Json(dao.Update(pb), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(dao.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}
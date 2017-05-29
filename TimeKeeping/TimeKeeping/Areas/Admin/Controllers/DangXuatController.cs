using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using TimeKeeping.Common;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class DangXuatController : Controller
    {

        public ActionResult Logout()
        {
            TempData[CommonConstants.ADMIN_SESSION] = null;
            return RedirectToAction("Index", "DangNhap");
        }
    }
}
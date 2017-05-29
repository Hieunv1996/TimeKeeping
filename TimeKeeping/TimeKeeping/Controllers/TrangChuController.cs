using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeKeeping.Controllers
{
    public class TrangChuController : BaseController
    {
        // GET: TrangChu
        public ActionResult Index()
        {
            return View();
        }
    }
}
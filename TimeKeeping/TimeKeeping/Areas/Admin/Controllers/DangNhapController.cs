using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TimeKeeping.Areas.Admin.Models;
using TimeKeeping.Common;

namespace TimeKeeping.Areas.Admin.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginValid(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var result = dao.LoginValid(model.Username, Encryptor.MD5Hash(model.Password),true);
                if (result)
                {
                    var user = dao.GetByUsername(model.Username);
                    if (user.TinhTrang == false)
                    {
                        ModelState.AddModelError("", "Tài khoản đã bị vô hiệu hóa");
                    }
                    else
                    {
                        var adminSession = new UserLogin();
                        adminSession.Username = user.TenDangNhap;
                        adminSession.UserID = user.IDNhanVien;
                        Session.Add(CommonConstants.ADMIN_SESSION, adminSession);
                        return RedirectToAction("Index", "TrangChu");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
            }
            return View("Index");
        }
////        public ActionResult Logout()
////        {
////            Session.Remove(CommonConstants.ADMIN_SESSION);
////            return RedirectToAction("Index", "DangNhap");
////        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BotDetect.Web.Mvc;

using Model.DAO;
using TimeKeeping.Common;
using TimeKeeping.Models;

namespace TimeKeeping.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "loginCaptcha", "Sai mã xác nhận!")]
        public ActionResult LoginValid(DangNhapModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new TaiKhoanDAO();
                var result = dao.LoginValid(model.Username, Encryptor.MD5Hash(model.Password));
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
                        Session.Add(CommonConstants.USER_SESSION, adminSession);
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
    }
}
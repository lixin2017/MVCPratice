using Luna.Areas.Member.Models;
using Luna.BLL;
using Luna.Common;
using Luna.IBLL;
using Luna.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Drawing;
using System.Web;
using System.Web.Mvc;



namespace Luna.Areas.Member.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private InterfaceUserService userService;
        public UserController() { userService = new UserService(); }

        // GET: Member/User
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult VerificationCode()
        {
            string verificationCode = Security.CreateVerificationText(6);
            Bitmap _img = Security.CreateVerificationImage(verificationCode, 200, 40);
            _img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            TempData["VerificationCode"] = verificationCode.ToUpper();
            return null;
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel register)
        {
            if (TempData["VerificationCode"] == null || TempData["VerificationCode"].ToString() != register.VerificationCode.ToUpper())
            {
                ModelState.AddModelError("VerificationCode", "验证码不正确");
                return View(register);
            }
            if (ModelState.IsValid)
            {

                if (userService.Exist(register.UserName)) ModelState.AddModelError("UserName", "用户名已存在");
                else
                {
                    User _user = new User()
                    {
                        UserName = register.UserName,
                        //默认用户组代码写这里
                        DisplayName = register.DisplayName,
                        PassWord = Security.Sha256(register.Password),
                        //邮箱验证与邮箱唯一性问题
                        Email = register.Email,
                        //用户状态问题
                        Status = 0,
                        RegistrationTime = System.DateTime.Now
                    };
                    _user = userService.Add(_user);
                    if (_user.UserID > 0)
                    {
                        var _identity = userService.CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignIn(_identity);
                        return RedirectToAction("Index", "Home");
                    }
                    else { ModelState.AddModelError("", "注册失败！"); }
                }
            }
            return View(register);
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel loginModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var _user = userService.Find(loginModel.UserName);
                if (_user == null) ModelState.AddModelError("UserName", "用戶不存在");
                else if (_user.PassWord == Common.Security.Sha256(loginModel.PassWord))
                {
                    _user.LoginTime = DateTime.Now;
                    _user.LoginIP = Request.UserHostAddress;
                    userService.Update(_user);
                    var _identity = userService.CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = loginModel.RememberMe }, _identity);
                    if (string.IsNullOrEmpty(returnUrl)) return RedirectToAction("Index", "Home");
                    else if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("Password", "密码错误");
            }
            return View();
        }

        #region 属性
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        #endregion

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Redirect(Url.Content("~/"));
        }

        public ActionResult Menu()
        {
            return PartialView();
        }

        public ActionResult Details()
        {
            return View(userService.Find(User.Identity.Name));
        }

        public ActionResult UserGroup()
        {
            return PartialView();
        }

        public ActionResult Modify()
        {
            var _user = userService.Find(User.Identity.Name);
            if (_user == null) ModelState.AddModelError("UserName", "用戶不存在");
            else
            {
                if (TryUpdateModel(_user, new string[] { "DisplayName", "Email" }))
                {
                    if (ModelState.IsValid)
                    {
                        if (userService.Update(_user)) ModelState.AddModelError("", "修改成功");
                        else ModelState.AddModelError("", "无需要修改的资料");
                    }
                }
                else ModelState.AddModelError("", "修改失败");
            }
            return View("Details", _user);

        }

        public ActionResult UserList()
        {
            int totalRecord;
            var list = userService.FindPageList(1, 10,out totalRecord,0);           
            ViewBag.totalRecord = totalRecord;
            return View(list);
        }
    }
}
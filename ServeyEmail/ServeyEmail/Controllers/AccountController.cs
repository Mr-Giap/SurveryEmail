using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValueObjects;
using BusinessLogicLayer.BLL;
namespace ServeyEmail.Controllers
{
    public class AccountController : Controller
    {
         
        // GET: Logins
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(OUsers user)
        {
            OUsers u = new OUsers();
            UserBLL userBLL = new UserBLL();
            u = userBLL.Checklogin(user);
            if(u==null)
            {
                return View();
            }
            Session.Add(CommonConstant.SESSION_ACCOUNT,u);
            ViewBag.UserName = u.UserName;
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session["SESSION_ACCOUNT"] = null;
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Register()
        {
            GroupBLL grBLL = new GroupBLL();
            SelectList listGr = new SelectList(grBLL.Getall(), "IdGroup", "Name");
            ViewBag.listGr = listGr;
            RoleBLL roleBLL = new RoleBLL();
            SelectList listRole = new SelectList(roleBLL.Getall(), "IdRole", "Name");
            ViewBag.listRole = listRole;
            return View();
        }
        [HttpPost]
        public ActionResult Register(OUsers user)
        {
            UserBLL userBLL = new UserBLL();
            if(userBLL.Insert(user))
            {
                return RedirectToAction("Success", "Account");
            }
            return View();
        }
        public ActionResult RegisterSuccess()
        {
            return View();
        }
    }
}
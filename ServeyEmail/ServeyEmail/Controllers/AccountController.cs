﻿using System;
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
            if (u.UserName == null)
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                return View();
            }
            Session.Add(CommonConstant.SESSION_ACCOUNT, u);
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
            ViewBag.listRole = listRole.Where(p => p.Value == "2").First().Text;
            return View();
        }
        [HttpPost]
        public ActionResult Register(OUsers user)
        {
            UserBLL userBLL = new UserBLL();      
            user.IdUser = Guid.NewGuid();
            user.IdRole = 2;
            if (userBLL.Insert(user))
            {
                return RedirectToAction("Login", "Account");
            }

            return View(user);
        }
    }
}
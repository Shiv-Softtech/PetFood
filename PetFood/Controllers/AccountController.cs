using AutoMapper;
using PetFood.Entity;
using PetFood.Models;
using PetFood.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetFood.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public JsonResult InsertUser(UserModel UserData)
        {
            var userDetail = Mapper.Map<UserModel, User>(UserData);
            var users = _userService.InsertUser(userDetail);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult LoginAuth(UserModel LoginData)
        {
            var userDetail = Mapper.Map<UserModel, User>(LoginData);
            var users = _userService.LoginAuth(userDetail);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

    }
}
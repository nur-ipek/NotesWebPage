using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Notes.BusinessLogicLayer;
using Notes.Entities;
using Notes.WebApp.ViewModels;

namespace Notes.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Test test = new Test();
            //test.InsertTest();
            NoteManager noteManager = new NoteManager();
            return View(noteManager.GetListNote().OrderByDescending(x=> x.CreatedOn).ToList());
        }
        public ActionResult ByCategory(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            CategoryManager categoryManager = new CategoryManager();
            Category category = categoryManager.GetCategoryById(id);
            if(category == null)
            {
                return HttpNotFound();
            }
            return View("Index", category.Notes.OrderByDescending(x=>x.CreatedOn).ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            
            if (ModelState.IsValid)
            {
                UserManager userManager = new UserManager();
                BusinessLayerResult<User> res = userManager.LoginUser(loginViewModel);
                if (res.Errors.Count > 0)
                {
                    if(res.Errors.Find(x => x.Code == Entities.Messages.ErrorMessageCode.UserIsNotActive) != null)
                    {
                        ViewBag.SetLink = "http://Home/Activate/123-4567-78980";
;                    }
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(loginViewModel);
                }
                Session["login"] = res.Result;
                return RedirectToAction("Index");
            }
          
            return View(loginViewModel);
        }
        public ActionResult Logout()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        } 
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                UserManager userManager = new UserManager();
                BusinessLayerResult<User> res=  userManager.RegisterUser(registerViewModel);

                if(res.Errors.Count >0 )
                {
                    res.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                    return View(registerViewModel);
                }

                return RedirectToAction("RegisterOk");
            }
            return View(registerViewModel);
        }

        public ActionResult RegisterOk()
        {
            return View();
        }
    }
}
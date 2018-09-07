using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthyBalance.Models.View;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HealthyBalance.Models.Data;
using Newtonsoft.Json;
using HealthyBalance.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthyBalance.Controllers
{

    public class BalanceController : Controller
    {
        private DietControllerContext context;
        public BalanceController(DietControllerContext context)
        {
            this.context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            SelectList lifestyles = MyExtensions.ToSelectList<Lifestyle>();
            SelectList genderList = MyExtensions.ToSelectList<Gender>();
            UserViewModel viewModel = new UserViewModel();
            viewModel.Lifestyles = lifestyles;
            viewModel.GenderList = genderList;
            viewModel.Gender = Gender.Female;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SignUp(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = context.User.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser == null)
                {
                    User newUser = new User();
                    newUser.Id = user.ID;
                    newUser.FirstName = user.FirstName;
                    newUser.LastName = user.LastName;
                    newUser.Email = user.Email;
                    newUser.Password = user.Password;
                    newUser.DateOfBirth = user.DateOfBirth;
                    newUser.Gender = (int)user.Gender;
                    newUser.Weight = user.Weight;
                    newUser.Length = user.Length;
                    newUser.Athletic = user.Athletic;
                    newUser.Lifestyle = (int)user.Lifestyle;
                    //context.User.Add(newUser);
                    //context.SaveChanges();

                    ModelState.Clear();
                    ViewBag.Message = user.FirstName + " " + user.LastName + " successfully registered.";
                }
                else
                {
                    ModelState.Clear();
                    ViewBag.Message = "WARNIGN!!! User with e-mail: " + user.Email + " allready exists!";
                }
            }

            SelectList lifestyles = MyExtensions.ToSelectList<Lifestyle>();
            SelectList genderList = MyExtensions.ToSelectListWithDefault<Gender>(Gender.Female);
            user.Lifestyles = lifestyles;
            user.GenderList = genderList;

            return View(user);
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(UserViewModel user)
        {
            var existingUser = context.User.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (existingUser != null)
            {
                user.ID = existingUser.Id;
                user.FirstName = existingUser.FirstName;
                user.LastName = existingUser.LastName;
                user.Email = existingUser.Email;
                user.Password = existingUser.Password;
                user.DateOfBirth = existingUser.DateOfBirth;
                user.Gender = (Gender)existingUser.Gender;
                user.Weight = (float)existingUser.Weight;
                user.Length = existingUser.Length;
                user.Athletic = existingUser.Athletic;
                user.Lifestyle = (Lifestyle)existingUser.Lifestyle;

                HttpContext.Session.SetString("LoggedInUser", JsonConvert.SerializeObject(user));
                return RedirectToAction("MyPage");
            }
            else
            {
                ModelState.AddModelError("", "Email or password is wrong.");
            }

            return View();
        }

        public IActionResult LogOut()
        {
            if (HttpContext.Session.Keys.Contains("LoggedInUser"))
            {
                HttpContext.Session.Clear();
            }
            return RedirectToAction("Index");
        }

        public IActionResult MyProfile()
        {
            if (HttpContext.Session.Keys.Contains("LoggedInUser"))
            {
                UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(HttpContext.Session.GetString("LoggedInUser"));
                SelectList lifestyles = MyExtensions.ToSelectList<Lifestyle>();
                SelectList genderList = MyExtensions.ToSelectList<Gender>();
                user.Lifestyles = lifestyles;
                user.GenderList = genderList;

                return View(user);
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        [HttpPost]
        public IActionResult MyProfile(int id, UserViewModel user)
        {
            var existingUser = context.User.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Id = user.ID;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Password = user.Password;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Gender = (int)user.Gender;
                existingUser.Weight = user.Weight;
                existingUser.Length = user.Length;
                existingUser.Athletic = user.Athletic;
                existingUser.Lifestyle = (int)user.Lifestyle;

                context.SaveChanges();

                ViewBag.Message = "Profile successfully updated.";

                HttpContext.Session.SetString("LoggedInUser", JsonConvert.SerializeObject(user));
            }

            return RedirectToAction("MyProfile");
        }

        public IActionResult MyPage()
        {
            return View();
        }

        public IActionResult MyActivity()
        {
            if (HttpContext.Session.Keys.Contains("LoggedInUser"))
            {
                UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(HttpContext.Session.GetString("LoggedInUser"));
                ActivityLogViewModel viewModel = new ActivityLogViewModel();
                viewModel.UserId = user.ID;
                viewModel.ActivityList= new SelectList(context.Activity, "Id", "Name");

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("LogIn");
            }
        }

        public IActionResult MyFoodIntake()
        {

            ActivityLogViewModel viewModel = new ActivityLogViewModel();
            return View(viewModel);
        }


        /*
        // GET: Balance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Balance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Balance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Balance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Balance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Balance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Balance/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        */
    }
}
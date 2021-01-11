using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Models;

namespace Restaurants.Controllers
{
    public class HomeController : Controller
    {
        private Context databases {get;set;}
        public HomeController(Context context)
        {
            databases = context;
        }

        ////////////////////////////////////////////////////////////////Login Logout

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("dish/add")]
        public IActionResult DishAdd()
        {
            return View();
        }
        [Route("menu")]
        public IActionResult Menu()
        {
            ViewBag.Dishes= databases.Dishes.ToList();
            return View();
        }

        [Route("dish/edit/{id}")]
        public IActionResult Edit(int id)
        {   
            Dish a = databases.Dishes.FirstOrDefault(d => d.DishId == id);
            return View("DishEdit",a);
        }
        [Route("dish/remove/{id}")]
        public IActionResult delete(int id)
        {
            databases.Dishes.Remove(
                databases.Dishes.FirstOrDefault(d => d.DishId == id)
            );
            databases.SaveChanges();
            return Redirect("/menu/manage");
        }
        [Route("/menu/manage")]
        public IActionResult MenuEdit()
        {
            ViewBag.Dishes = databases.Dishes.OrderBy(d=>d.Type).ToList();
            return View();
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(User NewUser)
        {
            if (ModelState.IsValid)
            {
                
                return Redirect("/");
            }
            else
            {
                return View("index");
            }
        }
        [Route("dish/create")]
        public IActionResult Create(Dish newdish)
        {
            if (ModelState.IsValid)
            {   
                databases.Dishes.Add(newdish);
                databases.SaveChanges();
                return Redirect("/menu");
            }
            else 
            {
                return View("DishAdd"); 
            }
        }
        [Route("dish/update/{id}")]
        public IActionResult Update(int id, Dish updatedDish)
        {   
            if (ModelState.IsValid)
            {       
                Dish SelectedDish = databases.Dishes.FirstOrDefault(d => d.DishId == id);
        
                SelectedDish.DishName = updatedDish.DishName;
                SelectedDish.Price = updatedDish.Price;
                SelectedDish.Ingredients = updatedDish.Ingredients;
                SelectedDish.UpdateAt = updatedDish.UpdateAt;
                SelectedDish.Description = updatedDish.Description;
                SelectedDish.Type = updatedDish.Type;
                databases.SaveChanges();
                return Redirect("/menu/manage");
            }
            else 
            {   
                updatedDish.DishId = id; //need this one to repeat the ID. If not the ID on url will lost
                return View("DishEdit",updatedDish); // this need to be RENDER, not redirect;
            }
        }
        // public IActionResult Index()
        // {
        //     return View();
        // }

        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}

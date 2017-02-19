using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_3_Web_Application_Design.Models;

namespace Lab_3_Web_Application_Design.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IList<String> greetingMessage = new List<String>();
            DateTime time = DateTime.Today;
            String greeting = "Good Morning!";
            if (time.Hour > 12 && time.Hour < 18)
            {
                greeting = "Good Afternoon!";
            }
            else if (time.Hour > 18)
            {
                greeting = "Good Evening!";
            }
            ViewData["greeting"] = greeting;
            ViewData["timeOfDay"] = time.ToString("h:mm tt");
            ViewData["date"] = time.Date.ToString("D");
            ViewData["daysLeft"] = (365 - time.DayOfYear);
            ViewData["year"] = time.Year + 1;

            return View();
        }
        public IActionResult ShowPerson()
        {
            Person p = new Person
            {
                FirstName = "Sophia",
                LastName = "Carnevale",
                BirthDate = new int[3] { 1, 26, 1996 }
            };
            DateTime date = new DateTime(p.BirthDate[2], p.BirthDate[0], p.BirthDate[1]);
            ViewData["name"] = p.FirstName + " " + p.LastName;
            ViewData["birthDate"] = date.ToString("dd MMMM yyyy");
            ViewData["age"] = p.Age;

            return View();
        }
        public IActionResult AddPerson()
        {
            return View();
        }
        public static Person
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                repo.Add(person);

                return RedirectToAction("Index");

            }
            else
            {
                return View(person);
            }
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLab3.Models;

namespace WebLab3.Controllers
{
    public class HomeController : Controller
    {
        //holds Person objects 
        public static PersonRepository people = new PersonRepository();
        //Gives greeting for home page
        public IActionResult Index()
        {
            IList<String> greetingMessage = new List<String>();
            DateTime time = DateTime.Now;
            String greeting = "Good Morning!";
            if (time.Hour >= 11 && time.Hour < 17)
            {
                greeting = "Good Afternoon!";
            }
            else if (time.Hour >= 17)
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
        //gives information from people object to the ShowPerson view
        public IActionResult ShowPerson()
        {
            ViewData["heading"] = "People";

            return View(people.PeopleList);
        }
        //for AddPerson view
        public IActionResult AddPerson()
        {
            return View();
        }
        //takes information from form and adds it to the person list
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                people.AddPerson(person);

                return RedirectToAction("ShowPerson");

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

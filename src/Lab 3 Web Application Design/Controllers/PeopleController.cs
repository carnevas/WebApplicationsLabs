using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebLab4.Models;

namespace WebLab4.Controllers
{
    public class PeopleController : Controller
    {
        //holds Person objects 
        public static PersonRepository people = new PersonRepository();
        // GET: /<controller>/
        public IActionResult Index()
        {
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
    }
}

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
        private PersonRepository people;

        private readonly ApplicationDbContext _context;
        //constructor
        public PeopleController(ApplicationDbContext context)
        {
            _context = context;
            people = new PersonRepository();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewData["heading"] = "People";
            return View(_context.People.ToList());
        }
        //gives information from people object to the ShowPerson view
        public IActionResult ShowPerson(int? id)
        {
            ViewData["heading"] = "Person";
            Person person;
            if (id == null)
            {
                person = new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = "1995-02-12"
                };
            }
            else
            {
                person = _context.People.SingleOrDefault(p => p.PersonID == id);
            }

            return View(person);
           // return View(people.PeopleList);
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

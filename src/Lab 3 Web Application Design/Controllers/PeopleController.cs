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
            ViewData["IndexHeading"] = "People";
            return View(_context.People.ToList());
        }
        //gives information from people object to the ShowPerson view
        public IActionResult ShowPerson(int? id)
        {
            ViewData["ShowPersonHeading"] = "Person";
            Person person;
            if (id == null)
            {
                person = new Person
                {
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = new DateTime(1995, 2, 12)
                };
            }
            else
            {
                person = _context.People.SingleOrDefault(p => p.PersonID == id);
            }

            return View(person);
        }
        //for Details view
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = _context.People.SingleOrDefault(p => p.PersonID == id);
            if (person == null)
            {
                return NotFound();
            }
            return View("ShowPerson", person);
        }
        //for DeletePerson view
        public IActionResult DeletePerson(int? id)
        {
            Person person = _context.People.SingleOrDefault(p => p.PersonID == id);
            ViewData["DeletePersonHeading"] = "Are you sure you would like to delete " + person.FirstName + " " + person.LastName + "?";
            return View(person);
        }
        [HttpPost]
        public IActionResult DeletePerson(Person person)
        {
            if(person != null)
            {
                _context.Remove(person);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
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
                _context.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }
        public IActionResult EditPerson(int? id)
        {
            Person person = _context.People.SingleOrDefault(p => p.PersonID == id);
            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Update(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(person);
            }
        }

    }
}

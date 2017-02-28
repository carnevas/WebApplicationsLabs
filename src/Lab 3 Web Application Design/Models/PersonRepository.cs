using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLab4.Models
{
    public class PersonRepository
    {
        //list that holds Person objects
        public readonly ApplicationDbContext _context;

        //constructor
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Person> PeopleList;
        public PersonRepository()
        {
            PeopleList = new List<Person>();

            Person p = new Person
            {
                FirstName = "Jane",
                LastName = "Doe",
                BirthDate = "1993-03-04"
            };

            PeopleList.Add(p);
        }
        //adds Person object to list
        public void AddPerson(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLab3.Models
{
    public class PersonRepository
    {
        //list that holds Person objects
        public List<Person> PeopleList { get; set; }

        //constructor
        public PersonRepository()
        {
            PeopleList = new List<Person>();

            Person p = new Person
            {
                FirstName = "Sophia",
                LastName = "Carnevale",
                BirthDate = "1996-01-26"
            };

            PeopleList.Add(p);
        }
        //adds Person object to list
        public void AddPerson(Person person)
        {
            PeopleList.Add(person);
        }
    }
}

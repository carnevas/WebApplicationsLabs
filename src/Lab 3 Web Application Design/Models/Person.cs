using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_3_Web_Application_Design.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //saved as MM DD YYYY
        public int[] BirthDate { get; set; }
        public int Age
        {
            get
            {
                DateTime date = DateTime.Today;
                int age = date.Year - BirthDate[2];
                if (date.Month < BirthDate[0])
                {
                    age--;
                }
                else if (date.Month == BirthDate[2] && date.Day < BirthDate[1])
                {
                    age--;
                }

                return age;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebLab4.Models
{
    public class Person
    {
        public int PersonID { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage="First Name must be 2 to 20 characters.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }
        //saved as YYYY-MM-DD
        public DateTime BirthDate { get; set; }
        public int Age
        {
            get
            {
                int age = -1;
                if (BirthDate != null)
                {
                    DateTime date = DateTime.Today;
                    age = date.Year - BirthDate.Year;
                    if (date.Month < BirthDate.Month)
                    {
                        age--;
                    }
                    else if (date.Month == BirthDate.Month && date.Day < BirthDate.Day)
                    {
                        age--;
                    }
                }
                     return age;
            }  
        }
        //formats birthday as MonthName Day, Year
        public string GetBirthday()
        {
            string birthday;
            if (BirthDate == null)
            {
                birthday = "Not Entered";
            }
            else
            {
                birthday = BirthDate.ToString("MMMM") + " " + BirthDate.Day + ", " + BirthDate.Year;
            }
            return birthday;
        }
    }
}

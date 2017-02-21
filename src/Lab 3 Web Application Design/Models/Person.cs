using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebLab3.Models
{
    public class Person
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        //saved as YYYY-MM-DD
        public string BirthDate { get; set; }
        public int Age
        {
            get
            {
                int age;
                if (BirthDate == null)
                {
                    age = 0;
                }
                else
                {
                    DateTime date = DateTime.Today;
                    string[] birthData = BirthDate.Split('-');
                    int year = int.Parse(birthData[0]);
                    int month = int.Parse(birthData[1]);
                    int day = int.Parse(birthData[2]);
                    age = date.Year - year;
                    if (date.Month < month)
                    {
                        age--;
                    }
                    else if (date.Month == month && date.Day < day)
                    {
                        age--;
                    }
                }
                return age;
            }
        }
        //formats birthday as MonthName Day, Year
        public string getBirthday()
        {
            string birthday;
            if (BirthDate == null)
            {
                birthday = "Not Entered";
            }
            else
            {
                string[] birthData = BirthDate.Split('-');
                int year = int.Parse(birthData[0]);
                int month = int.Parse(birthData[1]);
                int day = int.Parse(birthData[2]);
                DateTime birthDate = new DateTime(year, month, day);
                birthday = birthDate.ToString("MMMM") + " " + birthDate.Day + ", " + birthDate.Year;
            }
            return birthday;
        }
    }
}

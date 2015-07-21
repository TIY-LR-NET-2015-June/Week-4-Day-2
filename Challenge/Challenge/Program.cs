using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge
{
    class Program
    {
        static void Main(string[] args)
        {

            Person p = new Person("Daniel", "Pollock", DateTime.Parse("6/6/1981"), "daniel@theironyard.com");

            var test = p.Age;
            
        }


    }

    public class Person
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return Lastname + ", " + Firstname;
            }
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DOB.Year;
                if (DOB > today.AddYears(-age)) age--;


                return age;
            }
        }

        public Person(string first, string last, DateTime dob, string email)
        {
            Firstname = first;
            Lastname = last;
            DOB = dob;
            Email = email;
        }
    }
}

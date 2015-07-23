using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using W4D2HW.Controllers;

namespace W4D2HW.Models
{


    public class Person
    {

        public string Name { get; set; }
        public int YearsOld { get; set; }

        [Key]
        public int Id { get; set; }

        public Person()
        {
            Id = ClassMatesController.PersonList.Count;
        }
        public Person(string name, int yearsOld)
        {
            Name = name;
            YearsOld = yearsOld;
            Id = ClassMatesController.PersonList.Count;
        }
    }
}
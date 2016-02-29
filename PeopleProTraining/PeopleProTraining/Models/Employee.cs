using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleProTraining.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoomNumber { get; set; }
        public string Building { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public Decimal Salary { get; set; }

        


    }
}
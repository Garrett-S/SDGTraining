using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }
    public class EmployeeMetaData
    {

        [Required]
        public string FirstName;
        public int EmployeeID;
        [Required]
        public int DepartmentDepartmentID;
        [Required]
        public int BuildingBuildingID;
        [Required]
        public string LastName;
        [Required]
        public System.DateTime DoB;
        [Required]
        public int RoomNumber;
        [Required]
        public string Title;
        [Required]
        public decimal Salary;

    }


}

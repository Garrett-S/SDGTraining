//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PeopleProTraining.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.EmployeeID = 0;
            this.DepartmentDepartmentID = 0;
            this.BuildingBuildingID = 0;
        }

        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int DepartmentDepartmentID { get; set; }
        [Required]
        public int BuildingBuildingID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DoB { get; set; }
        [Required]
        public int RoomNumber { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Salary { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Building Building { get; set; }
    }
}

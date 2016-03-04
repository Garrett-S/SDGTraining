using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department
    {
    }

    public class DepartmentMetaData
    {
        public int DepartmentID = 0;
        [Required]
        public string Name;
    }
}

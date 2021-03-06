﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PeopleProTraining.Dal.Models
{
    [MetadataType(typeof(BuildingMetaData))]
    public partial class Building
    {
        public bool HasEmployees { get {
                return (
                (this.Employees.Count != 0)
                ); } }
    }
    public class BuildingMetaData
    {

        [Required]
        public string Name;

        public int BuildingID = 0;

        public string AddressLine1;

        public string AddressLine2;
        [Required]
        public string City;
        [Required]
        public string State;
        [Required]
        [RegularExpression(@"^\d{5}$")]
        [StringLength(5)]
        public string ZipCode;

        public string Country;



    }
}

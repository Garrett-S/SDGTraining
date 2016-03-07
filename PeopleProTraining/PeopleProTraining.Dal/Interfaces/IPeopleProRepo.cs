﻿using PeopleProTraining.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProTraining.Dal.Interfaces
{
    public interface IPeopleProRepo
    {
        #region access

        #region employees
        IQueryable<Employee> GetEmployees();
        IEnumerable<Employee> GetEmployees(Func<Employee, bool> predicate);

        Employee GetEmployee(Func<Employee, bool> predicate);
        Employee GetEmployee(int id);
        void SaveEmployee(Employee employee);
        void RemoveEmployee(Employee employee);
        #endregion

        #region buildings
        IQueryable<Building> GetBuildings();
        IEnumerable<Building> GetBuildings(Func<Building, bool> predicate);

        Building GetBuilding(Func<Building, bool> predicate);
        Building GetBuilding(int id);
        IEnumerable<Employee> BuildingEmployees(int id);
        void SaveBuilding(Building building);
        void RemoveBuilding(Building building);
        #endregion

        #region departments
        IQueryable<Department> GetDepartments();
        IEnumerable<Department> GetDepartments(Func<Department, bool> predicate);

        Department GetDepartment(Func<Department, bool> predicate);
        Department GetDepartment(int id);
        IEnumerable<Employee> DepartmentEmployees(int id);
        void SaveDepartment(Department department);
        void RemoveDepartment(Department department);
        #endregion

        void Dispose(bool isDisposing);
        #endregion
    }
}

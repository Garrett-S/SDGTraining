﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleProTraining.Dal.Extensions;
using PeopleProTraining.Dal.Interfaces;
using PeopleProTraining.Dal.Models;
using System.Data.SqlClient;
using PeopleProTraining.Dal.CustomExceptions;

namespace PeopleProTraining.Dal.Infrastructure
{
    public sealed class PeopleProRepo : IPeopleProRepo
    {
        private IPeopleProContext p_context;
        private bool p_disposed;

        public PeopleProRepo() : this(new PeopleProContext()) { }

        public PeopleProRepo(IPeopleProContext context)
        {
            p_context = context;
        }

        #region access

        #region employees
        public IQueryable<Employee> GetEmployees()
        {
            return p_context.Employees;
        }
        public IEnumerable<Employee> GetEmployees(Func<Employee, bool> predicate)
        {
            return p_context.Employees.Where(predicate);
        }

        public Employee GetEmployee(Func<Employee, bool> predicate)
        {
            return GetEmployees().SingleOrDefault(predicate);
        }
        public Employee GetEmployee(int id)
        {
            return GetEmployee(t => t.EmployeeID == id);
        }

        public void SaveEmployee(Employee employee)
        {
            DoSave(p_context.Employees, employee, employee.EmployeeID, t => t.EmployeeID == employee.EmployeeID);
        }
        public void RemoveEmployee(Employee employee)
        {
            DoRemove(p_context.Employees, employee, employee.EmployeeID, t => t.EmployeeID == employee.EmployeeID);
        }
        #endregion

        #region buildings
        public IQueryable<Building> GetBuildings()
        {
            return p_context.Buildings;
        }
        public IEnumerable<Building> GetBuildings(Func<Building, bool> predicate)
        {
            return p_context.Buildings.Where(predicate);
        }

        public Building GetBuilding(Func<Building, bool> predicate)
        {
            return GetBuildings().SingleOrDefault(predicate);
        }
        public Building GetBuilding(int id)
        {
            return GetBuilding(t => t.BuildingID == id);
        }

        public IEnumerable<Employee> BuildingEmployees(int id)
        {
            var employees = GetEmployees();
            employees = from employee in employees
                        where employee.BuildingBuildingID == id
                        select employee;

            return employees;
        }

        public void SaveBuilding(Building building)
        {
            DoSave(p_context.Buildings, building, building.BuildingID, t => t.BuildingID == building.BuildingID);
        }
        public void RemoveBuilding(Building building)
        {
            try {
                DoRemove(p_context.Buildings, building, building.BuildingID, t => t.BuildingID == building.BuildingID);
            }
            catch (Exception removeException)
            {
                throw new DBRemoveException(removeException.ToString());
            }
        }
        #endregion

        #region departments
        public IQueryable<Department> GetDepartments()
        {
            return p_context.Departments;
        }
        public IEnumerable<Department> GetDepartments(Func<Department, bool> predicate)
        {
            return p_context.Departments.Where(predicate);
        }

        public Department GetDepartment(Func<Department, bool> predicate)
        {
            return GetDepartments().SingleOrDefault(predicate);
        }
        public Department GetDepartment(int id)
        {
            return GetDepartment(t => t.DepartmentID == id);
        }
        public IEnumerable<Employee> DepartmentEmployees(int id)
        {
            var employees = GetEmployees();
            employees = from employee in employees
                        where employee.DepartmentDepartmentID == id
                        select employee;

            return employees;
        }

        public void SaveDepartment(Department department)
        {
            DoSave(p_context.Departments, department, department.DepartmentID, t => t.DepartmentID == department.DepartmentID);
        }

        public void RemoveDepartment(Department department)
        {
            try
            {
                DoRemove(p_context.Departments, department, department.DepartmentID, t => t.DepartmentID == department.DepartmentID);
            }
            catch (Exception removeException)
            {
                throw new DBRemoveException(removeException.ToString());
            }
        }
        #endregion

        #endregion



        /// <summary>
        /// Abstracts the saving process for an item in the Db Context.
        /// </summary>
        private void DoSave<T>(IDbSet<T> dbSet, T entity, int entityId, Func<T, bool> predicate) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(entity.GetType().Name);
            }

            if (entityId <= 0)
            {
                dbSet.Add(entity);
            }
            else
            {
                var old = dbSet.SingleOrDefault(predicate);
                entity.CopyTo(old);
            }

            p_context.SaveChanges();
        }
        /// <summary>
        /// Abstracts the deletion process for an item in the Db Context.
        /// </summary>
        private void DoRemove<T>(IDbSet<T> dbSet, T entity, int entityId, Func<T, bool> predicate) where T : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(entity.GetType().Name);
            }
            dbSet.Remove(entity);
            p_context.SaveChanges();
        }

        #region Disposal
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031",
            Justification = "Swallows general exceptions, to prevent the service from being disabled.")]
        public void Dispose(bool isDisposing)
        {
            if (!p_disposed)
            {
                try
                {
                    // Called from the IDisposable Method
                    // Nothing happens when isDisposing is false, since we don't have unmanaged resources
                    if (isDisposing)
                    {
                        try
                        {
                            if (p_context != null)
                            {
                                p_context.Dispose();
                            }
                        }
                        catch (Exception)
                        {
                            // This is intended to swallow up any exceptions to prevent the service from being crashing.
                        }
                    }
                }
                finally
                {
                    p_disposed = true;
                }
            }
        }

        #endregion

    }
}

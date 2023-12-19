using Company_project_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_project_management_system.services
{
    public class EmployeeService : IEmployeeServices
    {

        private readonly List<Project> projects = new List<Project>
        {
            new Project
            {
                Id = 1,
                Name = "Project A",
                StartDate = new DateTime(2023, 1, 1),
                EndDate = new DateTime(2023, 12, 31),
                ManagerId = 101
            },
            new Project
            {
                Id = 2,
                Name = "Project B",
                StartDate = new DateTime(2023, 2, 1),
                EndDate = new DateTime(2023, 11, 30),
                ManagerId = 102
            },
            // Add more projects
        };

        private readonly List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 101,
                Name = "John Doe",
                Email = "john.doe@example.com",
                DOJ = new DateTime(2022, 5, 15),
                DepartmentId = 201
            },
            new Employee
            {
                Id = 102,
                Name = "Jane Smith",
                Email = "jane.smith@example.com",
                DOJ = new DateTime(2022, 8, 20),
                DepartmentId = 202
            },
            // Add more employees
        };

        private readonly List<Department> departments = new List<Department>
        {
            new Department { Id = 201, Name = "Engineering" },
            new Department { Id = 202, Name = "Marketing" },
            // Add more departments
        };

        public List<Project> GetProject()
        {
            return projects;
        }

        public List<Employee> GetEmployee()
        {
            return employees;
        }

        public List<Department> GetDepartments()
        {
            return departments;
        }


        public List<EmployeeResponse> GetEmployeesForProject(int projectId)
        {
            var projectEmployees = new List<EmployeeResponse>();

            // Retrieve employees assigned to the project
            var assignedEmployeeIds = new List<int> { 101, 102 }; // Replace with actual logic to get assigned employees

            // Iterate through assigned employees and add details to the response
            foreach (var employeeId in assignedEmployeeIds)
            {
                var employee = employees.Find(emp => emp.Id == employeeId);
                var department = departments.Find(dept => dept.Id == employee.DepartmentId);

                projectEmployees.Add(new EmployeeResponse
                {
                    Name = employee.Name,
                    Email = employee.Email,
                    DOJ = employee.DOJ,
                    Department = new DepartmentResponse
                    {
                        Name = department.Name
                    }
                });
            }

            return projectEmployees;
        }
    }
}

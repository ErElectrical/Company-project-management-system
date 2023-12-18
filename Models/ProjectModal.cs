using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_project_management_system.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ManagerId { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Define updated response DTOs
    public class ProjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ManagerResponse Manager { get; set; }
        public List<EmployeeResponse> Employees { get; set; }
    }

    public class ManagerResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DepartmentResponse Department { get; set; }
    }

    public class EmployeeResponse
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DOJ { get; set; }
        public DepartmentResponse Department { get; set; }
    }

    public class DepartmentResponse
    {
        public string Name { get; set; }
    }

}

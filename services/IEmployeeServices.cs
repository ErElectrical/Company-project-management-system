using Company_project_management_system.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company_project_management_system.services
{
    public interface IEmployeeServices
    {
        List<EmployeeResponse> GetEmployeesForProject(int projectId);
        List<Project> GetProject();
        List<Employee> GetEmployee();
        List<Department> GetDepartments();
    }
}

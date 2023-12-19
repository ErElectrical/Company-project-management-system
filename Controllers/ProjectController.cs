using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Company_project_management_system.Models;
using Company_project_management_system.services;

namespace Company_project_management_system.Controllers
{

    //this attribute tells that the request needs to be authorized .
    [Authorize]
    [Route("api")]
    [ApiController]

    public class ProjectController : Controller
    {

        //inject the service dependancy to be used in controller.
        private readonly IEmployeeServices _myService;

        public ProjectController(IEmployeeServices myService)
        {
            _myService = myService;
        }
        // GET api/project
        [HttpGet("project")]
        public ActionResult<IEnumerable<ProjectResponse>> GetProjects([FromQuery] int page = 1, [FromQuery] int per_page = 10)
        {
            try
            {
                // Paginate the projects
                var paginatedProjects = Paginate(_myService.GetProject(), page, per_page);

                // Create a response object
                var response = new
                {
                    projects = new List<ProjectResponse>(),
                    total_projects = _myService.GetProject().Count,
                    page,
                    per_page
                };

                // Iterate through paginated projects and retrieve allocated employees
                foreach (var project in paginatedProjects)
                {
                    var manager = _myService.GetEmployee().Find(emp => emp.Id == project.ManagerId);
                    var department = _myService.GetDepartments().Find(dept => dept.Id == manager.DepartmentId);

                    // Add project details to the response
                    response.projects.Add(new ProjectResponse
                    {
                        Id = project.Id,
                        Name = project.Name,
                        StartDate = project.StartDate,
                        EndDate = project.EndDate,
                        Manager = new ManagerResponse
                        {
                            Name = manager.Name,
                            Email = manager.Email,
                            Department = new DepartmentResponse
                            {
                                Name = department.Name
                            }
                        },
                        Employees = _myService.GetEmployeesForProject(project.Id)
                    });
                }

                return View("projectResponse", response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        // Helper method for pagination
        private List<Project> Paginate(List<Project> items, int page, int per_page)
        {
            var start_index = (page - 1) * per_page;
            var end_index = Math.Min(start_index + per_page, items.Count);
            return items.GetRange(start_index, end_index - start_index);
        }

    }
}


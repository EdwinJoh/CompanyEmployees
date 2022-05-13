﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts.Interfaces;
using Shared.DataTransferObjects;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service) => _service = service;

        [HttpGet]
        public IActionResult GetEmployeeForCompany(Guid companyId)
        {
            var employee = _service.EmployeeService.GetEmployees(companyId,trackChanges:false);
            return Ok(employee);
        }
        
        [HttpGet("{id:guid}",Name = "GetEmployeeForCompany")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = _service.EmployeeService.GetEmployee(companyId, id,
            trackChanges: false);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId,[FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto Object is null");

            var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId,employee,trackChanges:false);

            return CreatedAtRoute("GetEmployeeForCompany", new { companyId,id = employeeToReturn.Id},employeeToReturn);

        }

    }
}
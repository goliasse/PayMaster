using AutoMapper;
using Paymaster.BusinessEntities;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Paymaster.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly IPayorService _payorService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IPayorService payorService, IEmployeeService employeeService)
        {
            _payorService = payorService;
            _employeeService = employeeService;

            Mapper.CreateMap<EmployeeDTO, Employee>()
               .AfterMap(
                   (src, dest) => dest.Payors = _payorService.FindBy(t => t.Id == src.PayorId)
               );
            Mapper.CreateMap<Employee, EmployeeDTO>()
                .AfterMap(
                    (src, dest) => dest.PayorId = src.Payors.Id
                );

            Mapper.CreateMap<List<Employee>, List<EmployeeDTO>>();
        }

        // GET: api/Employee
        /// <summary>
        /// List all employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeDTO> Get()
        {
            return Mapper.Map<IEnumerable<EmployeeDTO>>(_employeeService.All());
        }

        // GET: api/Employee/5
        /// <summary>
        /// Get employee by employee Id
        /// </summary>
        /// <param name="id">Id of the employee to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var employee = _employeeService.FindBy(t => t.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<EmployeeDTO>(employee));
        }

        // POST: api/Employee
        /// <summary>
        /// Method to insert/save employee record
        /// </summary>
        /// <param name="employee">Employee records to be inserted/saved</param>
        /// <returns></returns>
        public HttpResponseMessage Post(EmployeeDTO employeeDTO)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var employee = Mapper.Map<Employee>(employeeDTO);
                _employeeService.Add(employee);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, employee);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = employee.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method to update employee
        /// </summary>
        /// <param name="employee">Employee record to be updated</param>
        /// <returns></returns>
        public IHttpActionResult Put(EmployeeDTO value)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var searchedEmployee = _employeeService.FindBy(t => t.Id == value.Id);
                if (value == null)
                {
                    return BadRequest("Cannot update employee/Employee not found");
                }
                var toBeUpdatedRecord = Mapper.Map<Employee>(value);
                _employeeService.Update(toBeUpdatedRecord);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method to delete record
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var employee = _employeeService.FindBy(t => t.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                _employeeService.Delete(employee);
                //_employeeService.Delete(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
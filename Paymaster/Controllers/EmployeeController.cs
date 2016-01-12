using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using NHibernate;
using Paymaster.Model;
using Paymaster.App_Start;
using Paymaster.DBServices;
using Paymaster.Models;

namespace Paymaster.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private ISessionFactory _sessionFactory;
        private EmployeeService _employeeService;

        private PayorService _payorService;

        public EmployeeController()
        {
            _sessionFactory = DBPlumbing.CreateSessionFactory();
            _employeeService = new EmployeeService(_sessionFactory);
            _payorService = new PayorService(_sessionFactory);
            //Mapper.CreateMap<Employees, EmployeeDTO>();
            Mapper.CreateMap<EmployeeDTO, Employees>()
                .AfterMap(
                    (src, dest) => dest.Payors = _payorService.FindById(src.PayorId)
                );
            Mapper.CreateMap<Employees,EmployeeDTO >()
                .AfterMap(
                    (src, dest) => dest.PayorId = src.Payors.Id
                );

            Mapper.CreateMap<List<Employees>, List<EmployeeDTO>>();
            //.AfterMap(
            //    (src, dest) => Mapper.Map<Employees, EmployeeDTO>(src)
            //);

        }
        // GET: api/Employee
        /// <summary>
        /// List all employees
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EmployeeDTO> Get()
        {
            return Mapper.Map<IEnumerable<EmployeeDTO>>(_employeeService.GetAll());
        }

        // GET: api/Employee/5
        /// <summary>
        /// Get employee by employee Id
        /// </summary>
        /// <param name="id">Id of the employee to be searched: Guid/UUID</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var employee = _employeeService.FindById(id);
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

               var employee =  Mapper.Map<Employees>(employeeDTO);
                _employeeService.Save(employee);
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
                var searchedEmployee = _employeeService.FindById(value.Id);
                if (value == null)
                {
                    return BadRequest("Cannot update employee not found");
                }
                _employeeService.Update(searchedEmployee);
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
                var employee = _employeeService.FindById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                _employeeService.SoftDelete(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}

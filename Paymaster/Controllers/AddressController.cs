using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using NHibernate;
using Paymaster.App_Start;
using Paymaster.DBServices;
using Paymaster.Model;
using Paymaster.Models;

namespace Paymaster.Controllers
{
    public class AddressController : ApiController
    {
        private ISessionFactory _sessionFactory;
        private AddressService _addressService;
        private EmployeeService _employeeService;

        public AddressController()
        {
            _sessionFactory = DBPlumbing.CreateSessionFactory();
            _addressService = new AddressService(_sessionFactory);
            _employeeService = new EmployeeService(_sessionFactory);

            Mapper.CreateMap<AddressDTO, Addresses>()
               .AfterMap(
                   (src, dest) => dest.Employees = _employeeService.FindById(src.EmployeesId)
               );
            Mapper.CreateMap<Addresses, AddressDTO>()
                .AfterMap(
                    (src, dest) => dest.EmployeesId = src.Employees.Id
                );

            Mapper.CreateMap<List<Addresses>, List<AddressDTO>>();
        }
        
        /// <summary>
        /// List all Address
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AddressDTO> Get()
        {
            return Mapper.Map<IEnumerable<AddressDTO>>(_addressService.GetAll().AsEnumerable());
        }
        
        /// <summary>
        /// Get Address by address Id
        /// </summary>
        /// <param name="id">Id of the payor to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var record = _addressService.FindById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<AddressDTO>(record));
        }

        /// <summary>
        /// Method to insert/save payor record
        /// </summary>
        /// <param name="address">address records to be inserted/saved</param>
        /// <returns></returns>
        public HttpResponseMessage Post(Addresses address)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                _addressService.Save(address);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, address);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = address.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        
        /// <summary>
        /// Method to insert/save Address
        /// </summary>
        /// <param name="address">address to be updated</param>
        /// <returns></returns>
        public IHttpActionResult Put(AddressDTO address)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var searchedPayor = _addressService.FindById(address.Id);
                if (address == null)
                {   
                    return BadRequest("Cannot update payor/payor not found");
                }
                var toBeUpdatedRecord = Mapper.Map<Addresses>(address);
                _addressService.Update(toBeUpdatedRecord);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

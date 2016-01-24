using AutoMapper;
using Paymaster.BusinessEntities;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Paymaster.Controllers
{
    public class AddressController : BaseApiController
    {
        private readonly IAddressService _addressService;
        private readonly IEmployeeService _employeeService;

        public AddressController(IAddressService addressService, IEmployeeService employeeService)
        {
            _addressService = addressService;
            _employeeService = employeeService;

            Mapper.CreateMap<AddressDTO, Address>()
               .AfterMap(
                   (src, dest) => dest.Employees = _employeeService.FindBy(t => t.Id == src.EmployeesId)
               );
            Mapper.CreateMap<Address, AddressDTO>()
                .AfterMap(
                    (src, dest) => dest.EmployeesId = src.Employees.Id
                );

            Mapper.CreateMap<List<Address>, List<AddressDTO>>();
        }

        /// <summary>
        /// List all Address
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AddressDTO> Get()
        {
            return Mapper.Map<IEnumerable<AddressDTO>>(_addressService.All().AsEnumerable());
        }

        /// <summary>
        /// Get Address by address Id
        /// </summary>
        /// <param name="id">Id of the payor to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var record = _addressService.FindBy(t => t.Id == id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<AddressDTO>(record));
        }

        /// <summary>
        /// Method to insert/save payor record
        /// </summary>
        /// <param name="addressDto">address records to be inserted/saved</param>
        /// <returns></returns>
        public HttpResponseMessage Post(AddressDTO addressDto)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var record = Mapper.Map<Address>(addressDto);
                _addressService.Add(record);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, addressDto);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = addressDto.Id }));
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
                var searchedPayor = _addressService.FindBy(t => t.Id == address.Id);
                if (address == null)
                {
                    return BadRequest("Cannot update payor/payor not found");
                }
                var toBeUpdatedRecord = Mapper.Map<Address>(address);
                _addressService.Update(toBeUpdatedRecord);
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
        /// <param name="id">record id</param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var employee = _addressService.FindBy(t => t.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                _addressService.Delete(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
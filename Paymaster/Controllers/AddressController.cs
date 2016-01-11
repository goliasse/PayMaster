using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NHibernate;
using Paymaster.App_Start;
using Paymaster.DBServices;
using Paymaster.Model;

namespace Paymaster.Controllers
{
    public class AddressController : ApiController
    {
        private ISessionFactory _sessionFactory;
        private AddressService _addressService;

        public AddressController()
        {
            _sessionFactory = DBPlumbing.CreateSessionFactory();
            _addressService = new AddressService(_sessionFactory);
        }
        
        /// <summary>
        /// List all Address
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Addresses> Get()
        {
            return _addressService.GetAll().AsEnumerable();
        }
        
        /// <summary>
        /// Get Address by address Id
        /// </summary>
        /// <param name="id">Id of the payor to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var payor = _addressService.FindById(id);
            if (payor == null)
            {
                return NotFound();
            }
            return Ok(payor);
        }

        /// <summary>
        /// Method to insert/save payor record
        /// </summary>
        /// <param name="payor">payor records to be inserted/saved</param>
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
        /// <param name="payor">address to be updated</param>
        /// <returns></returns>
        public IHttpActionResult Put(Addresses address)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var searchedPayor = _addressService.FindById(address.Id);
                if (address == null)
                {
                    return BadRequest("Cannot update payor/payor not found");
                }
                _addressService.Update(searchedPayor);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

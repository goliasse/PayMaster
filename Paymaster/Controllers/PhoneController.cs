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

namespace Paymaster.Controllers
{
    public class PhoneController : ApiController
    {
        private ISessionFactory _sessionFactory;
        private PhoneService _phoneService;

        public PhoneController()
        {
            _sessionFactory = DBPlumbing.CreateSessionFactory();
            _phoneService = new PhoneService(_sessionFactory);
        }

        /// <summary>
        /// List all phone
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Phones> Get()
        {
            return _phoneService.GetAll().AsEnumerable();
        }

        /// <summary>
        /// Get Email by phone record Id
        /// </summary>
        /// <param name="id">Id of the phone to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var record = _phoneService.FindById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        /// <summary>
        /// Method to insert/save phone record
        /// </summary>
        /// <param name="email">phone records to be inserted/saved</param>
        /// <returns></returns>
        public HttpResponseMessage Post(Phones phone)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                _phoneService.Save(phone);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, phone);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = phone.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method to update phone
        /// </summary>
        /// <param name="email">phone to be updated</param>
        /// <returns></returns>
        public IHttpActionResult Put(Phones phone)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var searchedRecord = _phoneService.FindById(phone.Id);
                if (phone == null)
                {
                    return BadRequest("Cannot update phone/ phone not found");
                }
                var toBeUpdatedRecord = Mapper.Map<Phones>(phone);
                _phoneService.Update(toBeUpdatedRecord);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

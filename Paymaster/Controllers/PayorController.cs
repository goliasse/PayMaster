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
    public class PayorController : ApiController
    {
        private ISessionFactory _sessionFactory;
        private PayorService _payorService;
        
        public PayorController()
        {
            _sessionFactory = DBPlumbing.CreateSessionFactory();
            _payorService = new PayorService(_sessionFactory);
        }

        // GET: api/Payor
        /// <summary>
        /// List all payor
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Payors> Get()
        {
            return _payorService.GetAll().AsEnumerable();
        }

        // GET: api/Payor/id
        /// <summary>
        /// Get payor by payor Id
        /// </summary>
        /// <param name="id">Id of the payor to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var payor = _payorService.FindById(id);
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
        public HttpResponseMessage Post(Payors payor)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                _payorService.Save(payor);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, payor);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = payor.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST: api/Payor
        /// <summary>
        /// Method to insert/save payor record
        /// </summary>
        /// <param name="payor">payor records to be updated</param>
        /// <returns></returns>
        public IHttpActionResult Put(Payors payor)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var searchedPayor = _payorService.FindById(payor.Id);
                if (payor == null)
                {
                    return BadRequest("Cannot update payor/payor not found");
                }
                var toBeUpdatedRecord = Mapper.Map<Payors>(payor);
                _payorService.Update(toBeUpdatedRecord);
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
                var employee = _payorService.FindById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                _payorService.Delete(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}

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
    public class EmailController : ApiController
    {
        private ISessionFactory _sessionFactory;
        private EmailService _emailService;

        public EmailController()
        {
            _sessionFactory = DBPlumbing.CreateSessionFactory();
            _emailService = new EmailService(_sessionFactory);
        }

        /// <summary>
        /// List all Emails
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Emails> Get()
        {
            return _emailService.GetAll().AsEnumerable();
        }

        /// <summary>
        /// Get Email by email record Id
        /// </summary>
        /// <param name="id">Id of the email to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var record = _emailService.FindById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        /// <summary>
        /// Method to insert/save email record
        /// </summary>
        /// <param name="email">email records to be inserted/saved</param>
        /// <returns></returns>
        public HttpResponseMessage Post(Emails email)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                _emailService.Save(email);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, email);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = email.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method to update Email
        /// </summary>
        /// <param name="email">email to be updated</param>
        /// <returns></returns>
        public IHttpActionResult Put(Emails email)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var searchedRecord = _emailService.FindById(email.Id);
                if (email == null)
                {
                    return BadRequest("Cannot update email/ email not found");
                }
                var toBeUpdatedRecord = Mapper.Map<Emails>(email);
                _emailService.Update(toBeUpdatedRecord);
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
                var employee = _emailService.FindById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                _emailService.Delete(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
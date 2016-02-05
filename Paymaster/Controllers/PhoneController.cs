using AutoMapper;
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
    public class PhoneController : BaseApiController
    {
        private readonly IPhoneService _phoneService;

        public PhoneController(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        /// <summary>
        /// List all phone
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Phone> Get()
        {
            return _phoneService.All().AsEnumerable();
        }

        /// <summary>
        /// Get Email by phone record Id
        /// </summary>
        /// <param name="id">Id of the phone to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var record = _phoneService.FindBy(t => t.Id == id);
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
        public HttpResponseMessage Post(Phone phone)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                _phoneService.Add(phone);
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
        public IHttpActionResult Put(Phone phone)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var searchedRecord = _phoneService.FindBy(t => t.Id == phone.Id);
                if (phone == null)
                {
                    return BadRequest("Cannot update phone/ phone not found");
                }
                var toBeUpdatedRecord = Mapper.Map<Phone>(phone);
                _phoneService.Update(toBeUpdatedRecord);
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
                var employee = _phoneService.FindBy(t => t.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                _phoneService.Delete(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
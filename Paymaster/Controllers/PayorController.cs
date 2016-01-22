﻿using AutoMapper;
using Paymaster.RepositoryInfrastucture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Paymaster.BusinessEntities;
using Paymaster.BusinessServices;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;

namespace Paymaster.Controllers
{
    public class PayorController : ApiController//BaseApiController
    {
        private readonly IPayorService _payorService;
        private readonly IUnitOfWork _unitOfWork;
        
        public PayorController(IPayorService payorService, IUnitOfWork unitOfWork)
        {
            _payorService = payorService;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Payor
        /// <summary>
        /// List all payor
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Payors> Get()
        {
            return _payorService.All();
        }

        // GET: api/Payor/id
        /// <summary>
        /// Get payor by payor Id
        /// </summary>
        /// <param name="id">Id of the payor to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            //check for ID validation
            var payor = _payorService.FindBy(t => t.Id == id);
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
                try
                {
                    _payorService.Add(payor);
                    _unitOfWork.Commit();
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, payor);
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = payor.Id }));
                    return response;
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
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
                try
                {
                    var searchedPayor = _payorService.FindBy(t => t.Id == payor.Id);
                    if (payor == null)
                    {
                        return BadRequest("Cannot update payor/payor not found");
                    }
                    var toBeUpdatedRecord = Mapper.Map<Payors>(payor);
                    _payorService.Update(toBeUpdatedRecord);
                    _unitOfWork.Commit();
                    return Ok();
                }
                catch (Exception ex)
                {
                    _unitOfWork.Rollback();
                    return BadRequest();
                }
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
                var employee = _payorService.FindBy(t => t.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                //_payorService.Delete(employee);
                _payorService.Delete(employee);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
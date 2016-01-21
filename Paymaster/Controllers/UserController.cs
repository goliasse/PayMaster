using System;
using AutoMapper;
using NHibernate;
using Paymaster.App_Start;
using Paymaster.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Paymaster.DBServices;
using Paymaster.Model;

namespace Paymaster.Controllers
{
    public class UserController : BaseApiController
    {
        private ISessionFactory _sessionFactory;
        private PayorService _payorService;
        private UserService _userService;


        public UserController()
        {
            _sessionFactory = DBPlumbing.CreateSessionFactory();
            _payorService = new PayorService(_sessionFactory);
            _userService = new UserService(_sessionFactory);

            Mapper.CreateMap<UserDTO, Users>()
               .AfterMap(
                   (src, dest) => dest.Payors = _payorService.FindById(src.PayorId)
               );
            Mapper.CreateMap<UserInputDTO, Users>()
             .AfterMap(
                 (src, dest) => dest.Payors = _payorService.FindById(src.PayorId)
             );
            Mapper.CreateMap<Users, UserDTO>()
                .AfterMap(
                    (src, dest) => dest.PayorId = src.Payors.Id
                );

            Mapper.CreateMap<List<Users>, List<UserDTO>>();
        }

        /// <summary>
        /// List all Users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDTO> Get()
        {
            //TODO: assume the logged in user has priviledge to access all users
            //      we need to replace this with logged in user's priviledge
            return Mapper.Map<IEnumerable<UserDTO>>(_userService.GetAll().AsEnumerable());
        }
        
        /// <summary>
        /// Get Users by User's Id
        /// </summary>
        /// <param name="id">Id of the user to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var employee = _userService.FindById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<UserDTO>(employee));
        }

        /// <summary>
        /// Method to insert/save User record
        /// </summary>
        /// <param name="user">User records to be inserted/saved</param>
        /// <returns></returns>
        public HttpResponseMessage Post(UserInputDTO userInputDto)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {

                var user = Mapper.Map<Users>(userInputDto);
                _userService.Save(user);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Method to update user
        /// </summary>
        /// <param name="user">Users record to be updated</param>
        /// <returns></returns>
        public IHttpActionResult Put(UserInputDTO value)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                var searchedUser = _userService.FindById(value.Id);
                if (value == null)
                {
                    return BadRequest("Cannot update user/ user not found");
                }
                var toBeUpdatedRecord = Mapper.Map<Users>(value);
                _userService.Update(searchedUser);
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
                var employee = _userService.FindById(id);
                if (employee == null)
                {
                    return NotFound();
                }
                _userService.SoftDelete(employee);
                //TODO Enable delete instead of soft delete which will fail
                //_userService.Delete(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}
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
    public class UserController : BaseApiController
    {
        private readonly IPayorService _payorService;
        private readonly IUserService _userService;

        public UserController(IPayorService payorService, IUserService userService)
        {
            _payorService = payorService;
            _userService = userService;

            Mapper.CreateMap<UserDTO, User>()
               .AfterMap(
                   (src, dest) => dest.Payor = _payorService.FindBy(t => t.Id == src.PayorId)
               );
            Mapper.CreateMap<UserInputDTO, User>()
             .AfterMap(
                 (src, dest) => dest.Payor = _payorService.FindBy(t => t.Id == src.PayorId)
             );
            Mapper.CreateMap<User, UserDTO>()
                .AfterMap(
                    (src, dest) => dest.PayorId = src.Payor.Id
                );

            Mapper.CreateMap<List<User>, List<UserDTO>>();
        }

        /// <summary>
        /// List all Users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserDTO> Get()
        {
            //TODO: assume the logged in user has priviledge to access all users
            //      we need to replace this with logged in user's priviledge
            return Mapper.Map<IEnumerable<UserDTO>>(_userService.All().AsEnumerable());
        }

        /// <summary>
        /// Get Users by User's Id
        /// </summary>
        /// <param name="id">Id of the user to be searched</param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            var employee = _userService.FindBy(t => t.Id == id);
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
                var user = Mapper.Map<User>(userInputDto);
                _userService.Add(user);
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
                var searchedUser = _userService.FindBy(t => t.Id == value.Id);
                if (value == null)
                {
                    return BadRequest("Cannot update user/ user not found");
                }
                var toBeUpdatedRecord = Mapper.Map<User>(value);
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
                var employee = _userService.FindBy(t => t.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                _userService.Delete(t => t.Id == id);
                //_userService.SoftDelete(employee);
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
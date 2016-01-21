//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using AutoMapper;
//using NHibernate;
//using Paymaster.App_Start;
//using Paymaster.DBServices;
//using Paymaster.Model;
//using Paymaster.Models;

//namespace Paymaster.Controllers
//{
//    public class SearchController : BaseApiController
//    {
//        private ISessionFactory _sessionFactory;
//        private EmployeeService _employeeService;

//        public SearchController()
//        {
//            _sessionFactory = DBPlumbing.CreateSessionFactory();
//            _employeeService = new EmployeeService(_sessionFactory);

//            Mapper.CreateMap<Employees, EmployeeDTO>()
//                .AfterMap(
//                    (src, dest) => dest.PayorId = src.Payors.Id
//                );

//            Mapper.CreateMap<List<Employees>, List<EmployeeDTO>>();
//        }
//        /// <summary>
//        /// Method to insert/save phone record
//        /// </summary>
//        /// <param name="email">phone records to be inserted/saved</param>
//        /// <returns></returns>
//        public IEnumerable<EmployeeDTO> Post(EmployeeSearchDTO searchDto)
//        {
//            if (true)//TODO: replace this with validation logic ModelState.IsValid
//            {
//                var allEmployee = _employeeService.GetAll();
//                if (allEmployee.Any())
//                {
//                    var list = allEmployee.Where(t => (
//                                                      Compare(t.Firstname, searchDto.Firstname)
//                                                      || Compare(t.Middlename, searchDto.Middlename)
//                                                      || Compare(t.Lastname, searchDto.Lastname)
//                                                      || Compare(t.Socsec, searchDto.Socsec)
//                                                      ));
//                    return Mapper.Map<IEnumerable<EmployeeDTO>>(list);
//                }
//            }
//            return null;
//        }

//        private bool Compare(string toMatchIn, string toMatch)
//        {
//            if (!string.IsNullOrWhiteSpace(toMatchIn) && !string.IsNullOrWhiteSpace(toMatch))
//                return toMatchIn.ToLower().Trim().Contains(toMatch.ToLower().Trim());
//            return false;
//        }
//    }
//}

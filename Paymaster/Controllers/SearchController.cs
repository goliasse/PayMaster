using AutoMapper;
using Paymaster.BusinessEntities;
using Paymaster.BusinessServices.Interfaces;
using Paymaster.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace Paymaster.Controllers
{
    public class SearchController : BaseApiController
    {
        private readonly IEmployeeService _employeeService;

        public SearchController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

            Mapper.CreateMap<Employee, EmployeeDTO>()
                .AfterMap(
                    (src, dest) => dest.PayorId = src.Payors.Id
                );

            Mapper.CreateMap<List<Employee>, List<EmployeeDTO>>();
        }

        /// <summary>
        /// Method to insert/save phone record
        /// </summary>
        /// <param name="email">phone records to be inserted/saved</param>
        /// <returns></returns>
        public IEnumerable<EmployeeDTO> Post(EmployeeSearchDTO searchDto)
        {
            if (true)//TODO: replace this with validation logic ModelState.IsValid
            {
                //TODO: change _employeeService.All(); with _employeeService.FilterBy(expr);
                var allEmployee = _employeeService.All();
                if (allEmployee.Any())
                {
                    var list = allEmployee.Where(t => (
                                                      Compare(t.Firstname, searchDto.Firstname)
                                                      || Compare(t.Middlename, searchDto.Middlename)
                                                      || Compare(t.Lastname, searchDto.Lastname)
                                                      || Compare(t.Socsec, searchDto.Socsec)
                                                      ));
                    return Mapper.Map<IEnumerable<EmployeeDTO>>(list);
                }
            }
            return null;
        }

        private bool Compare(string toMatchIn, string toMatch)
        {
            if (!string.IsNullOrWhiteSpace(toMatchIn) && !string.IsNullOrWhiteSpace(toMatch))
                return toMatchIn.ToLower().Trim().Contains(toMatch.ToLower().Trim());
            return false;
        }
    }
}
using AutoMapper;
using JonasCodingTestNet6.API.Entities;
using JonasCodingTestNet6.API.Models;
using JonasCodingTestNet6.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace JonasCodingTestNet6.API.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IMapper _mapper;

        public EmployeeController(ILogger<EmployeeController> logger,
            ICompanyInfoRepository companyInfoRepository, IMapper mapper)
        {
            _logger = logger;
            _companyInfoRepository = companyInfoRepository;
            _mapper = mapper;
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees(int companyId)
        {
            var employees = await _companyInfoRepository.GetEmployeesAsync(companyId);
            var result = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(result);
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int employeeId)
        {
            var employee = await _companyInfoRepository.GetEmployeeAsync(employeeId);
            var result = _mapper.Map<EmployeeDto>(employee);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            var result = await _companyInfoRepository.CreateEmployeeAsync(employee);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            var result = await _companyInfoRepository.UpdateEmployeeAsync(employee);
            return Ok(result);
        }

        [HttpDelete("{employeeId}")]
        public async Task<ActionResult> DeleteEmployee(int employeeId)
        {
            var result = await _companyInfoRepository.DeleteEmployeeAsync(employeeId);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

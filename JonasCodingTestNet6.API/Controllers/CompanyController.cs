using AutoMapper;
using JonasCodingTestNet6.API.Entities;
using JonasCodingTestNet6.API.Models;
using JonasCodingTestNet6.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace JonasCodingTestNet6.API.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ILogger<CompanyController> _logger;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IMapper _mapper;

        public CompanyController(ILogger<CompanyController> logger,
            ICompanyInfoRepository companyInfoRepository, IMapper mapper)
        {
            _logger = logger;
            _companyInfoRepository = companyInfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
        {
            var companies = await _companyInfoRepository.GetCompaniesAsync();
            var result = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(result);
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int companyId)
        {
            var company = await _companyInfoRepository.GetCompanyAsync(companyId);
            var result = _mapper.Map<CompanyDto>(company);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyDto>> CreateCompany(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            var result = await _companyInfoRepository.CreateCompanyAsync(company);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<CompanyDto>> UpdateCompany(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            var result = await _companyInfoRepository.UpdateCompanyAsync(company);
            return Ok(result);

        }

        [HttpDelete("{companyId}")]
        public async Task<ActionResult> DeleteCompany(int companyId)
        {
            var result = await _companyInfoRepository.DeleteCompanyAsync(companyId);
            if (!result)
            {
                _logger.LogInformation($"Company with id = {companyId} was not found when trying to delete"); 
                return NotFound();
            }
            return Ok();
        }
    }
}

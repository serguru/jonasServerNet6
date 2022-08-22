using AutoMapper;
using JonasCodingTestNet6.API.Entities;
using JonasCodingTestNet6.API.Models;
using JonasCodingTestNet6.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace JonasCodingTestNet6.API.Controllers
{
    [ApiController]
    [Route("api/arsubledgers")]
    public class ArSubledgerController : ControllerBase
    {
        private readonly ILogger<ArSubledgerController> _logger;
        private readonly ICompanyInfoRepository _companyInfoRepository;
        private readonly IMapper _mapper;

        public ArSubledgerController(ILogger<ArSubledgerController> logger,
            ICompanyInfoRepository companyInfoRepository, IMapper mapper)
        {
            _logger = logger;
            _companyInfoRepository = companyInfoRepository;
            _mapper = mapper;
        }

        [HttpGet("{companyId}")]
        public async Task<ActionResult<IEnumerable<ArSubledgerDto>>> GetArSubledgers(int companyId)
        {
            var arSubledgers = await _companyInfoRepository.GetArSubledgersAsync(companyId);
            var result = _mapper.Map<IEnumerable<ArSubledgerDto>>(arSubledgers);
            return Ok(result);
        }

        [HttpGet("arSubledger/{arSubledgerId}")]
        public async Task<ActionResult<ArSubledgerDto>> GetArSubledger(int arSubledgerId)
        {
            var arSubledger = await _companyInfoRepository.GetArSubledgerAsync(arSubledgerId);
            var result = _mapper.Map<ArSubledgerDto>(arSubledger);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ArSubledgerDto>> CreateArSubledger(ArSubledgerDto arSubledgerDto)
        {
            var arSubledger = _mapper.Map<ArSubledger>(arSubledgerDto);
            var result = await _companyInfoRepository.CreateArSubledgerAsync(arSubledger);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ArSubledgerDto>> UpdateArSubledger(ArSubledgerDto arSubledgerDto)
        {
            var arSubledger = _mapper.Map<ArSubledger>(arSubledgerDto);
            var result = await _companyInfoRepository.UpdateArSubledgerAsync(arSubledger);
            return Ok(result);
        }

        [HttpDelete("{arSubledgerId}")]
        public async Task<ActionResult> DeleteArSubledger(int arSubledgerId)
        {
            var result = await _companyInfoRepository.DeleteArSubledgerAsync(arSubledgerId);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}

using HRMS.Api.Dtos;
using HRMS.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> GetCompany(long id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
                return NotFound();
            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCompany([FromBody] CompanyDTO companyDto)
        {
            await _companyService.AddCompanyAsync(companyDto);
            return CreatedAtAction(nameof(GetCompany), new { id = companyDto.CompanyId }, companyDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCompany(long id, [FromBody] CompanyDTO companyDto)
        {
            if (id != companyDto.CompanyId)
                return BadRequest();

            await _companyService.UpdateCompanyAsync(companyDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(long id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}

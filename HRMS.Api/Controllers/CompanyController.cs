using HRMS.Api.Business.CompanyManagement.CompanyRepository;
using HRMS.Api.Business.CompanyManagement.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Api.Controllers
{
    [Route("api/[Controller]")]
    [Authorize]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        [HttpGet("get-company")]
        public async Task<List<CompanyDto>> GetCompany()
        {
            return await companyRepository.GetAllCompony();
        }

        [HttpGet("get-company-by-id/{id}")]
        public async Task<CompanyDto> GetCompanyById([Required]long id)
        {
            return await companyRepository.GetComponyById(id);
        }

        [HttpPost("create-company")]
        public async Task<List<CompanyDto>> CreateCompany([Required] [FromBody] CompanyDto companyDto)
        {
            return await companyRepository.CreateCompany(companyDto);
        }

        [HttpPut("edit-company")]
        public async Task<List<CompanyDto>> EditCompany([Required] [FromBody] CompanyDto companyDto)
        {
            return await companyRepository.EditCompany(companyDto);
        }

        [HttpDelete("delete-company")]
        public async Task<List<CompanyDto>> DeleteCompany([Required] long id)
        {
            return await companyRepository.DeleteCompany(id);
        }
    }
}

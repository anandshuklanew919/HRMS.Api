using HRMS.Api.Business.CompanyManagement.DTO;

namespace HRMS.Api.Business.CompanyManagement.CompanyRepository
{
    public interface ICompanyRepository
    {
        Task<CompanyDto> GetComponyById(long companyid);
        Task<List<CompanyDto>> GetAllCompony();
        Task<List<CompanyDto>> CreateCompany(CompanyDto companyDto);
        Task<List<CompanyDto>> EditCompany(CompanyDto companyDto);
        Task<List<CompanyDto>> DeleteCompany(long companyId);
    }
}

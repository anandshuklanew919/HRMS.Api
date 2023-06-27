using HRMS.Api.Business.CompanyManagement.DTO;
using HRMS.Api.Data.Database;
using HRMS.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Api.Business.CompanyManagement.CompanyRepository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContex _appDbContex;

        public CompanyRepository(AppDbContex appDbContex)
        {
            _appDbContex = appDbContex;
        }

        public async Task<CompanyDto> GetComponyById(long companyid)
        {
            var companyDto = await (from company in _appDbContex.Companies
                                    where company.CompanyId == companyid
                                    select new CompanyDto()
                                    { CompanyId = company.CompanyId, CompanyName = company.CompanyName }
                            ).FirstOrDefaultAsync();

            return companyDto;
        }

        public async Task<List<CompanyDto>> GetAllCompony()
        {
            var companies = await (from company in _appDbContex.Companies
                                   select new CompanyDto()
                                   { CompanyId = company.CompanyId, CompanyName = company.CompanyName }
                            ).ToListAsync();

            return companies;
        }

        public async Task<List<CompanyDto>> CreateCompany(CompanyDto companyDto)
        {
            Company companyToAdd = new Company();
            companyToAdd.CompanyName = companyDto.CompanyName;
            await _appDbContex.AddAsync(companyToAdd);
            await _appDbContex.SaveChangesAsync();

            var companies = await GetAllCompony();
            return companies;
        }


        public async Task<List<CompanyDto>> EditCompany(CompanyDto companyDto)
        {

            var companyToEdit = await _appDbContex.Companies.
                                                  FirstOrDefaultAsync(
                                                   x => companyDto.CompanyId != 0 &&
                                                   x.CompanyId == companyDto.CompanyId);
            if (companyToEdit == null)
                return null;

            companyToEdit.CompanyName = companyDto.CompanyName;

            _appDbContex.Update(companyToEdit);
            await _appDbContex.SaveChangesAsync();

            var companies = await GetAllCompony();
            return companies;
        }


        public async Task<List<CompanyDto>> DeleteCompany(long companyid)
        {
            var companyToDelete = await _appDbContex.Companies.FirstOrDefaultAsync(x=> x.CompanyId == companyid);
            var deletedCompany =  _appDbContex.Companies.Remove(companyToDelete);

            var companies = await GetAllCompony();
            return companies;
        }

    }
}

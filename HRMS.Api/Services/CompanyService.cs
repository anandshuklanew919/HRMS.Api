using HRMS.Api.Data.Entities;
using HRMS.Api.Data.Repositories;
using HRMS.Api.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMS.Api.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CompanyDTO>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllAsync();
            return companies.Select(c => new CompanyDTO
            {
                CompanyId = c.CompanyId,
                CompanyName = c.CompanyName,
                Address = c.Address,
                City = c.City,
                State = c.State,
                Country = c.Country,
                PostalCode = c.PostalCode,
                Phone = c.Phone,
                Email = c.Email,
                Website = c.Website
            });
        }

        public async Task<CompanyDTO> GetCompanyByIdAsync(long id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            return new CompanyDTO
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                Address = company.Address,
                City = company.City,
                State = company.State,
                Country = company.Country,
                PostalCode = company.PostalCode,
                Phone = company.Phone,
                Email = company.Email,
                Website = company.Website
            };
        }

        public async Task AddCompanyAsync(CompanyDTO companyDto)
        {
            var company = new Company
            {
                CompanyName = companyDto.CompanyName,
                Address = companyDto.Address,
                City = companyDto.City,
                State = companyDto.State,
                Country = companyDto.Country,
                PostalCode = companyDto.PostalCode,
                Phone = companyDto.Phone,
                Email = companyDto.Email,
                Website = companyDto.Website
            };

            await _companyRepository.AddAsync(company);
        }

        public async Task UpdateCompanyAsync(CompanyDTO companyDto)
        {
            var company = await _companyRepository.GetByIdAsync(companyDto.CompanyId);
            if (company != null)
            {
                company.CompanyName = companyDto.CompanyName;
                company.Address = companyDto.Address;
                company.City = companyDto.City;
                company.State = companyDto.State;
                company.Country = companyDto.Country;
                company.PostalCode = companyDto.PostalCode;
                company.Phone = companyDto.Phone;
                company.Email = companyDto.Email;
                company.Website = companyDto.Website;

                await _companyRepository.UpdateAsync(company);
            }
        }

        public async Task DeleteCompanyAsync(long id)
        {
            await _companyRepository.DeleteAsync(id);
        }
    }
}

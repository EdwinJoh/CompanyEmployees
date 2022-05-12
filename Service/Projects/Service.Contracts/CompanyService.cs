using AutoMapper;
using Contracts;
using Contracts.Interfaces;
using Entities.Models;
using Service.Contracts.Interfaces;
using Shared.DataTransferObjects;

namespace Service.Projects.ServiceContracts
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {

            var companies = _repository.Company.GetAllCompanies(trackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;

        }
        public CompanyDto GetCompany(Guid id,bool trackChanges)
        {
            var company = _repository.Company.GetCompany(id,trackChanges);
            //check if the company is null

            var companyDto = _mapper.Map<CompanyDto>(company);
            return companyDto;
        }
    }

}


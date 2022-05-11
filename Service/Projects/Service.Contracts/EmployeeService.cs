using Contracts;
using Contracts.Interfaces;
using Service.Contracts.Interfaces;

namespace Service.Projects.ServiceContracts
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        public EmployeeService(IRepositoryManager repository, ILoggerManager
        logger)
        {
            _repository = repository;
            _logger = logger;
        }

    }
}

using AutoMapper;
using EmployeeService.Commands;
using EmployeeService.DTO;
using EmployeeService.Entities;
using EmployeeService.Interfaces;
using EmployeeService.Queries;

namespace EmployeeService.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ISqlRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(ISqlRepository<Employee> employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetAllItemsAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeeById(GetEmployeeByIdQuery request)
        {
            var employee = await _employeeRepository.GetItemByIdAsync(request.Id);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<bool> CreateNewEmployee(CreateNewEmployeeCommand request)
        {
            var newEmployee = _mapper.Map<Employee>(request.Employee);
            var result = await _employeeRepository.AddItemAsync(newEmployee);
            return true;
        }

        public async Task<bool> UpdateEmployee(UpdateEmployeeCommand request)
        {
            var entity = _mapper.Map<Employee>(request.Employee);
            entity.Id = request.Id;
            await _employeeRepository.UpdateItemAsync(entity);
            return true;
        }

        public async Task<bool> SoftDeleteEmployee(SoftDeleteEmployeeCommand request)
        {
            await _employeeRepository.SoftDeleteItemAsync(request.Id);
            return true;
        }

        public async Task<bool> HardDeleteEmployee(HardDeleteEmployeeCommand request)
        {
            await _employeeRepository.HardDeleteItemAsync(request.Id);
            return true;
        }
    }
}

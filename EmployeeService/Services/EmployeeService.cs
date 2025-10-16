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
        private readonly IS3Service _s3Service;

        public EmployeeService(ISqlRepository<Employee> employeeRepository, IMapper mapper, IS3Service s3Service)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _s3Service = s3Service;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _employeeRepository.GetItemsAsync(x => x != null);
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeeById(GetEmployeeByIdQuery request)
        {
            var employee = await _employeeRepository.GetItemMetadataAsync(x => x.EmployeeId == request.Id, x => x.Department, x => x.Position);
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
            var existingEntity = await _employeeRepository.GetItemAsync(request.Id);
            if (existingEntity != null)
            {
                // Map request.Employee into existingEntity.
                var updateEntity = _mapper.Map(request.Employee, existingEntity);
                await _employeeRepository.UpdateItemAsync(existingEntity.EmployeeId, updateEntity);
                return true;
            }
            else
            {
                return false;
            }
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

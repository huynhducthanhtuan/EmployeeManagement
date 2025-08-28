namespace EmployeeService.Interfaces
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file);
    }
}

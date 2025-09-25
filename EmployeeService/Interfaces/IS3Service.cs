namespace EmployeeService.Interfaces
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file);
        string GetPreSignedUrl(string key, int expireMinutes = 10);
    }
}

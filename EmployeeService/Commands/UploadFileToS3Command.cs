using MediatR;

namespace EmployeeService.Commands
{
    public class UploadFileToS3Command : IRequest<string>
    {
        public IFormFile File { get; set; }
    }
}

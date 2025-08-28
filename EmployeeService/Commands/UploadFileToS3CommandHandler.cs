using EmployeeService.Interfaces;
using MediatR;

namespace EmployeeService.Commands
{
    public class UploadFileToS3CommandHandler : IRequestHandler<UploadFileToS3Command, string>
    {
        private readonly IS3Service _s3Service;

        public UploadFileToS3CommandHandler(IS3Service s3Service)
        {
            _s3Service = s3Service;
        }

        public async Task<string> Handle(UploadFileToS3Command request, CancellationToken cancellationToken)
        {
            var result = await _s3Service.UploadFileAsync(request.File);
            return result;
        }
    }
}

using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Core.Domain.ResponseModel;
using Demostudentweb.Shared;

namespace Demostudentweb.Core.Contract
{
    public interface  IStudentService
    {
        Task AddStudentAsync(StudentRequestModel student);
        Task<PagedList<StudentResponseModel>> GetStudentAsync(int page = 1, int pageSize = 25);
        Task<PagedList<StudentResponseModel>> GetStudentByNameAsync(string name=null,int page = 1, int pageSize = 25);

        Task UpdateStudentAsync(StudentRequestModel student,int StudentId);

        Task DeleteStudentAsync(int StudentId);

       
    }
}
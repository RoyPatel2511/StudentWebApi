using Demostudentweb.Infra.Domain.Entities;
using Demostudentweb.Shared;

namespace Demostudentweb.Infra.Contract
{
    public interface IStudentRepository
    {
        Task<PagedList<Student>> GetStudent(int page = 1, int pageSize = 25);
        Task<PagedList<Student>> GetStudentByName(string name=null,int page = 1, int pageSize = 25);

        Task<List<Student>> GetStudentById(int studentId);
        Task<int> Addstudent(Student student);
        Task<Student> GetStudentdata(int studentId);
        Task<int> UpdateStudent(Student student);

     
  
    }
}
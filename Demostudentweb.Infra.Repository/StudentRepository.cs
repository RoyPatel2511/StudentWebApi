using Demostudentweb.Infra.Domain;
using Demostudentweb.Infra.Contract;
using Demostudentweb.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Demostudentweb.Shared;

namespace Demostudentweb.Infra.Repository
{

    public class StudentRepository : IStudentRepository
    {
        private readonly DemostudentwebContext _demostudentwebContext;
        public StudentRepository(DemostudentwebContext demostudentwebContext)
        {
            _demostudentwebContext = demostudentwebContext;
        }   
        public async Task<int> Addstudent(Student student)
        {
            await _demostudentwebContext.AddAsync(student);
            return await _demostudentwebContext.SaveChangesAsync();
        }
      
        public async Task<PagedList<Student>> GetStudent(int page = 1, int pageSize = 25)
        {
            try
            {
                var student = _demostudentwebContext.students.Include(e => e.Course).AsQueryable();
                var count = await student.LongCountAsync();
                var pageList =  student.ToPagedList(page, pageSize, count);

                return pageList;
            }
            catch (Exception)
            {

                throw;
            }
                  
        }

        public async Task<List<Student>> GetStudentById(int studentId)
        {
            var data = await _demostudentwebContext.students.Where(x => x.Id == studentId).ToListAsync();
            return data;
        }

        public async Task<PagedList<Student>> GetStudentByName(string name=null, int page = 1, int pageSize = 25)
        {
            try
            {
                var student = _demostudentwebContext.students.Include(e => e.Course).
                    Where(x => EF.Functions.Like(x.Name,$"%{name}%")).AsQueryable();
                var count = await student.LongCountAsync();
                var pageList = student.ToPagedList(page, pageSize, count);

                return pageList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Student> GetStudentdata(int StudentId)
        {
            var student = await _demostudentwebContext.students.FirstOrDefaultAsync(x => x.Id == StudentId);
            return student;
        }

       
        public async Task<int> UpdateStudent(Student student)
        {
            _demostudentwebContext.students.Update(student);
            return await _demostudentwebContext.SaveChangesAsync();
        }


     
      
    }
}
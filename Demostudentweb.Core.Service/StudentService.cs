using AutoMapper;
using Demostudentweb.Core.Builder;
using Demostudentweb.Core.Contract;
using Demostudentweb.Core.Domain.Exception;
using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Core.Domain.ResponseModel;
using Demostudentweb.Core.Service.Helper;
using Demostudentweb.Infra.Contract;
using Demostudentweb.Infra.Domain;
using Demostudentweb.Infra.Domain.Entities;
using Demostudentweb.Shared;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Demostudentweb.Core.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IFileUploading _fileUploading;
       

         
        public StudentService(IStudentRepository studentRepository, IMapper mapper, IFileUploading fileUploading)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _fileUploading = fileUploading;
        }

        public async Task AddStudentAsync(StudentRequestModel studentModel)
        {
            try
            {

                var fileName = await _fileUploading.UploadPhoto(studentModel.Img);
                var student = StudentBuilder.Build(studentModel, fileName);
                var count = await _studentRepository.Addstudent(student);
                    
                if (count == 0)
                {
                    throw new BadRequestException("Student is not created succssfully.");
                }
            }   
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PagedList<StudentResponseModel>> GetStudentAsync(int page = 1, int pageSize = 25)
        {
            try
            {
                var students = await _studentRepository.GetStudent(page, pageSize);
                var result = _mapper.Map<PagedList<StudentResponseModel>>(students);
                return result;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task DeleteStudentAsync(int studentId)
        {
            try
            {
                var student = await _studentRepository.GetStudentdata(studentId);

                if (student == null)
                {
                    throw new NotFoundException($"Student with {studentId} is not found.");
                }

                student.Delete();
                var count = await _studentRepository.UpdateStudent(student);

                if (count == 0)
                {
                    throw new BadRequestException("Student is not updated succssfully.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateStudentAsync(StudentRequestModel student, int studentId)
        {
            try
            {
                var students = await _studentRepository.GetStudentdata(studentId);

                if (students == null)
                {
                    throw new NotFoundException($"Student with {studentId} is not found.");
                }

                var data = await _studentRepository.GetStudentById(studentId);
                foreach (var item in data)
                {
                    var photoGet = item.Photo;
                    File.Delete(photoGet);

                }

                var photo = await _fileUploading.UploadPhoto(student.Img);
                students.Update(student.Name, student.Email, student.Birthdate, student.CourseId, photo);

                var count = await _studentRepository.UpdateStudent(students);

                if (count == 0)
                {
                    throw new BadRequestException("Student is not updated succssfully.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PagedList<StudentResponseModel>> GetStudentByNameAsync(string name=null, int page = 1, int pageSize = 25)
        {
            try
            {
                var students = await _studentRepository.GetStudentByName(name, page, pageSize);
                var result = _mapper.Map<PagedList<StudentResponseModel>>(students);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}

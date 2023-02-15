using AutoMapper;
using Demostudentweb.Configuration;
using Demostudentweb.Core.Builder;
using Demostudentweb.Core.Domain.Exception;
using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Core.Domain.ResponseModel;
using Demostudentweb.Core.Service;
using Demostudentweb.Core.Service.Helper;
using Demostudentweb.Infra.Contract;
using Demostudentweb.Infra.Domain.Entities;
using Demostudentweb.Infra.Repository;
using Demostudentweb.Shared;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Drawing.Printing;

namespace ServiceTest
{
    public class StudentServiceTest
    {
     
        private readonly Mock<IStudentRepository> _studentRepositoryMock;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;
        private readonly StudentService _studentService;
        private readonly Mock<IFileUploading> _fileUploading;



        public StudentServiceTest()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _fileUploading = new Mock<IFileUploading>();
            config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            mapper = config.CreateMapper();
            _studentService = new StudentService(_studentRepositoryMock.Object, mapper, _fileUploading.Object);

        }

        [Fact]
        //var students = await _studentRepository.GetStudent(page, pageSize);
        //var result = _mapper.Map<PagedList<StudentResponseModel>>(students);
        //        return result;
        public async Task GetStudent_Must_Pass()
        {
            PagedList<Student> studentList = new PagedList<Student>
            {
                Items = StudentList(),
                CurrentPage = 1,
                TotalPage = 1,
                PageSize = 1,
                TotalCount = 1
            };
            _studentRepositoryMock.Setup(repo => repo.GetStudent(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(studentList);
            var result = await _studentService.GetStudentAsync();
            Assert.NotNull(result);
        }


        private List<Student> StudentList()
        {

            List<Student> Students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    Name = "Ritik",
                    Email = "r@gmail.com",
                    Photo="abc.jpg",

                },
                 new Student
                {
                    Id = 2,
                    Name = "henil",
                    Email = "h@gmail.com",
                   Photo="abc.jpg",
                },
        };
            return Students;
        }

        [Fact]
        public async Task Add_Student_Must_Pass()
        {
            StudentRequestModel studentRequestModel = new StudentRequestModel()
            {

                Name = "henil",
                Email = "h@gmail.com",
                Birthdate = DateTime.Now,
                CourseId = 1,
            };
           
            _fileUploading.Setup(fu => fu.UploadPhoto(It.IsAny<IFormFile>())).ReturnsAsync("qwerty");
            _studentRepositoryMock.Setup(sa => sa.Addstudent(It.IsAny<Student>())).ReturnsAsync(1);
            await _studentService.AddStudentAsync(studentRequestModel);

        }
        [Fact]
        public async Task Delete_Student_Must_Pass()
        {
            Student student = new Student()
            {
                Id = 1,
                Name = "ritik",
            };
            _studentRepositoryMock.Setup(gd => gd.GetStudentdata(student.Id)).ReturnsAsync(student);
            _studentRepositoryMock.Setup(sr => sr.UpdateStudent(student)).ReturnsAsync(1);
            await _studentService.DeleteStudentAsync(student.Id);
        }
        [Fact]
        public async Task Update_Data_Must_Pass()
        {
            Student student = new Student()
            {
                Id = 1,
                Name = "ritik",
                Photo = "abc.jpg",
            };
            StudentRequestModel studentRequestModel = new StudentRequestModel()
            {

                Name = "henil",
                Email = "h@gmail.com",
                Birthdate = DateTime.Now,
                CourseId = 1,
            };
            _studentRepositoryMock.Setup(gi => gi.GetStudentdata(student.Id)).ReturnsAsync(student);
            _studentRepositoryMock.Setup(gsi => gsi.GetStudentById(student.Id)).ReturnsAsync(StudentList);
            _fileUploading.Setup(fu => fu.UploadPhoto(It.IsAny<FormFile>())).ReturnsAsync("string");
            _studentRepositoryMock.Setup(sr => sr.UpdateStudent(It.IsAny<Student>())).ReturnsAsync(1);
            await _studentService.UpdateStudentAsync(studentRequestModel, student.Id);
        }
        [Fact]
        public async Task AddStudentAsync_Fail()
        {
            StudentRequestModel studentRequestModel = new StudentRequestModel()
            {
                Name = "henil",
                Email = "h@gmail.com",
                Birthdate = DateTime.Now,
                CourseId = 1,
            };
            var student = new Student();
            _fileUploading.Setup(fu => fu.UploadPhoto(It.IsAny<FormFile>())).ReturnsAsync("string");
            _studentRepositoryMock.Setup(sa => sa.Addstudent(It.IsAny<Student>())).ReturnsAsync(0);
            await Assert.ThrowsAsync<BadRequestException>
            (async () => await _studentService.AddStudentAsync(studentRequestModel));
        }



        [Fact]
        public async Task Delete_Student_ValidId()
        {

            _studentRepositoryMock.Setup(ds => ds.GetStudentdata(It.IsAny<int>())).ReturnsAsync(null as Student);

            await Assert.ThrowsAsync<NotFoundException>
            (async () => await _studentService.DeleteStudentAsync(It.IsAny<int>()));
        }

        [Fact]
        public async Task Delete_Student_Fail()
        {
            Student student = new Student()
            {
                Id = 1,
                Name = "ritik",
            };
            _studentRepositoryMock.Setup(gd => gd.GetStudentdata(student.Id)).ReturnsAsync(student);
            _studentRepositoryMock.Setup(sr => sr.UpdateStudent(It.IsAny<Student>())).ReturnsAsync(0);
            await Assert.ThrowsAsync<BadRequestException>
           (async () => await _studentService.DeleteStudentAsync(student.Id));

        }

        [Fact]
        public async Task Update_Student_ValidId()
        {
            Student student = new Student()
            {
                Id = 1,
                Name = "ritik",
                Photo = "abc.jpg",
            };
            StudentRequestModel studentRequestModel = new StudentRequestModel()
            {

                Name = "henil",
                Email = "h@gmail.com",
                Birthdate = DateTime.Now,
                CourseId = 1,
            };
            _studentRepositoryMock.Setup(gi => gi.GetStudentdata(student.Id)).ReturnsAsync(null as Student);
            await Assert.ThrowsAsync<NotFoundException>
          (async () => await _studentService.UpdateStudentAsync(studentRequestModel, student.Id));
        }

        [Fact]
        public async Task Update_Student_Fail()
        {
            Student student = new Student()
            {
                Id = 1,
                Name = "ritik",
                Photo = "abc.jpg",
            };
            StudentRequestModel studentRequestModel = new StudentRequestModel()
            {

                Name = "henil",
                Email = "h@gmail.com",
                Birthdate = DateTime.Now,
                CourseId = 1,
            };
            _studentRepositoryMock.Setup(gi => gi.GetStudentdata(student.Id)).ReturnsAsync(student);
            _studentRepositoryMock.Setup(gsi => gsi.GetStudentById(student.Id)).ReturnsAsync(StudentList);
            _fileUploading.Setup(fu => fu.UploadPhoto(It.IsAny<FormFile>())).ReturnsAsync("string");
            _studentRepositoryMock.Setup(sr => sr.UpdateStudent(It.IsAny<Student>())).ReturnsAsync(0);
            await Assert.ThrowsAsync<BadRequestException>
            (async () => await _studentService.UpdateStudentAsync(studentRequestModel, student.Id));
        }
        [Fact]
        public async  Task Get_Student_By_Name()
        {
            PagedList<Student> studentList = new PagedList<Student>
            {
                Items = StudentList(),
                CurrentPage = 1,
                TotalPage = 1,
                PageSize = 1,
                TotalCount = 1
            };
            _studentRepositoryMock.Setup(x => x.GetStudentByName(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(studentList);
            var result = await _studentService.GetStudentByNameAsync();
            Assert.NotNull(result);
        }

    }
}
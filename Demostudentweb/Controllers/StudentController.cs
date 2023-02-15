using Demostudentweb.Core.Contract;
using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Core.Service;
using Demostudentweb.Infra.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demostudentweb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    { 
      
        private readonly IStudentService _StudentService;

       public StudentController(IStudentService studentService) 
        {
            
            _StudentService = studentService;
        }

        [HttpPost("students")]
        public async Task<IActionResult>PostStudent([FromForm] StudentRequestModel student)
        {
            await _StudentService.AddStudentAsync(student);
            return Created("students", null);
        }
        [HttpGet("students")]
        public async Task<IActionResult> GetStudents(int page = 1, int pageSize = 25)
        {
           var students=await _StudentService.GetStudentAsync(page, pageSize);
            return Ok(students);
        }
        [HttpGet("studentsbyname")]
        public async Task<IActionResult> GetStudentsByName(string name=null,int page = 1, int pageSize = 25)
        {
            var students = await _StudentService.GetStudentByNameAsync(name,page, pageSize);
            return Ok(students);
        }
        [HttpDelete("students/{id}")]
        public async Task<IActionResult> DeleteCandidates(int id)
        {
            await _StudentService.DeleteStudentAsync(id);
            return NoContent();
        }

    [HttpPut("students/{id}")]
    public async Task<IActionResult> UpadetStudent([FromForm] StudentRequestModel student,int id)
    {
        await _StudentService.UpdateStudentAsync(student,id);
        return NoContent();
    }



      
            
}
}

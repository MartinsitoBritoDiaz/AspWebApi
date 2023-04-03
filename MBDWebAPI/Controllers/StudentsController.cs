using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web_API.Modals;
using Web_API.Services.StudentService;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [SwaggerOperation(Summary = "Get all students")]
        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            try
            {
                var result = await _studentService.GetStudents();

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/<StudentController>
        [SwaggerOperation(Summary = "Create a new student")]
        [HttpPost, Authorize]
        public async Task<ActionResult<bool>> Post([FromBody] Student student)
        {
            try
            {
                await _studentService.CreateStudent(student);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Get By Id api/<StudentController>
        [SwaggerOperation(Summary = "Get student by id")]
        [HttpGet("{id}")]
        public async Task<ActionResult<bool>> GetById(int id)
        {
            try
            {
                var result = await _studentService.GetStudentById(id);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Update api/<StudentController>
        [SwaggerOperation(Summary = "Update a student ")]
        [HttpPut, Authorize]
        public async Task<ActionResult<Student>> Update(Student student)
        {
            try
            {
                var result = await _studentService.UpdateStudent(student);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Delete api/<StudentController>
        [SwaggerOperation(Summary = "Delete a student")]
        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                await _studentService.DeleteStudentById(id);

                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

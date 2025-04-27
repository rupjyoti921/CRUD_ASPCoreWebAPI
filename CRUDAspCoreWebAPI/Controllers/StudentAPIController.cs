using System.Reflection.Metadata.Ecma335;
using CRUDAspCoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDAspCoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MyDbContext context;

        public StudentAPIController(MyDbContext context)
        {
            this.context = context;
        }
        //Get Request
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudets()
        {
            var data= await context.Students.ToListAsync();
            return Ok(data);
        }

        //Get Request with ID
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Student>>> GetStudetsByID(int id)
        {
            var data = await context.Students.FindAsync(id);
            if (data == null)
            {
                return NotFound(); 
            }
            return Ok(data);
        }

        //Post Request
        [HttpPost()]
        public async Task<ActionResult<string>> CreateStudent(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
            return Ok(student);
            
        }

        //Put Request with id
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateStudent(int id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            context.Entry(student).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(student);

        }

        //Delete Request with id
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteStudent(int id)
        {
            var std = await context.Students.FindAsync(id);
            if (std == null)
            {
                return BadRequest();
            }
            var temp = std;
            context.Students.Remove(std);
            await context.SaveChangesAsync();
            return Ok(temp);
        }
    }
} 

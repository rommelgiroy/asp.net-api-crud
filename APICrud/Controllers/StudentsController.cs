using APICrud.Contracts;
using APICrud.Models;
using APICrud.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace APICrud.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _student;

    public StudentsController(IStudentRepository student)
    {
        _student = student;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudent()
    {
        var student = await _student.GetAllStudents();
        return Ok(student);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetStudent(int id)
    {
        var student = await _student.GetStudent(id);

        if (id == 0)
            return BadRequest();

        return Ok(student);

    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] Student student)
    {
        await _student.CreateStudent(student);
        return Ok(student);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateStudent([FromBody] Student student)
    {
        await _student.UpdateStudent(student);
        return Ok(student);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        await _student.DeleteStudent(id);
        return Ok();
    }   
}

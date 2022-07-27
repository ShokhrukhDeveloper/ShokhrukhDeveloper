using dtos;
using Microsoft.AspNetCore.Mvc;

namespace student.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController:ControllerBase
{   
    [HttpGet]
    public IActionResult GetStudents(){
        var students=StudentDTO.Students;
        if(!students.Any())return NoContent();
        return Ok(students);
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetStudentsById(Guid Id)
    {
        var student=StudentDTO.Students.Find(s=>s.Id==Id);
        if(student is not StudentDTO)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpPost]
    public IActionResult CreateStudent(StudentDTO studentDTO)
    {
        studentDTO.Id=Guid.NewGuid();
        StudentDTO.Students.Add(studentDTO);
        return Created("Successfully created",studentDTO);
    }

    [HttpDelete]
    [Route("{Id}")]
    public IActionResult DeleteStudentById(Guid Id)
    {
        var student=StudentDTO.Students.Find(s=>s.Id==Id);
        if(student is not StudentDTO)
        {
            return NotFound();
        }
        StudentDTO.Students.Remove(student);
        return Ok("Successfully deleted");
    }
    
    [HttpPut]
    public IActionResult UpdateStudent(StudentDTO student)
    {
        var studentDTO=StudentDTO.Students.Find(s=>s.Id==student.Id);
        if(studentDTO is not StudentDTO)
        {
            return NotFound();
        }
        StudentDTO.Students.Remove(studentDTO);
        StudentDTO.Students.Add(student);
        return Ok("Successfully updated");
    }
    
}
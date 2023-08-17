using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystemAPI.Data;
using System.Net;
using System.Reflection;

namespace StudentRegistrationSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegistrationController : ControllerBase
    {
    private readonly DataContex _context;

    public StudentRegistrationController(DataContex context)
    {
      _context = context;
    }

    [HttpGet]
        public async Task<ActionResult<List<StudentRegistration>>> GetStudentRegistration()
        {
      return Ok(await _context.RegisteredStudents.ToListAsync());
        }

    [HttpPost]
    public async Task<ActionResult<List<StudentRegistration>>> CreateStudentRegistration(StudentRegistration student)
    {
      _context.RegisteredStudents.Add(student);
      await _context.SaveChangesAsync();

      return Ok(await _context.RegisteredStudents.ToListAsync());
    }



    [HttpPut]
    public async Task<ActionResult<List<StudentRegistration>>> UpdateStudentRegistration (StudentRegistration student)
    {
      var dbStudent = await _context.RegisteredStudents.FindAsync(student.Id);
      if (dbStudent == null)
      {
        return BadRequest("Student Not Found");
      }

      dbStudent.Id = student.Id;
      dbStudent.FirstName = student.FirstName;
      dbStudent.LastName = student.LastName;
      dbStudent.Mobile = student.Mobile;
      dbStudent.Email = student.Email;
      dbStudent.DOB = student.DOB;
      dbStudent.Address = student.Address;
      dbStudent.NIC = student.NIC;

      await _context.SaveChangesAsync();

      return Ok(await _context.RegisteredStudents.ToListAsync());
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<List<StudentRegistration>>> DeleteStudentRegistration (int id)
    {
      var dbStudent = await _context.RegisteredStudents.FindAsync(id);
      if (dbStudent == null)
      {
        return BadRequest("Student Not Found");
      }

      _context.RegisteredStudents.Remove(dbStudent);
      await _context.SaveChangesAsync();

      return Ok(await _context.RegisteredStudents.ToListAsync());

    }



  }
}

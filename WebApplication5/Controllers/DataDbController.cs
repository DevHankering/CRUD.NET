using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.DTO;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataDbController : ControllerBase
    {


        private readonly DataDbContext _dbContext;

        public DataDbController(DataDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllData()
        {
            var studentModels = _dbContext.Student.ToList();


            return Ok(studentModels);
        }

        //[HttpGet]
        //[Route("/get/{id}")]
        //public IActionResult GetDataById(int id)
        //{
        //    var student = _dbContext.Student.Find(id);

        //    if (student is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(student);
        //}


        [HttpGet]
        [Route("/get/{id}")]
        public IActionResult GetDataById(int id)
        {
            var student = _dbContext.Student
                .Include(s => s.Address)  
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }



        [HttpPost]
        [Route("/AddStudents")]
        public IActionResult AddStrudent(StudentDto studentDto)
        {


            var StudentEntity = new StudentModel()
            {
                Email = studentDto.Email,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                PhoneNumber = studentDto.PhoneNumber,
                //shekhar 
                 //Address = new



            };

            _dbContext.Student.Add(StudentEntity);
            _dbContext.SaveChanges();


            return Ok(studentDto);



        }

        [HttpPut]
        [Route("/UpdateStudents/{id}")]

        public IActionResult UpdateStudent(int id, StudentUpadateDto studentUpadateDto)
        {
            var updateStudent = _dbContext.Student.Find(id);
 
            if(updateStudent is null)
            {
                return NotFound();
            }

            updateStudent.FirstName = studentUpadateDto.FirstName;
            updateStudent.LastName = studentUpadateDto.LastName;
            updateStudent.Email = studentUpadateDto.Email;
            updateStudent.PhoneNumber = studentUpadateDto.PhoneNumber;
           // updateStudent.Address_Id = studentUpdateDto.Address_Id;

            _dbContext.SaveChanges();

            return Ok(updateStudent);
        }


        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteStudentById(Guid id)
        {
            var student = _dbContext.Student.Find(id);
            if(student is null)
            {
                return NotFound();
            }

            _dbContext.Student.Remove(student);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Route("/getStudentDataWithAddress/")]

        public IActionResult GetStudentWithAddress()
        {
            var studentAddress = _dbContext.Address.ToList();

            return Ok(studentAddress);
        }

        [HttpPost]
        [Route("/addAddress")]

        public IActionResult addAddress(StudentAddressDto studentAddressDto)
        {
            var studentAddressEntity = new StudentAddress()
            {
                State = studentAddressDto.State,
                City = studentAddressDto.City,
                PINCODE = studentAddressDto.PINCODE,
            };

            _dbContext.Address.Add(studentAddressEntity);
            _dbContext.SaveChanges();

            return Ok(studentAddressEntity);
        }
    }
}

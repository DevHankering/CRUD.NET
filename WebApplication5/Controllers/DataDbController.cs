using System;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DataDbController(DataDbContext dbContext, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
        }



        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllData()
        {
            var student = _dbContext.Student
                .Include(a => a.Address)
                .Include(b => b.Image)
                .Select(c => new StudentAddressImageDto()
                {
                   FirstName = c.FirstName,
                   LastName = c.LastName,
                   Email = c.Email,
                   PhoneNumber = c.PhoneNumber,
                   State =c.Address.State,
                   City = c.Address.City,
                   PINCODE = c.Address.PINCODE,
                   FileName = c.Image.FileName,
                   FileDescription = c.Image.FileExtension,
                   FileExtension = c.Image.FileExtension,
                   FilePath = c.Image.FilePath,
                   FileSizeInBytes = c.Image.FileSizeInBytes,
                })
                .ToList();

            return Ok(student);
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
            //var student = _dbContext.Student
            //    .Include(s => s.Address)
            //    .FirstOrDefault(s => s.StudentId == id);
            var student = _dbContext.Student
                //.Include(a => a.Address)
                //.Include(b => b.Image)
                .FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            //var filePath = student.UrlFilePath;
            //var filename = student.ImageFileName;
            //var filename = student.

            //if (!System.IO.File.Exists(filePath))
            //{
            //    return NotFound("File not found.");
            //}

            //var fileBytes = System.IO.File.ReadAllBytes(filePath);
            //var fileExtension = Path.GetExtension(student.UrlFilePath.
            //Uri uri = new Uri(filePath);
            //string fileExtension = Path.GetExtension(uri.AbsolutePath);

            //return File(fileBytes, "application/octet-stream", $"{filename}{fileExtension}"); 


            return Ok(student);
        }



        [HttpPost]
        [Route("/AddStudents")]
        public async Task<IActionResult> AddStudent([FromForm] StudentDto studentDto)
        {

          
            //public async Task<IActionResult> UploadFile([FromForm] FileUploadModel model)
            //{
                if (studentDto.ImageFile == null || studentDto.ImageFile.Length == 0)
                {
                    return BadRequest("No file uploaded.");
                }

                // Process the file (e.g., save it to disk or a database)
                var filePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images\\StudentImages", studentDto.ImageFile.FileName);
            var FileName = studentDto.ImageFile.FileName;


            using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await studentDto.ImageFile.CopyToAsync(stream);
                }

            //var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/StudentImages{studentDto.ImageFile.FileName}{Path.GetExtension(studentDto.ImageFile.FileName)}";


            var studentDomainModel = new StudentModel()
            {
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Email = studentDto.Email,
                PhoneNumber = studentDto.PhoneNumber,
                //LocalFilePath = filePath,
                //UrlFilePath = filePath,
                //ImageFileName = studentDto.ImageFileName,
            };

            //return Ok(new { FilePath = filePath });
            await _dbContext.Student.AddAsync(studentDomainModel);
            await _dbContext.SaveChangesAsync();
            return Ok(studentDomainModel);

            //}









            //var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images/StudentImages", $"{studentDto.ImageFileName}{Path.GetExtension(studentDto.ImageFile.FileName)}");

            //upload image to local path
            //using var stream = new FileStream(localFilePath, FileMode.Create);
            //studentDto.ImageFile.CopyTo(stream);

            //var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/StudentImages{studentDto.ImageFileName}{Path.GetExtension(studentDto.ImageFile.FileName)}";



            //var StudentEntity = new StudentModel()
            //{
            //Email = studentDto.Email,
            //FirstName = studentDto.FirstName,
            //LastName = studentDto.LastName,
            //PhoneNumber = studentDto.PhoneNumber,
            //ImageFile = studentDto.ImageFile,


            //shekhar 
            //Address = new 

            //};

            //StudentEntity.UrlFilePath = urlFilePath;
            //StudentEntity.LocalFilePath = localFilePath;


            //_dbContext.Student.Add(StudentEntity);
            //_dbContext.SaveChanges();


            //return Ok(studentDto);



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
            var studentAddress = _dbContext.Student.ToList();

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

        [HttpPost]
        [Route("studentwithaddress")]

        public async Task<IActionResult> PostDataWithAddress([FromBody] StudentAddressDto studentAddressDto)
        {
            if (studentAddressDto == null)
            {
                return BadRequest("Invalid data.");
            }

            //using var transaction = await _dbContext.Database.BeginTransactionAsync();

            //step 1: create the address (linked to the students)

            var address = new StudentAddress
            {
                State = studentAddressDto.State,
                City = studentAddressDto.City,
                PINCODE = studentAddressDto.PINCODE,
            };
            _dbContext.Address.Add(address);      // add address data to the dbContext
            await _dbContext.SaveChangesAsync();  // save address data


            //step2.   //Create the student
            var student = new StudentModel
            {
                FirstName = studentAddressDto.FirstName,
                LastName = studentAddressDto.Email,
                PhoneNumber = studentAddressDto.PhoneNumber,
                //Address_Id = address.AddressId,
            };

            _dbContext.Student.Add(student);      //add student data to the doContext
            await _dbContext.SaveChangesAsync(); // save student data




            //commit  the transaction

            //await transaction.CommitAsync();

            //Map Domain Model back to DTO
            var response = new ResponseStudentAddressDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                PhoneNumber = student.PhoneNumber,
                Email = student.Email,
                StudentId = student.StudentId,
                AddressId = address.AddressId,
                State = address.State,
                City = address.City,
                PINCODE = address.PINCODE,

            };


            return CreatedAtAction(nameof(GetDataById), new {Id = response.StudentId}, response);
        }



        [HttpGet]
        [Route("/getStudentAddressData")]

        public async Task<IActionResult> getStudentAddressDatta()
        {
            throw new Exception();
            //var studentAddressData = await (from student in _dbContext.Student
            //                                join address in _dbContext.Address
            //                                on student.Address_Id equals address.AddressId
            //                                select new StudentAddressDto
            //                                {
            //                                    StudentId = student.StudentId,
            //                                    FirstName = student.FirstName,
            //                                    LastName = student.LastName,
            //                                    PhoneNumber = student.PhoneNumber,
            //                                    Address = new AddressDto()
            //                                    {
            //                                        State = address.State,
            //                                        City = address.City,
            //                                        PINCODE = address.PINCODE
            //                                    }


            //                                }).ToListAsync();

            var studentAddressData = await _dbContext.Student
                                         .Include(x => x.Address)
                                         .Select(x => new StudentAddressDto
                                         {
                                             StudentId = x.StudentId,
                                             FirstName = x.FirstName,
                                             LastName = x.LastName,
                                             PhoneNumber = x.PhoneNumber,
                                             State = x.Address.State,
                                             City = x.Address.State
                                         }).ToListAsync();


            return Ok(studentAddressData);

        }

        //[HttpGet("download/{filename}")]
        //[HttpGet]


        //public IActionResult DownloadImage(string filename)
        //{

        //    var filePath = Path.Combine(_uploadDirectory, filename);

        //    if (!System.IO.File.Exists(filePath))
        //    {
        //        return NotFound("File not found.");
        //    }

        //    var fileBytes = System.IO.File.ReadAllBytes(filePath);
        //    return File(fileBytes, "application/octet-stream", filename);
        //}




        [HttpPost]
        [Route("UploadImages")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {

            ValidateFileUpload(request);
            if (ModelState.IsValid)   // ModelState.IsValid return boolean vlaue
            {
                //user repository to upload image 
                // convert Dto to domain model
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length, // request.File.Length --> it is generated by the system
                    FileName = request.FileName, // request.FileName --> because it is given by user.
                    FileDescription = request.FileDescription,
                };

                var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{request.FileName}{Path.GetExtension(request.File.FileName)}");// webHostEnvironment.ContenRootPath is used to navigate the path , Images is folderName,  request.FileName is the file name., 
                                                                                                                                                                //upload image to lacal path
                using var stream = new FileStream(localFilePath, FileMode.Create); //FileMode.Create creates the folder and file --> thtis line generally creates the file and folder into your local machine
                await request.File.CopyToAsync(stream); // --> this puts the file into stream. // these two lines, we are going to upload the image.


                //creating a path for our file
                //https://localhost:1234/images/image.jpg
                var urlFilePath = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}/Images/{request.FileName}{Path.GetExtension(request.File.FileName)}";

                imageDomainModel.FilePath = urlFilePath;
                await _dbContext.Images.AddAsync(imageDomainModel);
                await _dbContext.SaveChangesAsync();

                return Ok(imageDomainModel);
            }
            return BadRequest(ModelState);
        }
        //Here we are adding vaidation for ImageUloadRequestDto;
        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new string[] { ".jpg", "jpeg", ".png", ".pdf", ".PNG" };

            if (!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsupported file extension"); // it takes two parameters one is the key and the other is errorMessage

            }
            if (request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size more than 10MB, Please upload a smaller size file");
            }
        }


        [HttpGet]
        [Route("GetAllImages")]

        public async Task<IActionResult> GetAll()
        {
            var GetImages = await _dbContext.Images.ToListAsync();

            return Ok(GetImages);
        }






        [HttpPost]
        [Route("Image+Student+Address")]

        public async Task<IActionResult> Upload([FromForm] StudentAddressImageDto studentAddressImageDto)
        {
            var totalDetails = new StudentModel()
            {
                FirstName = studentAddressImageDto.FirstName,
                LastName= studentAddressImageDto.LastName,
                PhoneNumber = studentAddressImageDto.PhoneNumber,
                Email   = studentAddressImageDto.Email,
                Address = new StudentAddress()
                {
                    State = studentAddressImageDto.State,
                    City= studentAddressImageDto.City,
                    PINCODE = studentAddressImageDto.PINCODE,
                },
                Image = new Image()
                {
                    //File = studentAddressImageDto.FullName,
                    FileName = studentAddressImageDto.FileName,
                    FileDescription = studentAddressImageDto.FileDescription,
                    FileExtension = studentAddressImageDto.FileExtension,
                    FilePath    = studentAddressImageDto.FilePath,
                    FileSizeInBytes = studentAddressImageDto.FileSizeInBytes,
                }
            };

            await _dbContext.AddAsync(totalDetails);
            await _dbContext.SaveChangesAsync();
            return Ok(totalDetails);
        }

        [HttpGet]
        [Route("GetTotalData(student+address+image)")]
        public async Task<IActionResult> totalDetail()
        {
            var totalData = await _dbContext.Student
                .Include(a => a.Address)
                .Include(i => i.Image)
                .Select( x => new StudentAddressImageDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    State = x.Address.State,
                    City = x.Address.City,
                    PINCODE = x.Address.PINCODE,
                    FileName = x.Image.FileName,
                    FileDescription = x.Image.FileDescription,
                    FileExtension = x.Image.FileExtension,
                    FilePath = x.Image.FilePath,
                    FileSizeInBytes = x.Image.FileSizeInBytes,
                })
                .ToListAsync();
             _dbContext.SaveChanges();

            return Ok(totalData);
        }
      
            
    }
}

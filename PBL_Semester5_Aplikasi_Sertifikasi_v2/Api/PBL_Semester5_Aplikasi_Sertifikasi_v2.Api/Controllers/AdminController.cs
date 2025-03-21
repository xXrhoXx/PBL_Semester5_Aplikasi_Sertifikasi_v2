using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private DemoDbContext _demoDbContext;
        public AdminController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Admin>> Get()
        {
            return _demoDbContext.admins;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Admin?>> GetById(int id)
        {
            return await _demoDbContext.admins.Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        [HttpPost]
        public async Task<ActionResult> Create(Admin admin)
        {
            // Create a new instance with a hashed password
            var accessorWithHashedPassword = admin with
            {
                Password = HashPassword(admin.Password)
            };

            await _demoDbContext.admins.AddAsync(accessorWithHashedPassword);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessorWithHashedPassword.Id }, accessorWithHashedPassword);
        }


        [HttpPut]
        public async Task<ActionResult> Update(Admin admin)
        {
            // Create a new instance with a hashed password
            var accessorWithHashedPassword = admin with
            {
                Password = HashPassword(admin.Password)
            };

            _demoDbContext.admins.Update(accessorWithHashedPassword);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productGetByIdResult = await GetById(id);
            if (productGetByIdResult is null)
                return NotFound();

            _demoDbContext.Remove(productGetByIdResult.Value);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpPost("validate")]
        public async Task<ActionResult<Admin?>> ValidateUser([FromBody] UserValidationRequest request)
        {
            var admin = await _demoDbContext.admins
                .Where(x => x.Nama == request.Username && x.Email == request.Email)
                .SingleOrDefaultAsync();

            if (admin == null)
                return NotFound("User not found");

            // Example for password verification (assumes hashed passwords):
            //if (request.Password != admin.Password)
            //    return Unauthorized("Invalid password");
            // Example for password verification (assumes hashed passwords):
            if (!VerifyPassword(request.Password, admin.Password))
                return Unauthorized("Invalid password");

            return Ok(admin);
        }

        // Example password verification
        private bool VerifyPassword(string password, string passwordHash)
        {
            // Use a library like BCrypt or similar for hashing
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

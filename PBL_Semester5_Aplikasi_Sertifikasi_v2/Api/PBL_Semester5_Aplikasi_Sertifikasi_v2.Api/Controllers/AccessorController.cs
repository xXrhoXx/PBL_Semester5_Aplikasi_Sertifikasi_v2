using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;
using System.Collections;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessorController : ControllerBase
    {
        private DemoDbContext _demoDbContext;
        public AccessorController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Accessor>> Get()
        {
            return _demoDbContext.accessors;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Accessor?>> GetById(int id)
        {
            return await _demoDbContext.accessors.Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        /*
        [HttpGet("{username}, {email}, {password}")]
        public async Task<ActionResult<Accessor?>> GetAuthenticate(string username, string email, string password)
        {
            return await _demoDbContext.accessors.Where(x => x.Email == password).SingleOrDefaultAsync();
        }
        */


        /*
        [HttpPost]
        public async Task<ActionResult> Create(Accessor accessor)
        {
            await _demoDbContext.accessors.AddAsync(accessor);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessor.Id }, accessor);
        }
        */
        [HttpPost]
        public async Task<ActionResult> Create(Accessor accessor)
        {
            // Create a new instance with a hashed password
            var accessorWithHashedPassword = accessor with
            {
                Password = HashPassword(accessor.Password)
            };

            await _demoDbContext.accessors.AddAsync(accessorWithHashedPassword);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessorWithHashedPassword.Id }, accessorWithHashedPassword);
        }


        /*
        [HttpPut]
        public async Task<ActionResult> Update(Accessor accessor)
        {
            _demoDbContext.accessors.Update(accessor);  
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }
        */
        [HttpPut]
        public async Task<ActionResult> Update(Accessor accessor)
        {
            // Create a new instance with a hashed password
            var accessorWithHashedPassword = accessor with
            {
                Password = HashPassword(accessor.Password)
            };

            _demoDbContext.accessors.Update(accessorWithHashedPassword);
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
        public async Task<ActionResult<Accessor?>> ValidateUser([FromBody] UserValidationRequest request)
        {
            var accessor = await _demoDbContext.accessors
                .Where(x => x.Nama == request.Username && x.Email == request.Email)
                .SingleOrDefaultAsync();

            if (accessor == null)
                return NotFound("User not found");

            // Example for password verification (assumes hashed passwords):
            //if (request.Password != accessor.Password)
            //    return Unauthorized("Invalid password");
            // Example for password verification (assumes hashed passwords):
            if (!VerifyPassword(request.Password, accessor.Password))
                return Unauthorized("Invalid password");

            return Ok(accessor);
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessedController : ControllerBase
    {
        private DemoDbContext _demoDbContext;
        public AccessedController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Accessed>> Get()
        {
            return _demoDbContext.accesseds;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Accessed?>> GetById(int id)
        {
            return await _demoDbContext.accesseds.Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        /*
        [HttpPost]
        public async Task<ActionResult> Create(Accessed accessed)
        {
            await _demoDbContext.accesseds.AddAsync(accessed);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessed.Id }, accessed);
        }
        */
        [HttpPost]
        public async Task<ActionResult> Create(Accessed accessed)
        {
            // Create a new instance with a hashed password
            var accessorWithHashedPassword = accessed with
            {
                Password = HashPassword(accessed.Password)
            };

            await _demoDbContext.accesseds.AddAsync(accessorWithHashedPassword);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessorWithHashedPassword.Id }, accessorWithHashedPassword);
        }


        /*
        [HttpPut]
        public async Task<ActionResult> Update(Accessed accessed)
        {
            _demoDbContext.accesseds.Update(accessed);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }
        */
        [HttpPut]
        public async Task<ActionResult> Update(Accessed accessed)
        {
            // Create a new instance with a hashed password
            var accessorWithHashedPassword = accessed with
            {
                Password = HashPassword(accessed.Password)
            };

            _demoDbContext.accesseds.Update(accessorWithHashedPassword);
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
        public async Task<ActionResult<Accessed?>> ValidateUser([FromBody] UserValidationRequest request)
        {
            var accessor = await _demoDbContext.accesseds
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

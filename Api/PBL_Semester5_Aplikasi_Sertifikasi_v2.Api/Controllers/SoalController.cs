using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoalController : ControllerBase
    {
        private DemoDbContext _demoDbContext;
        public SoalController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Questions>> Get()
        {
            return _demoDbContext.questions;
        }


        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Questions?>> GetById(int id)
        {
            return await _demoDbContext.questions.Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        /*
        [HttpGet("by-accessor/{accessorId}")]
        public async Task<ActionResult<Questions?>> GetByAccessorId(int accessorId)
        {
            return await _demoDbContext.questions.Where(x => x.AccessorId == accessorId).SingleOrDefaultAsync();
        }
        */
        [HttpGet("by-accessor/{accessorId}")]
        public async Task<ActionResult<List<Questions>>> GetByAccessorId(int accessorId)
        {
            var questions = await _demoDbContext.questions
                .Where(x => x.AccessorId == accessorId)
                .ToListAsync();

            if (questions == null || questions.Count == 0)
                return NotFound();

            return Ok(questions);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Questions accessor)
        {
            await _demoDbContext.questions.AddAsync(accessor);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessor.Id }, accessor);
        }


        [HttpPut]
        public async Task<ActionResult> Update(Questions accessor)
        {
            _demoDbContext.questions.Update(accessor);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productGetByIdResult = await GetById(id);
            if (productGetByIdResult == null)
                return NotFound();

            _demoDbContext.Remove(productGetByIdResult.Value);
            await _demoDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

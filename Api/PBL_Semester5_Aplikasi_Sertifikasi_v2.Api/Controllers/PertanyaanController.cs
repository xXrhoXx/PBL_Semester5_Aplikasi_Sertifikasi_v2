using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PertanyaanController : ControllerBase
    {
        private DemoDbContext _demoDbContext;
        public PertanyaanController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Question>> Get()
        {
            return _demoDbContext.question;
        }


        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Question?>> GetById(int id)
        {
            return await _demoDbContext.question.Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        [HttpGet("by-questions/{questionsId}")]
        public async Task<ActionResult<List<Question>>> GetByAccessorId(int questionsId)
        {
            var question = await _demoDbContext.question
                .Where(x => x.QuestionsId == questionsId)
                .ToListAsync();

            if (question == null || question.Count == 0)
                return NotFound();

            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Question accessor)
        {
            await _demoDbContext.question.AddAsync(accessor);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessor.Id }, accessor);
        }


        [HttpPut]
        public async Task<ActionResult> Update(Question accessor)
        {
            _demoDbContext.question.Update(accessor);
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

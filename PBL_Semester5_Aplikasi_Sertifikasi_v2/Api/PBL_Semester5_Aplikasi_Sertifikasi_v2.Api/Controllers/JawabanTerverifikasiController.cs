using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JawabanTerverifikasiController : ControllerBase
    {
        private DemoDbContext _demoDbContext;
        public JawabanTerverifikasiController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;


        [HttpGet]
        public ActionResult<IEnumerable<AnswerVerified>> Get()
        {
            return _demoDbContext.answerVerified;
        }


        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<AnswerVerified?>> GetById(int id)
        {
            return await _demoDbContext.answerVerified.Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        [HttpGet("by-accessor/{accessorId}")]
        public async Task<ActionResult<List<AnswerVerified>>> GetByAccessorId(int accessorId)
        {
            var answerVerified = await _demoDbContext.answerVerified
                .Where(x => x.AccessorId == accessorId)
                .ToListAsync();

            if (answerVerified == null || answerVerified.Count == 0)
                return NotFound();

            return Ok(answerVerified);
        }


        [HttpGet("by-accessed/{accessedId}")]
        public async Task<ActionResult<List<AnswerVerified>>> GetByAccessedId(int accessedId)
        {
            var answerVerified = await _demoDbContext.answerVerified
                .Where(x => x.AccessedId == accessedId)
                .ToListAsync();

            if (answerVerified == null || answerVerified.Count == 0)
                return NotFound();

            return Ok(answerVerified);
        }


        [HttpGet("by-questions/{questionsId}")]
        public async Task<ActionResult<List<AnswerVerified>>> GetByQuestionsId(int questionsId)
        {
            var answerVerified = await _demoDbContext.answerVerified
                .Where(x => x.QuestionsId == questionsId)
                .ToListAsync();

            if (answerVerified == null || answerVerified.Count == 0)
                return NotFound();

            return Ok(answerVerified);
        }


        [HttpGet("by-assessment-session-id/{assessmentSessionId}")]
        public async Task<ActionResult<List<AnswerVerified>>> GetByQuestionId(int assessmentSessionId)
        {
            var answerVerified = await _demoDbContext.answerVerified
                .Where(x => x.AssessmentSessionId == assessmentSessionId)
                .ToListAsync();

            if (answerVerified == null || answerVerified.Count == 0)
                return NotFound();

            return Ok(answerVerified);
        }


        /*
        [HttpGet("by-answer/{answerId}")]
        public async Task<ActionResult<List<AnswerVerified>>> GetByAnswerId(int answerId)
        {
            var answerVerified = await _demoDbContext.answerVerified
                .Where(x => x.AnswerId == answerId)
                .ToListAsync();

            if (answerVerified == null || answerVerified.Count == 0)
                return NotFound();

            return Ok(answerVerified);
        }
        */


        [HttpPost]
        public async Task<ActionResult> Create(AnswerVerified accessor)
        {
            await _demoDbContext.answerVerified.AddAsync(accessor);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessor.Id }, accessor);
        }


        [HttpPut]
        public async Task<ActionResult> Update(AnswerVerified accessor)
        {
            _demoDbContext.answerVerified.Update(accessor);
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

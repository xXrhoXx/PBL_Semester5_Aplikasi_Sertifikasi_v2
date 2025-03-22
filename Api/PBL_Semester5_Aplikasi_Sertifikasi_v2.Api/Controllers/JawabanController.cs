using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Services;
using MimeTypes = MimeKit.MimeTypes;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JawabanController : ControllerBase
    {
        private DemoDbContext _demoDbContext;
        public JawabanController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Answer>> Get()
        {
            return _demoDbContext.answer;
        }


        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Answer?>> GetById(int id)
        {
            return await _demoDbContext.answer.Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        [HttpGet("by-accessor/{accessorId}")]
        public async Task<ActionResult<List<Answer>>> GetByAccessorId(int accessorId)
        {
            var answer = await _demoDbContext.answer
                .Where(x => x.AccessorId == accessorId)
                .ToListAsync();

            if (answer == null || answer.Count == 0)
                return NotFound();

            return Ok(answer);
        }


        [HttpGet("by-accessed/{accessedId}")]
        public async Task<ActionResult<List<Answer>>> GetByAccessedId(int accessedId)
        {
            var answer = await _demoDbContext.answer
                .Where(x => x.AccessedId == accessedId)
                .ToListAsync();

            if (answer == null || answer.Count == 0)
                return NotFound();

            return Ok(answer);
        }


        [HttpGet("by-questions/{questionsId}")]
        public async Task<ActionResult<List<Answer>>> GetByQuestionsId(int questionsId)
        {
            var answer = await _demoDbContext.answer
                .Where(x => x.QuestionsId == questionsId)
                .ToListAsync();

            if (answer == null || answer.Count == 0)
                return NotFound();

            return Ok(answer);
        }


        [HttpGet("by-question/{questionId}")]
        public async Task<ActionResult<List<Answer>>> GetByQuestionId(int questionId)
        {
            var answer = await _demoDbContext.answer
                .Where(x => x.QuestionId == questionId)
                .ToListAsync();

            if (answer == null || answer.Count == 0)
                return NotFound();

            return Ok(answer);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Answer accessor)
        {
            await _demoDbContext.answer.AddAsync(accessor);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessor.Id }, accessor);
        }


        [HttpPost("upload-file")]
        public IActionResult UploadFile(IFormFile? file)
        {
            return Ok(new UploadHandler().Upload(file));
        }


        [HttpGet("download-file")]
        public IActionResult Download(string fileName)
        {
            // Define the path to the Uploads directory
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            // Construct the full path to the file
            string fullPath = Path.Combine(path, fileName);

            // Check if the file exists
            if (!System.IO.File.Exists(fullPath))
            {
                return NotFound("File not found.");
            }

            // Get the file's content type (e.g., application/pdf, image/jpeg)
            string contentType = MimeTypes.GetMimeType(fullPath);

            // Return the file to the client
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            return File(fileBytes, contentType, fileName);
        }


        [HttpPut]
        public async Task<ActionResult> Update(Answer accessor)
        {
            _demoDbContext.answer.Update(accessor);
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

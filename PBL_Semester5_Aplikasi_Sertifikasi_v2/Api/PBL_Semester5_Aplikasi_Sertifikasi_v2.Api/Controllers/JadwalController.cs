using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalController : ControllerBase
    {
        private DemoDbContext _demoDbContext;
        public JadwalController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<Schedule>> Get()
        {
            return _demoDbContext.schedules;
        }


        [HttpGet("by-id/{id}")]
        public async Task<ActionResult<Schedule?>> GetById(int id)
        {
            return await _demoDbContext.schedules.Where(x => x.Id == id).SingleOrDefaultAsync();
        }


        [HttpGet("by-accessor/{accessorId}")]
        public async Task<ActionResult<List<Schedule>>> GetByAccessorId(int accessorId)
        {
            var schedules = await _demoDbContext.schedules
                .Where(x => x.AccessorID == accessorId)
                .ToListAsync();

            if (schedules == null || schedules.Count == 0)
                return NotFound();

            return Ok(schedules);
        }


        [HttpGet("by-accessed/{accessedId}")]
        public async Task<ActionResult<List<Schedule>>> GetByAccessedId(int accessedId)
        {
            var schedules = await _demoDbContext.schedules
                .Where(x => x.AccessedId == accessedId)
                .ToListAsync();

            if (schedules == null || schedules.Count == 0)
                return NotFound();

            return Ok(schedules);
        }


        [HttpGet("by-questions/{questionsId}")]
        public async Task<ActionResult<List<Schedule>>> GetByQuestionsId(int questionsId)
        {
            var schedules = await _demoDbContext.schedules
                .Where(x => x.QuestionsId == questionsId)
                .ToListAsync();

            if (schedules == null || schedules.Count == 0)
                return NotFound();

            return Ok(schedules);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Schedule accessor)
        {
            await _demoDbContext.schedules.AddAsync(accessor);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = accessor.Id }, accessor);
        }


        [HttpPut]
        public async Task<ActionResult> Update(Schedule accessor)
        {
            _demoDbContext.schedules.Update(accessor);
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

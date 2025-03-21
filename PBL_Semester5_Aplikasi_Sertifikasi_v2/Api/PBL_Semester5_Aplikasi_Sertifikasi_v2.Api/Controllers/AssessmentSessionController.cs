using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Data;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentSessionController : ControllerBase
    {
        private DemoDbContext _demoDbContext;
        public AssessmentSessionController(DemoDbContext demoDbContext) => _demoDbContext = demoDbContext;

        [HttpGet]
        public ActionResult<IEnumerable<AssessmentSession>> Get()
        {
            return _demoDbContext.assessmentSessions;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AssessmentSession?>> GetById(int id)
        {
            return await _demoDbContext.assessmentSessions.Where(x => x.AssessmentSessionId == id).SingleOrDefaultAsync();
        }


        // New action to get the largest AssessmentSessionId
        [HttpGet("max-id")]
        public async Task<ActionResult<int>> GetMaxId()
        {
            if (!await _demoDbContext.assessmentSessions.AnyAsync())
            {
                return Ok(-1);
            }

            int maxId = await _demoDbContext.assessmentSessions
                                            .MaxAsync(x => x.AssessmentSessionId);

            return Ok(maxId);
        }


        [HttpPost]
        public async Task<ActionResult> Create(AssessmentSession assessmentSession)
        {
            await _demoDbContext.assessmentSessions.AddAsync(assessmentSession);
            await _demoDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = assessmentSession.AssessmentSessionId }, assessmentSession);
        }
    }
}

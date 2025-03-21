using Microsoft.AspNetCore.Mvc;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Services;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportRenderingService _reportRenderingService;

        public ReportController(ReportRenderingService reportRenderingService) => 
            _reportRenderingService = reportRenderingService;

        [HttpGet("GeneratePdf")]
        public ActionResult GeneratePdf()
        {
            var report = new AnswerVerified
            {
                Id = 0,
                Rekomendasi = "0",
                Tanggapan = "0",
                Question = "0",
                Answer = "0",
                AccessedId = 0,
                AccessorId = 0,
                QuestionsId = 0,
                AssessmentSessionId = 0,
            };

            var doc = _reportRenderingService.GenerateReportPdf(report);
            return File(doc, "application/pdf", "report.pdf");
        }
    }
}

using PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Entities;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Helpers;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Services
{
    public class ReportRenderingService
    {
        public ReportRenderingService()
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
        }

        public byte[] GenerateReportPdf(AnswerVerified report)
        {
            var doc = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);

                    page.Header()
                        .Row(row =>
                        {
                            row.RelativeItem()
                            .Column(col =>
                            {
                                col.Item().Text("Id");
                                col.Item().Text("Pertanyaan");
                                col.Item().Text("Jawaban");
                                col.Item().Text("Tanggapan");
                                col.Item().Text("Rekomendasi");
                            });
                        });

                    page.Content();

                    page.Footer();
                });
            });

            doc.ShowInCompanion(); 

            return doc.GeneratePdf();
        }
    }
}

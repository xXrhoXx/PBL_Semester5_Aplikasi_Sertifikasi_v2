namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Domain.Model
{
    public record LoginResponseModel
    {
        public string Token {  get; init; }
        public long TokenExpired { get; init; }
    }
}

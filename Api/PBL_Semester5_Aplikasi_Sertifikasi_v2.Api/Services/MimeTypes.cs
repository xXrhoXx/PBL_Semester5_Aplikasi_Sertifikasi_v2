namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Services
{
    // Utility class to get MIME types (you can use a NuGet library like MimeTypesMap for more robust handling)
    public static class MimeTypes
    {
        private static readonly Dictionary<string, string> MimeMapping = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
    {
        { ".jpg", "image/jpeg" },
        { ".jpeg", "image/jpeg" },
        { ".png", "image/png" },
        { ".gif", "image/gif" },
        { ".pdf", "application/pdf" },
        { ".zip", "application/zip" },
        { ".rar", "application/x-rar-compressed" }
    };

        public static string GetMimeType(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            return MimeMapping.ContainsKey(extension) ? MimeMapping[extension] : "application/octet-stream";
        }
    }
}

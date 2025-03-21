namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.Api.Services
{
    public class UploadHandler
    {
        public string Upload(IFormFile file)
        {
            // Allowed extension
            List<string> validFileFormat = new List<string>() {".rar", ".zip", ".jpg", ".pdf"};
            string extension = Path.GetExtension(file.FileName);
            if (!validFileFormat.Contains(extension))
            {
                return $"Extension is not valid({string.Join(',',validFileFormat)})";
            }

            // File Size
            long size = file.Length;
            if (size > (100 * 1024 * 1024))
                return "file to big, maximum 100mb";

            // Name Modification
            string fileName = Guid.NewGuid().ToString() + extension;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

            // Ensure the directory exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fullPath = Path.Combine(path, fileName);

            using FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            file.CopyTo(stream);

            //return fileName;
            return fullPath;
        }
    }
}

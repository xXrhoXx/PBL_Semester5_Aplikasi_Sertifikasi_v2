namespace BaseLibrary.Entities
{
    public class Assesse : BaseEntity
    {
        public string? alumni {  get; set; }
        public string? tanggalLahir { get; set; }
        public string? pendidikanTerakhir {  get; set; }
        public string? alamat {  get; set; }

        public Role? role { get; set; }
    }
}

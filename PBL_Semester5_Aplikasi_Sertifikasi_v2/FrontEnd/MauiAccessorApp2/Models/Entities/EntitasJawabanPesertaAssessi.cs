namespace MauiAccessorApp2.Models.Entities
{
    public class EntitasJawabanPesertaAssessi
    {
        public int idSoal;
        public int idPesertaAssessi;
        public string namaPesertaAssesi;
        public int idAssessor;
        public string namaAssesor;
        public List<Pertanyaan> daftarPertanyaanPesertaAssessi;
        public List<Jawaban> daftarJawabanPesertaAssessi;
    }
}

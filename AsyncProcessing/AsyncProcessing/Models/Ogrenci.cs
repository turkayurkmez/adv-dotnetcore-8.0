using System.Collections;

namespace AsyncProcessing.Models
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }
    }

    public class Ogretmen
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Numara { get; set; }
    }

    public class  Sinif : IEnumerable<Ogrenci>
    {
        public List<Ogrenci> Ogrenciler { get; set; }

        public void OgrenciEkle(Ogrenci ogrenci)
        {
            Ogrenciler.Add(ogrenci);
        }

        public IEnumerator<Ogrenci> GetEnumerator()
        {
            foreach (var item in Ogrenciler)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

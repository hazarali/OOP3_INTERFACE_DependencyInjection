using System;

namespace FaturaSistemi
{
    // Fatura hesaplama arayüzü
    public interface IFatura
    {
        decimal Hesapla(decimal miktar, int ay);
    }

    // Elektrik Faturası
    public class ElektrikFaturasi : IFatura
    {
        private const decimal BirimFiyat = 0.75m; // Birim başına 0.75 TL

        public decimal Hesapla(decimal miktar, int ay)
        {
            return miktar * BirimFiyat * ay;
        }
    }

    // Su Faturası
    public class SuFaturasi : IFatura
    {
        private const decimal BirimFiyat = 0.5m; // Birim başına 0.5 TL

        public decimal Hesapla(decimal miktar, int ay)
        {
            return miktar * BirimFiyat * ay;
        }
    }

    // Doğalgaz Faturası
    public class DogalgazFaturasi : IFatura
    {
        private const decimal BirimFiyat = 1.25m; // Birim başına 1.25 TL

        public decimal Hesapla(decimal miktar, int ay)
        {
            return miktar * BirimFiyat * ay;
        }
    }

    // Fatura Yönetimi
    public class FaturaManager
    {
        private readonly IFatura _fatura;

        // Constructor injection ile fatura türü alınır
        public FaturaManager(IFatura fatura)
        {
            _fatura = fatura;
        }

        public void FaturaHesapla(decimal miktar, int ay)
        {
            decimal toplamFatura = _fatura.Hesapla(miktar, ay);
            Console.WriteLine($"Fatura Hesaplandı. Toplam Tutar: {toplamFatura} TL");
        }
    }

    // Fatura Hesaplama Testi
    class Program
    {
        static void Main(string[] args)
        {
            // Dependency Injection: Farklı fatura türleri ile hesaplama yapılabilir.
            IFatura elektrikFaturasi = new ElektrikFaturasi();
            IFatura suFaturasi = new SuFaturasi();
            IFatura dogalgazFaturasi = new DogalgazFaturasi();

            FaturaManager elektrikFaturaManager = new FaturaManager(elektrikFaturasi);
            FaturaManager suFaturaManager = new FaturaManager(suFaturasi);
            FaturaManager dogalgazFaturaManager = new FaturaManager(dogalgazFaturasi);

            decimal miktar = 100; // Tüketim miktarı
            int ay = 1; // Ay sayısı

            elektrikFaturaManager.FaturaHesapla(miktar, ay);
            suFaturaManager.FaturaHesapla(miktar, ay);
            dogalgazFaturaManager.FaturaHesapla(miktar, ay);
        }
    }
}

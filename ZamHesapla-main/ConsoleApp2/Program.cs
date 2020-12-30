using System;

namespace ConsoleApp2
{
    class Program
    {
        public double MaasHesapla(int cocuksayisi, double maas)
        {
            double zam;
            
            switch (cocuksayisi)
            {
                case 0:
                    var zamOraniveZam = CocuksuzZamOraniVeZamHesapla(maas);
                    Console.WriteLine($"Yapılacak zam oranı {zamOraniveZam[0]} zam tutarı {zamOraniveZam[1]}");
                    return zamOraniveZam[1] + maas;
                case 1:
                    zam = maas * 0.05;
                    Console.WriteLine("Yapılacak zam oranı 5% zam tutarı {0}", zam);
                    return zam + maas;
                case 2:
                    zam = maas * 0.10;
                    Console.WriteLine("Yapılacak zam oranı 10% zam tutarı {0}", zam);
                    return zam + maas;
            }

            if (cocuksayisi >= 3)
            {
                zam = maas * 0.15;
                Console.WriteLine("Yapılacak zam oranı 15% zam tutarı {0}", zam);
                return zam + maas;
            }

            throw new ArgumentOutOfRangeException("Geçersiz giriş");
        }

        public double[] CocuksuzZamOraniVeZamHesapla(double alinanMaas)
        {
            Console.WriteLine("Toplam çalışan sayısı :");
            var toplamCalisan = int.Parse(Console.ReadLine());
                    
            Console.WriteLine("1 ve 2 çocuğu olan çalışan sayısı: ");
            var cocukluCalisan = int.Parse(Console.ReadLine());
            
            var zam = (alinanMaas / 100) * ((double)cocukluCalisan / toplamCalisan) * 10;
            var zamOrani = (alinanMaas + zam - alinanMaas) / 100*10;

            return new[] {zamOrani, zam};
        }
        
        public void GetCalculatedSalary(int cevap, double alinanMaas)
        {
            if (cevap >= 3)
            {
                Console.WriteLine($"Yeni maaş: {MaasHesapla(cevap, alinanMaas)}");
            }
            
            switch (cevap)
            {
                case 0:
                    Console.WriteLine($"Yeni maaş: {MaasHesapla(cevap, alinanMaas)}");
                    break;
                
                case 1:
                    Console.WriteLine($"Yeni maaş: {MaasHesapla(cevap, alinanMaas)}");
                    break;
                
                case 2:
                    Console.WriteLine($"Yeni maaş: {MaasHesapla(cevap, alinanMaas)}");
                    break;
            }
        }

        static void Main(string[] args)
        {
            var program = new Program();

            // Çocuk sayısı istenir.
            Console.WriteLine("Kaç çocuklu çalışan için zam hesaplanacak ?");
            var canParseCevap = int.TryParse(Console.ReadLine(), out var cevap);
            
            // Maaş tutarı istenir.
            Console.WriteLine("Maaş tutarını girin: ");
            var canParseAlinanMaas = double.TryParse(Console.ReadLine(), out var alinanMaas); 
            
            // Parse edilip edilemediklerine bakılır.
            var isValuesAreValid = canParseCevap && canParseAlinanMaas;
            
            // Parse edilene kadar, değerler tekrar istenir. 
            while (!isValuesAreValid)
            {
                Console.WriteLine("Kaç çocuklu çalışan için zam hesaplanacak ?");
                canParseCevap = int.TryParse(Console.ReadLine(), out cevap);
            
                Console.WriteLine("Maaş tutarını girin: ");
                canParseAlinanMaas = double.TryParse(Console.ReadLine(), out alinanMaas); 
                
                isValuesAreValid = canParseCevap && canParseAlinanMaas;
            }

            // Hesaplanmış maaş sonucu
            program.GetCalculatedSalary(cevap, alinanMaas);
        }
    }
}


// dışarıdan çalışan sayısı alınacak 
// her çalışanın kaç çocuğu var alınacak
// bir şirkette çalışanlarına zam yapılacak. zam oranı çalışanın çocuk sayısına göre belirlenecek 
// 1 çocuk varsa 5%
// 2 çocuk varsa 10%
// 3 çocuk varsa 15%
// çocuğu yoksa 
// 1 ve 2 çocuklu kişilerin aritmetik ortalaması zam olarak yapılacak
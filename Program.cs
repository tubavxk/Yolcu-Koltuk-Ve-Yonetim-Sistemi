using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

class Program
{
    static Dictionary<int, bool> koltuklar = new Dictionary<int, bool>();
    static Dictionary<int, string> koltukCinsiyet = new Dictionary<int, string>();

    static void Main(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            koltuklar[i] = false;
            koltukCinsiyet[i] = "";
        }

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Yolcu Yönetim Sistemi");
            Console.WriteLine("1. Kullanıcı Kayıt/Giriş Yap");
            Console.WriteLine("2. Seyahat ve Koltuk Seçimi");
            Console.WriteLine("3. Ödeme ve Bilet Onayı");
            Console.WriteLine("4. Bilet Bilgileri");
            Console.WriteLine("5. Hatırlatma ");
            Console.WriteLine("6. Bilet İptali");
            Console.WriteLine("7. Çıkış");
            Console.Write("Seçiminizi yapın: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    KullaniciKayitVeGiris();
                    break;
                case "2":
                    SeyahatVeKoltukSecimi();
                    break;
                case "3":
                    OdemeVeBiletOnayi();
                    break;
                case "4":
                    BiletBilgileri();
                    break;
                case "5":
                    Hatırlatma();
                    break;
                case "6":
                    Biletİptali();
                    break;
                case "7":
                    Console.WriteLine("Çıkış yapılıyor...");
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }

            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }
    }
    static void KullaniciKayitVeGiris()
    {
        Console.WriteLine("1. Yeni Kayıt Yap");
        Console.WriteLine("2. Giriş Yap");
        Console.Write("Seçiminiz: ");
        string secim = Console.ReadLine();

        if (secim == "1")
        {
            Console.Write("Adınızı girin: ");
            string ad = Console.ReadLine();
            Console.Write("Soyadınızı girin: ");
            string soyad = Console.ReadLine();
            Console.WriteLine("Kayıt başarılı! Lütfen giriş yapın.");
        }
        else if (secim == "2")
        {
            Console.Write("Adınızı ve Soyadınızı giriniz: ");
            string adsoyad = Console.ReadLine();
            Console.WriteLine("Başarıyla Siteye giriş yapılmıştır.");
        }
        else
        {
            Console.WriteLine("Geçersiz seçim.");
        }
    }
    static void SeyahatVeKoltukSecimi()
    {
        Console.WriteLine("Otobüs/Uçak/Tren");
        Console.Write("Hangi ulaşım aracını tercih edeceğinizi seçiniz: ");
        string arac = Console.ReadLine();


        Console.Write("Kalkış noktasını girin: ");
        string kalkis = Console.ReadLine();
        Console.Write("Varış noktasını girin: ");
        string varis = Console.ReadLine();
        Console.Write("Gidiş tarihi (GG/AA/YYYY): ");
        string gidisTarihi = (Console.ReadLine());


        Console.Write("Uygulamanın Size bildirim göndermesine izin veriyor musunuz? Evet/Hayır: ");
        string bildirim = Console.ReadLine();
        Console.WriteLine("Uygun Seyehatler Listeleniyor...");

        Console.Write("Cinsiyetinizi girin (Erkek/Kadın): ");
        string cinsiyet = Console.ReadLine();

        KoltukDurumlariniGoruntule();

        Console.Write("Rezerve etmek istediğiniz koltuk numarasını girin (1-10): ");
        if (int.TryParse(Console.ReadLine(), out int koltukNo) && koltuklar.ContainsKey(koltukNo))
        {
            if (koltuklar[koltukNo])
            {
                Console.WriteLine("Bu koltuk zaten rezerve edilmiş.");
            }
            else if (CinsiyetUyumuKontrolEt(koltukNo, cinsiyet))
            {
                koltuklar[koltukNo] = true;
                koltukCinsiyet[koltukNo] = cinsiyet;
                Console.WriteLine($"{koltukNo} numaralı koltuk başarıyla rezerve edildi.");
            }
            else
            {
                Console.WriteLine("Cinsiyet uyumsuzluğu nedeniyle bu koltuğu seçemezsiniz.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz koltuk numarası.");
        }
    }
    static bool CinsiyetUyumuKontrolEt(int koltukNo, string cinsiyet)
    {
        if (koltukNo % 2 == 0)
        {
            int yanKoltuk = koltukNo - 1;
            return koltukCinsiyet[yanKoltuk] == "" || koltukCinsiyet[yanKoltuk] == cinsiyet;
        }
        else
        {
            int yanKoltuk = koltukNo + 1;
            return koltukCinsiyet[yanKoltuk] == "" || koltukCinsiyet[yanKoltuk] == cinsiyet;
        }
    }
    private static void BiletBilgileri()
    {
        Console.WriteLine("Bilet bilgilerinizi mail olarak almak istiyor musunuz?");
        Console.WriteLine("evet/hayır");
        Console.Write("Seçiminiz: ");
        string seçim = Console.ReadLine()?.ToLower();


        if (seçim == "evet")
        {
            Console.WriteLine("Lütfen telefon numaranızı ve eposta adresinizi giriniz");
            Console.Write("Telefon numaranız: ");
            int telefon = Convert.ToInt32(Console.ReadLine());
            Console.Write("Mail adresiniz: ");
            string mail = Console.ReadLine();
            Console.WriteLine("Bilet bilgileriniz iletilmiştir");

        }
        else if (seçim == "hayır")
        {
            Console.WriteLine("Lütfen telefon numaranızı giriniz");
            Console.Write("Telefon numaranız: ");
            int telefon = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Bilet bilgileriniz iletilmiştir");
        }

        else
        {
            Console.WriteLine("Geçersiz cevap. Lütfen 'Evet' veya 'Hayır' yazınız.");
        }
    }

    private static void Biletİptali()
    {
        Console.WriteLine("Yetişemediğiniz takdirde bilet iptali yapmak istiyor musunuz");
        Console.WriteLine("evet/hayır");
        Console.Write("Seçiminiz: ");
        string seçim = Console.ReadLine();

        if (seçim == "evet")
        {
            Console.WriteLine("Kupon yapılsın mı?");
            Console.WriteLine("evet/hayır");
            Console.Write("seçiminiz: ");
            string secim = Console.ReadLine();

            if (secim == "evet")
            {
                Console.WriteLine("Başarıyla Oluşturuldu. Kuponunuz Hesabınıza tanımlanmıştır");
            }

            else
            {
                Console.WriteLine("Paranız en kısa sürede kartınıza iade edilecektir");
            }
        }

        else
        {
            Console.WriteLine("Anasayfaya geri dönebilirsiniz");
        }

    }

    private static void Hatırlatma()
    {
        Console.WriteLine("Kalkıştan önce hatırlatma çağrısı almanız için lütfen güncel Telefon numaranızı giriniz");
        Console.Write("Telefon numaranız: ");
        int telefon = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Telefon numaranız kaydedilmiştir");
    }



    static void OdemeVeBiletOnayi()
    {
        Console.WriteLine("Lütfen İletişim Bilgilerinizi Giriniz");
        Console.Write("Telefon numaranız: ");
        int telefon = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ödeme Yöntemleri:");
        Console.WriteLine("1. Kredi Kartı");
        Console.WriteLine("2. Havale/EFT");
        Console.Write("Seçiminizi yapın: ");
        string odemeSecimi = Console.ReadLine();

        if (odemeSecimi == "1")
        {
            Console.Write("Kart numarasını girin: ");
            int kartNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ödeme başarıyla tamamlandı.");
        }
        else if (odemeSecimi == "2")
        {
            Console.WriteLine("Hesap bilgileri gönderildi. Lütfen ödeme yapın.");
        }
        else
        {
            Console.WriteLine("Geçersiz ödeme seçimi.");
        }

        Console.WriteLine("Biletinizi Başarıyla Satın Aldınız.");

    }

    static void KoltukDurumlariniGoruntule()
    {
        Console.WriteLine("Koltuk Durumları:");
        foreach (var koltuk in koltuklar)
        {
            string durum = koltuk.Value ? $"Dolu ({koltukCinsiyet[koltuk.Key]})" : "Boş";
            Console.WriteLine($"Koltuk {koltuk.Key}: {durum}");
        }
    }
}

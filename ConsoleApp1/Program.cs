using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static string[] kullaniciAdlari = new string[100];
        static string[] sifreler = new string[100];
        static int kayitSayac = 0;

        static string[] taksiciler = { "Mehmet Bey", "Ahmet Bey", "Akif Bey" };
        static string[] mesgulDurum = { "Hayır", "Hayır", "Hayır" };
        static string[] yildizSayisi = { "****", "*****", "***" };
        static int secim;
        static int gitmekIstenilenSecim;
        static bool kullaniciVar;
        static bool girisDogru;
        static int fiyat;
        static string kabul;
        static int puan;
        static void Main(string[] args)
        {
            giris:
            Console.WriteLine("           OtoTak\n          ********\nOtoTak Uygulamasına Hoşgeldiniz !\n********************************");
            Console.Write("1 - Kayıt Ol \n2 - Giriş Yap\n********************************\nİşlem Seçiniz : ");
            try
            {
                secim = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                Thread.Sleep(1000);
                Console.Clear();
                goto giris;
            }

            switch(secim)
            {
                case 1:

                    kayitOl();
                    goto giris;

                    if (kullaniciVar == true)
                    {
                        Console.WriteLine("Bu Kullanıcı Adı Kullanılmaktadır !");
                        goto giris;
                    }

                    break;

                case 2:

                    girisYap();
                    if(girisDogru == false)
                    {
                        Console.WriteLine("Kullanıcı Adı / Şifre Hatalı");
                        goto giris;
                    }
                    break;

                default:
                    Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto giris;
            }
            Console.Write("Çıkmak İçin Herhangi Bir Tuşa Basınız");
            Console.ReadKey();
        }

        static void kayitOl()
        {
            Console.Clear();
            Console.Write("Kullanıcı Adınızı Giriniz : ");
            string kullaniciAdi = Console.ReadLine();
            Console.Clear();

            Console.Write("Şifrenizi Giriniz : ");
            string sifre = Console.ReadLine();
            Console.Clear();

            kullaniciVar = false;
            for (int i = 0; i < kullaniciAdlari.Length; i++)
            {
                if (kullaniciAdlari[i] == kullaniciAdi)
                {
                    kullaniciVar = true;
                }
            }
            if (kullaniciVar == false)
            {
                kullaniciAdlari[kayitSayac] = kullaniciAdi;
                sifreler[kayitSayac] = sifre;
                kayitSayac++;
            }
            else
            {
                Console.WriteLine("Bu Kullanıcı Adı Kullanılmaktadır. Lütfen Başka Kullanıcı Adı İle Tekrar Deneyiniz !");
                Thread.Sleep(2000);
                Console.Clear();
            }

        }

        static void girisYap()
        {
            Console.Clear();
            Console.Write("Kullanıcı Adınızı Giriniz : ");
            string kullaniciAdi = Console.ReadLine();
            Console.Clear();

            Console.Write("Şifrenizi Giriniz : ");
            string sifre = Console.ReadLine();
            Console.Clear();

            girisDogru = false;
            for (int i = 0; i < kullaniciAdlari.Length; i++)
            {
                if (kullaniciAdlari[i] == kullaniciAdi)
                {
                    if(sifreler[i] == sifre)
                    {
                        Console.WriteLine("Giriş Başarılı !");
                        girisDogru = true;
                        Thread.Sleep(1000);
                        Console.Clear();
                        anaMenu();
                    }
                }
            }
        }

        static void anaMenu()
        {
        anaMenuSecim:
            Console.WriteLine("           OtoTak\n          ********\n********************************");
            Console.Write("1 - Taksi Çağırma \n********************************\nİşlem Seçiniz : ");

            try
            {
                secim = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                Thread.Sleep(1000);
                Console.Clear();
                goto anaMenuSecim;
            }

            switch (secim)
            {
                case 1:
                taksiciSecim:
                Console.WriteLine("Taksiciler \n************");
                for (int i = 0; i < taksiciler.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {taksiciler[i]} | Yıldız Puanı {yildizSayisi[i]} | Meşgul mü ? {mesgulDurum[i]}");
                }

                try
                {
                    Console.Write("Taksici Seçiniz : ");
                    secim = Convert.ToInt32(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto taksiciSecim;
                }
                
                
                kabulYer:

                switch (secim)
                {
                    case 1:

                        kabulSecim:
                        yerler();
                        Console.Clear();
                        Console.WriteLine($"Gideceğiniz Yer İçin Tutar {fiyat} TL'dir\nKabul Ediyor musunuz ?(E / H) :");

                        kabul = Console.ReadLine();
                        if (kabul == "e" || kabul == "E")
                        {
                            Console.WriteLine("Kabul Edildi ! Gidiliyor...");
                            Thread.Sleep(2000);
                            puanlama();
                        }
                        else if (kabul == "h" || kabul == "H")
                        {
                            Console.WriteLine("Kabul Edildi ! Gidiliyor..."); 
                            Thread.Sleep(2000);
                            puanlama();
                        }
                        else
                        {
                            Console.WriteLine("Lütfen Doğru Şekilde Yazınız !");
                            goto kabulSecim;
                        }
                        break;

                    case 2:

                        kabulSecim1:
                        yerler();
                        Console.Clear();
                        Console.WriteLine($"Gideceğiniz Yer İçin Tutar {fiyat} TL'dir\nKabul Ediyor musunuz ?(E / H) :");

                        kabul = Console.ReadLine();
                        if (kabul == "e" || kabul == "E")
                        {
                            Console.WriteLine("Kabul Edildi ! Gidiliyor...");
                            Thread.Sleep(2000);
                            puanlama();
                        }
                        else if (kabul == "h" || kabul == "H")
                        {
                            Console.WriteLine("Kabul Edildi ! Gidiliyor...");
                            Thread.Sleep(2000);
                            puanlama();
                        }
                        else
                        {
                            Console.WriteLine("Lütfen Doğru Şekilde Yazınız !");
                            goto kabulSecim1;
                        }
                        break;
                    case 3:

                        kabulSecim2:
                        yerler();
                        Console.Clear();
                        Console.WriteLine($"Gideceğiniz Yer İçin Tutar {fiyat} TL'dir\nKabul Ediyor musunuz ?(E / H) :");

                        kabul = Console.ReadLine();
                        if (kabul == "e" || kabul == "E")
                        {
                            Console.WriteLine("Kabul Edildi ! Gidiliyor...");
                            Thread.Sleep(2000);
                            puanlama();
                        }
                        else if (kabul == "h" || kabul == "H")
                        {
                            Console.WriteLine("Kabul Edildi ! Gidiliyor...");
                            Thread.Sleep(2000);
                            puanlama();
                        }
                        else
                        {
                            Console.WriteLine("Lütfen Doğru Şekilde Yazınız !");
                            goto kabulSecim2;
                        }
                        break;
                    }
                break;

                default:
                    Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                    Thread.Sleep(1000);
                    Console.Clear();
                    goto anaMenuSecim;
                    break;
            }
        }

        static void puanlama()
        {
            puanlamaGec:
            Console.Clear();
            Console.Write("Şöförü Puanlayınız (0-5) : ");
            try
            {
                puan = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Şöför Puanlandı");
            }
            catch
            {
                Console.WriteLine("Lütfen Doğru Şekilde Puanlayınız !");
                Thread.Sleep(1000);
                Console.Clear();
                goto puanlamaGec;
            }
        }
        static void yerler()
        {
            oldugunuzYerSecim:
            Console.Clear();
            Console.WriteLine("1 - Toki\n2 - Ömerli\n3 - Sazlıbosna Gölü\n4 - Arnavutköy Devlet Hastanesi\n5 - Kitap Kafe");
            try
            {
                Console.Write("Olduğunuz Yeri Seçiniz : ");
                secim = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                Thread.Sleep(1000);
                Console.Clear();
                goto oldugunuzYerSecim;
            }

            gitmekIstenilen:
            Console.Clear();
            Console.WriteLine("1 - Toki\n2 - Ömerli\n3 - Sazlıbosna Gölü\n4 - Arnavutköy Devlet Hastanesi\n5 - Kitap Kafe");

            try
            {
                Console.Write("Gitmek İstediğiniz Seçiniz : ");
                gitmekIstenilenSecim = Convert.ToInt32(Console.ReadLine());

            }
            catch
            {
                Console.WriteLine("Lütfen Doğru Şekilde Seçim Yapınız !");
                Thread.Sleep(1000);
                Console.Clear();
                goto gitmekIstenilen;
            }

            if (secim == gitmekIstenilenSecim)
            {
                Console.WriteLine("Olduğunuz Yeri Seçemezsiniz !");
                goto gitmekIstenilen;
            }
            else if (secim <= 0 || secim >= 6 || gitmekIstenilenSecim <= 0 || gitmekIstenilenSecim >= 6)
            {
                Console.WriteLine("Lütfen Doğru Seçim Yapınız !");
                goto oldugunuzYerSecim;
            }
            else if (secim == 1 && gitmekIstenilenSecim == 2)
            {
                fiyat = 55;
            }
            else if (secim == 1 && gitmekIstenilenSecim == 3)
            {
                fiyat = 40;
            }
            else if (secim == 1 && gitmekIstenilenSecim == 4)
            {
                fiyat = 60;
            }
            else if (secim == 1 && gitmekIstenilenSecim == 5)
            {
                fiyat = 55;
            }



            else if (secim == 2 && gitmekIstenilenSecim == 1)
            {
                fiyat = 70;
            }
            else if (secim == 2 && gitmekIstenilenSecim == 3)
            {
                fiyat = 100;
            }
            else if (secim == 2 && gitmekIstenilenSecim == 4)
            {
                fiyat = 100;
            }
            else if (secim == 2 && gitmekIstenilenSecim == 5)
            {
                fiyat = 95;
            }

            else if (secim == 3 && gitmekIstenilenSecim == 1)
            {
                fiyat = 55;
            }
            else if (secim == 3 && gitmekIstenilenSecim == 2)
            {
                fiyat = 80;
            }
            else if (secim == 3 && gitmekIstenilenSecim == 4)
            {
                fiyat = 90;
            }
            else if (secim == 3 && gitmekIstenilenSecim == 5)
            {
                fiyat = 105;
            }




            else if (secim == 4 && gitmekIstenilenSecim == 1)
            {
                fiyat = 75;
            }
            else if (secim == 4 && gitmekIstenilenSecim == 2)
            {
                fiyat = 120;
            }
            else if (secim == 4 && gitmekIstenilenSecim == 3)
            {
                fiyat = 100;
            }
            else if (secim == 4 && gitmekIstenilenSecim == 5)
            {
                fiyat = 80;
            }



            else if (secim == 5 && gitmekIstenilenSecim == 1)
            {
                fiyat = 75;
            }
            else if (secim == 5 && gitmekIstenilenSecim == 2)
            {
                fiyat = 95;
            }
            else if (secim == 5 && gitmekIstenilenSecim == 3)
            {
                fiyat = 135;
            }
            else if (secim == 5 && gitmekIstenilenSecim == 4)
            {
                fiyat = 65;
            }
        }
    }
}

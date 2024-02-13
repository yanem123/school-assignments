//Készítette: Szilágyi János

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp6
{
    class Program
    {
    /*static List<string> szavak = new List<string>() {"Kapott","Kevés","Kelepcében","Futott","Adott","Ott","Erre","OTIT","Hol?","Kevés","Merre?","HTTP"};

    
        static string[] dolgozok = {
            "Nagy Ágota; Operátor;296000",
            "Kelemen Béla; Java fejlesztő;432000",
            "Kovács Barna; C# fejlesztő;490000",
            "Boldog Béla;Adatbázis specialista;1250000",
            "Kezdő Gedeon; Operátor;250000",
            "Rohanó Teodór; Java fejlesztő;790000",
            "Szép Levente; PHP fejlesztő;560000",
            "Jakab Edit; IT biztonsági szakkértő;1450000",
            "Mosó György; Operátor;370000",
            "Kovács Géza; C# fejlesztő;560000",
            "Kezdő Boglárka;C# fejlesztő;450000"
            };
    */
    static void Main(string[] args)
        {
            //1. feladat
            string szo;
            List<string> szavak = new List<string>();
            do
            {
                 szo = Console.ReadLine();
                if (szo !="*")
                {
                    szavak.Add(szo);
                }
            } while (szo!="*");
            //1.a.

            int leghosszabb = 0;
            foreach (string item in szavak)
            {
                if (item.Length>leghosszabb)
                {
                    leghosszabb = item.Length;
                }
            }
            Console.WriteLine("A leghosszabb szó hossza: "+leghosszabb);
            //1.b.
            bool kerdojel = false;

            foreach (string item in szavak)
            {
                if (item[item.Length-1]=='?')
                {
                    kerdojel = true;
                }
            }

            if (kerdojel)
            {
                Console.WriteLine("Van olyan szó, ami ?-re végződik.");
            }
            else
            {
                Console.WriteLine("Nincs olyan szó, ami ?-re végződik.");
            }
            //1.c.
            int mennyi = 0;

            foreach (string item in szavak)
            {
                if (item.Length<5)
                {
                    mennyi++;
                }
            }
            Console.WriteLine(mennyi+" db 5 karakternél rövidebb szó van");
            //1.d.
            string BIG = "";
            int bigg = 0;
            foreach (string item in szavak)
            {
                if (item.Length > bigg)
                {
                    BIG = item;
                }
            }
            Console.WriteLine(BIG+" a leghosszabb szó a listában.");
            //1.e.

            List<string> kisszavak = new List<string>();
            foreach (string item in szavak)
            {
                kisszavak.Add(item.ToLower());
            }
            szavak = kisszavak;


            //2. feladat


            //2.a.
            int osszeg = 0;
            foreach (string item in File.ReadAllLines("fizetesek.txt"))
            {
                string[] seged = item.Split(';');
                osszeg = osszeg + int.Parse(seged[2]);

            }
            Console.WriteLine("A teljes fizetés: "+osszeg);
            //2.b.
            string neve = "";
            int seged1 = 0;
            foreach (string item in File.ReadAllLines("fizetesek.txt"))
            {
                string[] seged = item.Split(';');
                if (int.Parse(seged[2])>seged1)
                {
                    seged1 = int.Parse(seged[2]);
                    neve = seged[0];
                }
            }
            Console.WriteLine(neve+" a legtöbbet kereső dolgozó.");
            //2.c.
            int keves = 0;
            foreach (string item in File.ReadAllLines("fizetesek.txt"))
            {
                string[] seged = item.Split(';');
                if (int.Parse(seged[2])<300000)
                {
                    keves++;
                }
            }
            Console.WriteLine(keves+" db ember van 300000 Ft alatti fizetéssel.");
            //2.d.
            
            foreach (string item in File.ReadAllLines("fizetesek.txt"))
            {
                string[] seged = item.Split(';');
                if (seged[1]=="Operátor")
                {
                    Convert.ToInt32(Convert.ToInt32(seged[2])*1.12);
                }
            }
            //2.e.
            List<string> fejlesztok = new List<string>();
            foreach (string item in File.ReadAllLines("fizetesek.txt"))
            {
                string[] seged = item.Split(';');
                if (seged[1].Contains("fejlesztő"))
                {
                    fejlesztok.Add(item);
                }
            }

            foreach (string item in fejlesztok)
            {
                string[] seged = item.Split(';');
                Console.WriteLine(seged[0]+"("+seged[1]+") - "+seged[2]+"Ft");
            }


        }
    }
}

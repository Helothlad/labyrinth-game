using System;
using System.IO;
using System.Text;

namespace Nagyhazi
{
    class Jatek
    {
        private int palyaSzama;
        private string[] adatok;
        private int xkordinata = 0;
        private int ykordinata = 1;
        private int prevXkordinata = 0;
        private int prevYkordinata = 0;
        private char jatekosKarakter = 'X';
        private bool megnyerte = false;
        private DateTime kezdetiIdopont;
        private DateTime vegzoIdopont;
        private TimeSpan osszesIdo { set; get; }
        private string formazottOsszesIdo;
       
        public void JatekInditasa(int palyaSzama)
        {
            this.palyaSzama = palyaSzama;
            adatok = File.ReadAllLines($@".\Labirintusok\palya_{palyaSzama}.txt", Encoding.Default);
            kezdetiIdopont = DateTime.Now;
            Console.Clear();
            LabirintusElsoKiiratas(); 

            while (!megnyerte)
            {
                JatekosMozgatasKiiratas();
                if (xkordinata == adatok[ykordinata].Length - 1 && ykordinata == adatok.Length - 2)
                {
                    megnyerte = true;
                }

                ConsoleKey key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        JatekosMozgatas(0, -1);
                        break;
                    case ConsoleKey.DownArrow:
                        JatekosMozgatas(0, 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        JatekosMozgatas(-1, 0);
                        break;
                    case ConsoleKey.RightArrow:
                        JatekosMozgatas(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        MainMenu fomenu = new MainMenu();
                        fomenu.Menu();
                        break;
                }
            }

            vegzoIdopont = DateTime.Now;
            osszesIdo = vegzoIdopont - kezdetiIdopont;
            Gyozelem();
        }

        private void LabirintusElsoKiiratas()
        {
            Console.WriteLine("Jatek megszakitasa: Escape");
            for (int y = 0; y < adatok.Length; y++)
            {
                for (int x = 0; x < adatok[y].Length; x++)
                {
                    if (x == xkordinata && y == ykordinata)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(jatekosKarakter);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(adatok[y][x]);
                    }
                }
                Console.WriteLine();
            }
        }

        private void JatekosMozgatas(int x, int y)
        {
            int xuj = xkordinata + x;
            int yuj = ykordinata + y;
            if (xuj >= 0 && xuj < adatok[0].Length && yuj >= 0 && yuj < adatok.Length && adatok[yuj][xuj] != '+' && adatok[yuj][xuj] != '-' && adatok[yuj][xuj] != '|')
            {
                prevXkordinata = xkordinata;
                prevYkordinata = ykordinata;
                xkordinata = xuj;
                ykordinata = yuj;
            }
        }

        private void JatekosMozgatasKiiratas()
        {
            Console.SetCursorPosition(prevXkordinata, prevYkordinata + 1); //megtalaljuk a jatekos elobbi poziciojat
            Console.Write(adatok[prevYkordinata][prevXkordinata]); // visszairjuk az eredeti karakter az adatok-bol ami mindig egy ueres karakter
            Console.SetCursorPosition(xkordinata, ykordinata + 1); //cursort az uj poziciora helyezi
            Console.ForegroundColor = ConsoleColor.Red; //szinezes pirosra
            Console.Write(jatekosKarakter); //Kiiratjuk a jatekos karakter az uj helyen
            Console.ResetColor();
        }

        public void Gyozelem()
        {
            Console.WriteLine();
            Console.WriteLine();
            formazottOsszesIdo = $"{osszesIdo.Minutes}p {osszesIdo.Seconds}ms";
            Console.WriteLine("Gratulalok on nyert");
            Console.WriteLine($"{formazottOsszesIdo} idő volt teljesiteni a labirintust");
            Toplista toplista = new Toplista();
            MainMenu fomenu = new MainMenu();

            if (toplista.ToplistabaKerulE(palyaSzama, osszesIdo))
            {
                Console.WriteLine("Bekerulsz a toplistaba:");
                toplista.Beillesztes(formazottOsszesIdo, osszesIdo, palyaSzama);
            }
            else
            {
                Console.WriteLine("Nem kerulsz be a toplistaba");
                
            }
        }
    }
}

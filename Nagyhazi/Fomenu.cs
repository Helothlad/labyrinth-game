using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Nagyhazi
{
    class MainMenu
    {
        private int szam;
        private int palyaSzama { get; set; }

        public int GetPalyaSzam()
        {
            return palyaSzama;
        }
        public void Menu()
        {
            MenuKiiratas();
            Esetkezeles();
        }

        public void MenuKiiratas()
        {
            Console.Clear();
            Console.WriteLine("Fomenu:");
            Console.WriteLine("1. Uj jatek kezdese:");
            Console.WriteLine("2. Toplista megtekintése:");
            Console.WriteLine("3. Sugo megnyitasa:");
            Console.WriteLine("4. Kilépés:");
            Console.WriteLine("Ird be 1-4 kozott a szamodra megfelelo szamot:");
        }
        public void Esetkezeles()
        {
            this.szam = int.Parse(Console.ReadLine());
            
            if(szam == 1)
            {
                Console.Clear();
                Console.WriteLine("Melyik pályán szeretnél játszani 1-5ig?");
                this.palyaSzama = int.Parse(Console.ReadLine());
                Jatek jatek = new Jatek();
                jatek.JatekInditasa(palyaSzama);
            }
            else if(szam == 2)
            {
                Toplista toplista = new Toplista();
                toplista.ToplistaKiiratas();
            }else if(szam == 3)
            {
                Sugo sugo = new Sugo();
                sugo.SugoMegjelenites();
            }
            else
            {
                Environment.Exit(0);
            }
            

        }
    }
}

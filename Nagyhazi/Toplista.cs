using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagyhazi
{
    class Toplista
    {
        
        private StreamReader sr;
        

        public StreamReader GetStreamReader()
        {
            sr = new StreamReader($@".\Toplista\Toplista.txt", Encoding.Default);
            return sr;
        }

        public void ToplistaKiiratas()
        {
            Console.Clear();
            Console.WriteLine("Toplista:");
            StreamReader sr = GetStreamReader();
            int db = 0;
            while (!sr.EndOfStream)
            {
                db++;
                string sor = sr.ReadLine();
                Console.WriteLine(sor);
                string[] tomb = sor.Split(' ');
                if (db % 5 == 0 && db != 25)
                {
                    Console.WriteLine();
                    db = 0;
                }
            }
            sr.Close();
            Console.WriteLine("Vissza a fomenuhoz 1: ");
            string input = Console.ReadLine();
            if(input !=  null)
            {
                MainMenu fomenu = new MainMenu();
                fomenu.MenuKiiratas();
                fomenu.Esetkezeles();
            }
            
        }
        public bool ToplistabaKerulE(int palyaSzama, TimeSpan osszesIdo)
        {
            

            sr = GetStreamReader();
            while(!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] tomb = sor.Split(' ');
                int length = tomb[0].Length;


                int perc = int.Parse(tomb[0].Substring(0, tomb[0].Length - 1));

            
                int masodperc = int.Parse(tomb[1].Substring(0, tomb[1].Length-2));

                TimeSpan ListabolIdo = new TimeSpan(0, perc, masodperc);
                
                int palyaSzam = int.Parse(tomb[3]);
                
                if (palyaSzam == palyaSzama && ListabolIdo > osszesIdo)
                {
                    sr.Close();
                    return true;
                }
                
            }
            sr.Close();
            return false;
        }
        public void Beillesztes(string formazottIdoTartam,TimeSpan idoTartam, int palyaSzama)
        {
            Console.WriteLine("Add meg a keresztneved:");
            string Nev = Console.ReadLine();
            string beillesztendo = formazottIdoTartam + " " + Nev + " " + palyaSzama;
            //Console.WriteLine(beillesztendo);

            StreamReader sr = GetStreamReader();
            
            string[] sorok = new string[25];
            int i = 0;
            string tempString = "";
            bool csere = false;

            while (!sr.EndOfStream)
            {

                string sor = sr.ReadLine();
                string[] tomb = sor.Split(' ');
                int percek = int.Parse(tomb[0].Substring(0, tomb[0].Length-1));
                int masodPercek = int.Parse(tomb[1].Substring(0, tomb[1].Length - 2));
                TimeSpan temp = new TimeSpan(0, percek, masodPercek);
                
                if (tomb[3] == palyaSzama.ToString() && temp > idoTartam && !csere)
                {
                    sorok[i] = beillesztendo;
                    i++;
                    csere = true;
                }
                else
                {
                    if (csere && i % 5 != 0)
                    {
                        sorok[i] = tempString;
                        i++;
                    }
                    else
                    {
                        sorok[i] = sor;
                        i++;
                    }
                }
                tempString = sor;

            }
            sr.Close();
            File.WriteAllLines($@".\Toplista\Toplista.txt", sorok, Encoding.Default);

            Console.WriteLine("A mainmenuhoz irjal be egy 1-es szamot:");
            string input = Console.ReadLine();
            MainMenu fomenu = new MainMenu();
            if (input != null)
            {
                fomenu.Menu();

            }
        }
    }
}

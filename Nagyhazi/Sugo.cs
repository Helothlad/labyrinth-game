using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagyhazi
{
    class Sugo
    {
        public void SugoMegjelenites()
        {
            Console.Clear();
            Console.WriteLine("Sugo:");
            Console.WriteLine("Üdvözlünk a Labirintus Játékban! Ebben a játékban különböző labirintusokon kell átkelned, miközben megpróbálod a lehető leggyorsabban megtalálni a kijáratot.\r\n\r\n" +
                "A játék labirintusait szövegfájlok formájában tölti be, amelyek palya_N.txt formátumot követnek, ahol N az adott pálya száma." +
                "\r\nÖt különböző labirintust tartalmaz a játék." +
                "\r\nHogyan Játssz" +
                "\r\n\r\nÚj Játék: A főmenüben válaszd az 'Új Játék' lehetőséget, majd válassz egy labirintust." +
                "\r\nIrányítás: A kurzor mozgató nyilakkal tudod irányítani a karaktert a labirintusban. A játékos karaktere egy jellegzetes szimbólum ('X'), amely kiemelkedik a színe miatt." +
                "\r\nCél: Keress rá a labirintus kijáratára a lehető leggyorsabban." +
                "\r\nIdőmérés: A teljesítéshez szükséges időt rögzítjük. Próbáld meg a labirintust a lehető leggyorsabban teljesíteni!" +
                "\r\nJáték Megszakítása: Az 'ESC' gomb megnyomásával bármikor kiléphetsz a játékból." +
                "\r\nToplista Kezelése" +
                "\r\n\r\nHa az első öt leggyorsabb idő egyikét éred el egy labirintusban, akkor beírhatod a nevedet." +
                "\r\nAz idődet és a nevedet a toplista.txt fájlban rögzítjük, így nyomon követheted a legjobb teljesítményeket.");
            Console.WriteLine();
            Console.WriteLine("Vissza a menuhoz: 1");
            string input = Console.ReadLine();
            if(input != null ) 
            {
                MainMenu fomenu = new MainMenu();
                fomenu.Menu();
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

/*Također,  potrebno je omogućiti ispis sadržaja u aplikaciji korištenjem sučelja *IPrinter* s dvije konkretne implementacije, 
konzolnom i datotečnom. Konzolnoj se inačici može zadati i naknadno izmijeniti boja teksta, dok se datotečnoj može zadati i 
naknadno izmijeniti datoteka u koju će zapisivati.

* Izlaz je formatiran tako da prikazuje očekivani izlaz s konzole i treba promatrati prikaz izlaza, a ne izvornu .md datoteku koja sadržava i html oznake.
* Metoda *PrintWeathers* ispisuje sve vremenske prilike na sve dostupne pisače.
*/

namespace WeatherConditionsClassLibrary
{
    public interface IPrinter
    {
        void Print(string weather);
    }
}

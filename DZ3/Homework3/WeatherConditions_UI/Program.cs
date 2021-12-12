using System;
/*U sustav za rad s informacijama o vremenskim prilikama trebate dodati klasu za generiranje vremenskih prilika 
(generiranje instanci klase *Weather*). Ta nova klasa definira raspone vrijednosti unutar kojih će biti postavljane 
vrijednosti atributa novostvorenih (generiranih) vremenskih prilika, generator pseudoslučajnih vrijednosti te metodu 
za generiranje vremenskih prilika.

Generator pseudoslučajnih vrijednosti treba biti predstavljen sučeljem *IRandomGenerator* koje ćete sami definirati, 
a ono sadrži metodu koja omogućuje generiranje realne vrijednosti unutar raspona zadanog predanim argumentima. 
Definirajte dva različita konkretna tipa generatora pseudoslučajnih vrijednosti. Prvi treba generirati vrijednosti
unutar zadanog raspona prema uniformnoj razdiobi. Drugi predstavlja pristrani generator. Kod pristranog generatora,
dvostruko je veća vjerojatnost generiranja vrijednosti u donjoj polovini raspona vrijednosti u odnosu na one iz gornje
polovine (vidjeti dodatne upute). 
 
Također,  potrebno je omogućiti ispis sadržaja u aplikaciji korištenjem sučelja *IPrinter* s dvije konkretne implementacije, 
konzolnom i datotečnom. Konzolnoj se inačici može zadati i naknadno izmijeniti boja teksta, dok se datotečnoj može zadati i 
naknadno izmijeniti datoteka u koju će zapisivati. 

Implementirajte sve potrebne klase i njihove metode kako bi se testni program u nastavku mogao ispravno izvesti. 
*/

using WeatherConditionsClassLibrary;

namespace WeatherConditions_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            const int weatherCount = 10;
            double minTemperature = -25.00, maxTemperature = 43.00;
            double minHumidity = 0.00, maxHumidity = 100.00;
            double minWindSpeed = 0.00, maxWindSpeed = 10.00;
            Random generator = new Random();

            IRandomGenerator randomGenerator = new UniformGenerator(generator);
            WeatherGenerator weatherGenerator = new WeatherGenerator(
                minTemperature, maxTemperature,
                minHumidity, maxHumidity,
                minWindSpeed, maxWindSpeed,
                randomGenerator
            );

            Weather[] uniformWeathers = new Weather[weatherCount];
            for (int i = 0; i < uniformWeathers.Length; i++)
            {
                uniformWeathers[i] = weatherGenerator.Generate();
            }

            randomGenerator = new BiasedGenerator(generator);
            weatherGenerator.SetGenerator(randomGenerator);
            Weather[] winterWeathers = new Weather[weatherCount];
            for (int i = 0; i < winterWeathers.Length; i++)
            {
                winterWeathers[i] = weatherGenerator.Generate();
            }

            IPrinter[] uniformPrinters = new IPrinter[]
            {
                new ConsolePrinter(ConsoleColor.DarkYellow),
                new FilePrinter(@"uniformWeathers.txt"),
            };
            ForecastUtilities.PrintWeathers(uniformPrinters, uniformWeathers);

            IPrinter[] winterPrinters = new IPrinter[]
            {
                new ConsolePrinter(ConsoleColor.Green),
                new FilePrinter(@"winterWeathers.txt"),
            };
            ForecastUtilities.PrintWeathers(winterPrinters, winterWeathers);
        }
    }
    
}

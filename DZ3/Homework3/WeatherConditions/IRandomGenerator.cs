using System;
using System.Collections.Generic;
using System.Text;

/*Generator pseudoslučajnih vrijednosti treba biti predstavljen sučeljem *IRandomGenerator* koje ćete sami definirati, 
a ono sadrži 
metodu koja omogućuje generiranje realne vrijednosti unutar raspona zadanog predanim argumentima. 
Definirajte dva različita konkretna tipa generatora pseudoslučajnih vrijednosti. Prvi treba generirati vrijednosti
unutar zadanog raspona prema uniformnoj razdiobi. Drugi predstavlja pristrani generator. Kod pristranog generatora,
dvostruko je veća vjerojatnost generiranja vrijednosti u donjoj polovini raspona vrijednosti u odnosu na one iz gornje
polovine (vidjeti dodatne upute).*/

namespace WeatherConditionsClassLibrary
{
    public interface IRandomGenerator
    {
         double GenerateRandomValue(double lowerValue, double upperValue);//limit
    }
}

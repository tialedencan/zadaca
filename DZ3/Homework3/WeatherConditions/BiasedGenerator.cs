using System;
using System.Collections.Generic;
using System.Text;

/*Kod pristranog generatora,
dvostruko je veća vjerojatnost generiranja vrijednosti u donjoj polovini raspona vrijednosti u odnosu na one iz gornje
polovine (vidjeti dodatne upute). 
 * Unutar vlastitih konkretnih generatora možete koristiti instancu Random klase.
* Gornja granica ne uključuje se kod generiranja. Ovo je samo da Vam olakša život ako koristite klasu *Random* čija metoda *NextDouble()* omogućuje generiranje pseudoslučajne vrijednosti u rasponu *0.0&le;r<1.0*.
* Ako je *Tmin=0*, a *Tmax=10*, tada će vjerojatnost generiranja vrijednosti *t<5* biti dvostruko veća u odnosu na *5&le;t<10*.
*/
namespace WeatherConditionsClassLibrary
{
    public class BiasedGenerator : IRandomGenerator
    {
        Random generator;
        public BiasedGenerator(Random generator)
        {
            this.generator = generator;
        }

        
         public double GenerateRandomValue(double lowerValue, double upperValue) 
         {

             double randomValue = generator.NextDouble(); //* (upperValue - lowerValue)/2 + lowerValue;
             //int probability = 0;


                 if (randomValue < 0.5)
                 {
                     return randomValue * (upperValue - lowerValue) / 2 + lowerValue;
                 }
                 else { return randomValue * (upperValue - lowerValue) + lowerValue; }


         }
    }
}

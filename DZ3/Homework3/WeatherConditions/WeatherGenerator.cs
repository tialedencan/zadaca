using System;
using System.Collections.Generic;
using System.Text;

/*U sustav za rad s informacijama o vremenskim prilikama trebate dodati klasu za generiranje vremenskih prilika 
(generiranje instanci klase *Weather*).
Ta nova klasa definira raspone vrijednosti unutar kojih će biti postavljane 
vrijednosti atributa novostvorenih (generiranih) vremenskih prilika,
generator pseudoslučajnih vrijednosti te 
metodu za generiranje vremenskih prilika.
*/
namespace WeatherConditionsClassLibrary
{
    public class WeatherGenerator
    {
        double minTemperature; double maxTemperature;
        double minHumidity; double maxHumidity;
        double minWindSpeed; double maxWindSpeed; 
        IRandomGenerator randomGenerator;

        public WeatherGenerator(double minTemperature, double maxTemperature,double minHumidity, double maxHumidity,double minWindSpeed, double maxWindSpeed,IRandomGenerator randomGenerator)
        {
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
            this.minHumidity = minHumidity;
            this.maxHumidity = maxHumidity;
            this.minWindSpeed = minWindSpeed;
            this.maxWindSpeed = maxWindSpeed;
            this.randomGenerator = randomGenerator;
        }

        public void SetGenerator(IRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }
        

        public Weather Generate()
        {
            double temperature = randomGenerator.GenerateRandomValue(this.minTemperature,this.maxTemperature);
            double humidity = randomGenerator.GenerateRandomValue(this.minHumidity, this.maxHumidity);
            double windSpeed = randomGenerator.GenerateRandomValue(this.minWindSpeed, this.maxWindSpeed);

            Weather randomWeather = new Weather(temperature, humidity, windSpeed);

            return randomWeather;
        }

        
    }
}

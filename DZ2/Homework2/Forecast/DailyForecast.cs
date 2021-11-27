using System;
using System.Collections.Generic;
using System.Text;

/*U sustav za rad s informacijama o vremenskim prilikama trebate dodati klasu koja predstavlja vremensku prognozu za određeni dan.
Vremenska prognoza sadržava informacije o datumu na koji se odnosi (struktura DateTime) te referencu na objekt tipa Weather iz Zadaće 1.*/

namespace ForecastClassLibrary
{
    public class DailyForecast
    {
        private DateTime date;
        Weather weather;

        public DailyForecast(DateTime date, Weather weather)
        {
            this.date = date;
            this.weather = weather;
        }

        public Weather GetWeather() { return weather; }
        public string GetAsString()
        {
            return $"{this.date.ToString()}: {this.weather.GetAsString()}";
            // 08/11/2021 00:00:00: T=6.17°C, w=4.9km/h, h=56.13%
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

/*U sustav za rad s informacijama o vremenskim prilikama trebate dodati klasu koja predstavlja vremensku prognozu za određeni dan.
Vremenska prognoza sadržava informacije o datumu na koji se odnosi (struktura DateTime) te referencu na objekt tipa Weather iz Zadaće 1.*/

namespace DailyForecastClassLibrary
{
    public class DailyForecast
    {
        private DateTime date;
        Weather weather;

        public DailyForecast(DateTime date, Weather weather)
        {
            this.date = date;
            this.weather=weather;
        }

        public DailyForecast() {

        }

        public Weather Weather { get { return this.weather; } } 
        public Weather GetWeather() { return weather; }
        public DateTime GetTime() { return date; }
        public override string ToString()
        {
            return $"{this.date.ToString("dd/MM/yyyy HH:mm:ss")}: {this.weather.ToString()}";
            // 08/11/2021 00:00:00: T=6.17°C, w=4.9km/h, h=56.13%
        }

       // public bool MoveNext() { return true; }

        //public object Current { get { return new DailyForecast(); } }
    }
}

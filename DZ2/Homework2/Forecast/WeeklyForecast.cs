using System;
using System.Collections.Generic;
using System.Text;

/*Također je potrebno dodati klasu koja predstavlja tjednu prognozu sa stanjem za čuvanje sedam dnevnih vremenskih prognoza u obliku polja.*/
namespace ForecastClassLibrary
{
    public class WeeklyForecast
    {

        private DailyForecast[] sevenDaysForecast;

        public WeeklyForecast(DailyForecast[] sevenDaysForecast)
        {
            this.sevenDaysForecast = sevenDaysForecast;
        }

        public string GetAsString()
        {
            return $"{sevenDaysForecast[0].GetAsString()}\n" +
                   $"{sevenDaysForecast[1].GetAsString()}\n" +
                   $"{sevenDaysForecast[2].GetAsString()}\n" +
                   $"{sevenDaysForecast[3].GetAsString()}\n" +
                   $"{sevenDaysForecast[4].GetAsString()}\n" +
                   $"{sevenDaysForecast[5].GetAsString()}\n" +
                   $"{sevenDaysForecast[6].GetAsString()}";
        }

        public double GetMaxTemperature() {

            Weather temp = sevenDaysForecast[0].GetWeather();
            foreach(DailyForecast forecast in sevenDaysForecast)
            {
                if(temp < forecast.GetWeather())
                {
                    temp = forecast.GetWeather();
                }
            }
            return temp.GetTemperature();
        }

        public DailyForecast this[int index]   // Indexer declaration
        {
            get
            {
                // Check the index limits.
                //if (index < 0 || index >= 8)
                    
               // else
                    return sevenDaysForecast[index];
            }
            set
            {
                if (!(index < 0 || index >= 8))
                    sevenDaysForecast[index] = value;
            }
        }

        //public DailyForecast WeeklyForecast() => sevenDaysForecast;
    }
}

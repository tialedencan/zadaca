using System;
using System.Collections.Generic;
using System.Text;

namespace ForecastClassLibrary
{
    public class ForecastUtilities
    {

        static public DailyForecast Parse(string dailyWeatherInput)
        {
            var values = dailyWeatherInput.Split(",");
            DateTime date=DateTime.Parse(values[0]);
            Weather day = new Weather(double.Parse(values[1]), double.Parse(values[3]), double.Parse(values[2]));
            
            return new DailyForecast(date,day);
        }

        static Weather FindWeatherWithLargestWindchill(Weather[] weathers)
        {

            int index = 0;
            double maxWindChill = weathers[0].CalculateWindChill();

            for (int i = 0; i < weathers.Length; i++)
            {
                if (maxWindChill < weathers[i].CalculateWindChill())
                {
                    maxWindChill = weathers[i].CalculateWindChill();
                    index = i;
                }
            }

            return weathers[index];

        }

    }
}

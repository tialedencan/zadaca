using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherConditionsClassLibrary
{
    public class ForecastUtilities
    {
        public static void PrintWeathers(IPrinter[] printers,Weather[] weathers)
        {
            for(int i=0;i<weathers.Length;i++)
            {
                printers[0].Print(weathers[i].ToString());
                printers[1].Print(weathers[i].ToString());
            }
        }
        static public DailyForecast Parse(string dailyWeatherInput)
        {
            string[] values = dailyWeatherInput.Split(",");
            DateTime date=DateTime.Parse(values[0]);
            double t = double.Parse(values[1].Replace(".",","));
            double h = double.Parse(values[3].Replace(".",","));
            double ws = double.Parse(values[2].Replace(".", ","));

            Weather day = new Weather(t,h, ws);
            
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

using System;
using System.Collections.Generic;
using System.Text;


namespace Weather_dz
{
    public class Weather
    {
        private double temperature;
        private double humidity;
        private double windSpeed;


        public Weather()
        {
            this.temperature = 24.3;
            this.humidity = 1.2;
            this.windSpeed = 12;
        }
        public Weather(double temperature, double humidity, double windSpeed)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.windSpeed = windSpeed;
        }

        public void SetTemperature(double temperature)
        {
            this.temperature = temperature;
        }

        public void SetWindSpeed(double windSpeed)
        {
            this.windSpeed = windSpeed;
        }

        public void SetHumidity(double humidity)
        {
            this.humidity = humidity;
        }

        public double GetTemperature()
        {
            return temperature;
        }

        public double GetHumidity()
        {
            return humidity;
        }

        public double GetWindSpeed()
        {
            return windSpeed;
        }

        public double CalculateFeelsLikeTemperature()
        {
            double heatIndex;
            heatIndex = Constants.c1 + Constants.c2 * this.temperature + Constants.c3 * this.humidity + Constants.c4 * this.temperature * this.humidity + Constants.c5 * Math.Pow(this.temperature, 2) + Constants.c6 * Math.Pow(this.humidity, 2) + Constants.c7 * Math.Pow(this.temperature, 2) * this.humidity + Constants.c8 * this.temperature * Math.Pow(this.humidity, 2) + Constants.c9 * Math.Pow(this.temperature, 2) * Math.Pow(this.humidity, 2);
            return heatIndex;
        }

       public double CalculateWindChill()
        {
            double WindChillIndex;
            WindChillIndex = 13.12 + 0.6215*temperature - 11.37*Math.Pow(windSpeed,0.16)  + 0.3965*temperature* Math.Pow(windSpeed, 0.16);
            
            if(  WindChillIndex < temperature) return WindChillIndex;
            return 0;
        }


    }
}

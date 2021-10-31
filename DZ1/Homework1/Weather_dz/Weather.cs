using System;
using System.Collections.Generic;
using System.Text;

namespace Weather_dz
{
    class Weather
    {
        private double temperature;
        private double humidity;
        private double windSpeed;

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


    }
}

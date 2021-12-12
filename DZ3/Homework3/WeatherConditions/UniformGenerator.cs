using System;
using System.Collections.Generic;
using System.Text;


namespace WeatherConditionsClassLibrary
{
    public class UniformGenerator:IRandomGenerator
    {
        Random generator;
        public UniformGenerator(Random generator)
        {
            this.generator = generator;
        }

        public double GenerateRandomValue(double lowerValue, double upperValue) 
        {
            if (lowerValue < upperValue)
            {
                double randomValue = generator.NextDouble() * (upperValue - lowerValue) + lowerValue;

                return randomValue;
            }
            else { return 0; }
        }
    }
}

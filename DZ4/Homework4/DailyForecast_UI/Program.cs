﻿using System;
using DailyForecastClassLibrary;
using System.Collections.Generic;
/* Definirajte klasu koja omogućuje pohranu dnevnih vremenskih prognoza za proizvoljan broj dana (klasa *DailyForecastRepository*).
 * Omogućite:
* dodavanje novih prognoza za pojedinačne dane
* dodavanje cijele liste prognoza
* uklanjanje prognoza po datumu
* izravno iteriranje po prognozi uporabom petlje *foreach*
* duboko kopiranje uporabom odgovarajućeg konstruktora

Implementirajte sve potrebne klase i njihove metode kako bi se testni program u nastavku mogao ispravno izvesti.*/

namespace DailyForecast_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            double minTemperature = -25.00, maxTemperature = 43.00;
            double minHumidity = 0.0, maxHumidity = 100.00;
            double minWindSpeed = 0.00, maxWindSpeed = 10.00;
            IRandomGenerator randomGenerator = new UniformGenerator(new Random());
            WeatherGenerator weatherGenerator = new WeatherGenerator(
                minTemperature, maxTemperature,
                minHumidity, maxHumidity,
                minWindSpeed, maxWindSpeed,
                randomGenerator
            );

            // Creating the repository and adding items.
            DailyForecastRepository repository = new DailyForecastRepository();
            repository.Add(new DailyForecast(DateTime.Now, weatherGenerator.Generate()));
            repository.Add(new DailyForecast(DateTime.Now.AddDays(1), weatherGenerator.Generate()));
            repository.Add(new DailyForecast(DateTime.Now.AddDays(2), weatherGenerator.Generate()));
            Console.WriteLine($"Current state of repository:{Environment.NewLine}{repository}");

            // Adding a new forecast for the same day should replace the old one:
            repository.Add(new DailyForecast(DateTime.Now.AddHours(2), weatherGenerator.Generate()));
            Console.WriteLine($"Current state of repository:{Environment.NewLine}{repository}");

            // Adding multiple forecasts, the ones for existing days should replace the old ones:
            List<DailyForecast> forecasts = new List<DailyForecast>() {
        new DailyForecast(DateTime.Now.AddDays(2), weatherGenerator.Generate()),
        new DailyForecast(DateTime.Now.AddDays(3), weatherGenerator.Generate()),
        new DailyForecast(DateTime.Now.AddDays(4), weatherGenerator.Generate()),
    };
            repository.Add(forecasts);
            Console.WriteLine($"Current state of repository:{Environment.NewLine}{repository}");
            // Removing forecasts based on date:
            try
            {
                repository.Remove(DateTime.Now);
                repository.Remove(DateTime.Now.AddDays(100));
            }
            catch (NoSuchDailyWeatherException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine($"Current state of repository:{Environment.NewLine}{repository}");

            // Iterating over a custom object:
            Console.WriteLine("Temperatures:");
            foreach (DailyForecast dailyForecast in repository)
            {
                Console.WriteLine($"-> {dailyForecast.Weather.GetTemperature()}");
            }

            // Deep clone:
            DailyForecastRepository copy = new DailyForecastRepository(repository);
            Console.WriteLine($"Original repository:{Environment.NewLine}{repository}");
            Console.WriteLine($"Cloned repository:{Environment.NewLine}{copy}");

            DailyForecast forecastToAdd = new DailyForecast(DateTime.Now, new Weather(-2.0, 47.12, 2.1));
            copy.Add(forecastToAdd);

            Console.WriteLine($"Original repository:{Environment.NewLine}{repository}");
            Console.WriteLine($"Cloned repository:{Environment.NewLine}{copy}");
        
    }
    }
}

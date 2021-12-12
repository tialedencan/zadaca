using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherConditionsClassLibrary
{
    public class ConsolePrinter:IPrinter
    {
        private ConsoleColor color;

        public ConsolePrinter(ConsoleColor color)
        {
            this.color = color;
        }

        public void Print(string weather)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(weather);
            Console.ResetColor();
            
        }
    }
}

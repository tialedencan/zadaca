using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WeatherConditionsClassLibrary
{
    public class FilePrinter:IPrinter
    {
        public string Filename{ get; private set; }
        public FilePrinter(string filename)
        {
            Filename= filename;
        }

        public void Print(string weather)
        {
            using (var writer = new StreamWriter(Filename, true))
                 {
                    writer.WriteLine(weather);
                 }
        }
    }
}

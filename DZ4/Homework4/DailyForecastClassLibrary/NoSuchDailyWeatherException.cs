using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DailyForecastClassLibrary
{
    [Serializable]
    public class NoSuchDailyWeatherException:Exception
    {
        DateTime date;
        public NoSuchDailyWeatherException() { }
        public NoSuchDailyWeatherException(string message):base (message) { }
        public NoSuchDailyWeatherException(string message, Exception innerException):base(message, innerException) { }
        public NoSuchDailyWeatherException(string message, DateTime date) : base(message)
        {
            this.date = date;
        }
        protected NoSuchDailyWeatherException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

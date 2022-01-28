using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace WpfWeatherUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         const string APPID = "54925ed5f4be1cd34d09f253f39617d1"; 
        public MainWindow()
        {
            InitializeComponent();
           
        }

       private void  SearchCityWeather_Click(object sender, RoutedEventArgs e)
       {
            GetWeather();
       }
        void GetWeather()
         {
             
             using (WebClient web =new WebClient()) {
                 string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", SearchLocation.Text, APPID);//&cnt=6  cityName
                
                 var json = web.DownloadString(url);

                 var result = JsonConvert.DeserializeObject<WeatherInformation.root>(json);

                 WeatherInformation.root output = result;

                txtCityCountry.Text = output.name+"   "+output.sys.country; //string.Format("{0}", output.name);

                //txtCountry.Text = ;
                txtTemperature.Text = output.main.temp.ToString()+"\u00B0C";
                txtWind.Text ="Wind: " + output.wind.speed.ToString()+" km/h";
                txtHumidityy.Text = "Humidity: " +output.main.humidity.ToString()+"%";
                txtVisibility.Text = "Visibility: "+(output.visibility/1000).ToString()+" km";

                /*string description = output.weather[0].description;
                StringBuilder sb = new StringBuilder();
                 sb.Append(description.ToUpper());
                for (int i = 1; i < sb.Length; i++)
                    sb.Replace(sb[i], description[i]);*/

                txtMessage.Text = output.weather[0].description;
                displayWeatherImage(output.weather[0].id);

             }
         }
        private void displayWeatherImage(int weatherId)
        {
            BitmapImage image = new BitmapImage(new Uri("../../../icons/thunderstorm.pg", UriKind.Relative));
            if (weatherId >= 200 && weatherId <= 232)
            {
                image = new BitmapImage(new Uri("../../../icons/thunderstorm.png", UriKind.Relative));
            }
            else if (weatherId >= 300 && weatherId <= 321)
            {
                image = new BitmapImage(new Uri("../../../icons/raindrops.png", UriKind.Relative));
            }
            else if (weatherId >= 500 && weatherId <= 531)
            {
                image = new BitmapImage(new Uri("../../../icons/rain.png", UriKind.Relative));
            }
            else if (weatherId >= 600 && weatherId <= 622)
            {
                image = new BitmapImage(new Uri("../../../icons/snow.png", UriKind.Relative));
            }
            else if (weatherId >= 700 && weatherId <= 781)
            {
                image = new BitmapImage(new Uri("../../../icons/refresh.png", UriKind.Relative));
            }
            else if (weatherId == 800)
            {
                image = new BitmapImage(new Uri("../../../icons/clear_night.png", UriKind.Relative));
            }
            else if (weatherId >= 801 && weatherId <= 804)
            {
                image = new BitmapImage(new Uri("../../../icons/clouds.png", UriKind.Relative));
            }
            imgWeather.Source = image;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

/* Definirajte klasu koja omogućuje pohranu dnevnih vremenskih prognoza za proizvoljan broj dana (klasa *DailyForecastRepository*).
 * Omogućite:
* dodavanje novih prognoza za pojedinačne dane
* dodavanje cijele liste prognoza
* uklanjanje prognoza po datumu
* izravno iteriranje po prognozi uporabom petlje *foreach*
* duboko kopiranje uporabom odgovarajućeg konstruktora*/

/*
*Dnevne prognoze unutar objekta u svakom su trenutku sortirane uzlazno prema datumu.
* U slučaju da se pokuša dodati prognoza za datum (uzeti u obzir samo datume, ne gledati vrijeme) koji je već prisutan, 
* potrebno je postojeću zamijeniti novom prognozom.
* U slučaju da kod brisanja ne postoji niti jedna prognoza, potrebno je podići iznimku vlastitog tipa izvedenog 
* iz klase *System.Exception* koja će čuvati i omogućiti pristup datumu koji je doveo do iznimke.
*/
namespace DailyForecastClassLibrary
{
    public class DailyForecastRepository :IEnumerable,IEnumerator
    {
        List<DailyForecast> list;
        
        private int position = -1;
        public DailyForecastRepository() { list = new List<DailyForecast>(); }
        public DailyForecastRepository(DailyForecastRepository repository)
        {
            this.list = new List<DailyForecast>();
            foreach(DailyForecast daily in repository.list)
            {
                this.list.Add(new DailyForecast(daily.GetTime(), daily.GetWeather()));
            }
        }
        public void Add(DailyForecast dailyForecast)
        {
            int flag = 0, index=0;
            int indexRemember=0;

            foreach (DailyForecast df in list)
            {
                if (df.GetTime().Date == dailyForecast.GetTime().Date)
                {
                    indexRemember = index;
                    flag = 1;
                }
                
                index++;
            }
            if (flag == 1)
            {
                 list.Remove(list[indexRemember]);
                 list.Insert(indexRemember,dailyForecast);
            }
                    
                    
            if(flag==0) list.Add(dailyForecast);

            //if(list.Contains(dailyForecast)) 
        
        }
        public void Add(List<DailyForecast> list)
        {
            foreach (DailyForecast dailyforecast in list)
            {
                Add(dailyforecast);
            
            }

        } 
 

        public void Remove(DateTime time)
        {
            if (list == null)
            {
                 throw new NoSuchDailyWeatherException("No forecasts in list", time);
            }

            int flag = 0,index=0,indexR=0;

            foreach (DailyForecast dailyforecast in list)
            {
                
                if (dailyforecast.GetTime().Date == time.Date)
                {
                    indexR = index;
                    flag = 1;
                }
                index++;
            }
            if (flag == 1)
            {
                list.Remove(list[indexR]);
            }
            
            if (flag == 0)
            {
                throw new NoSuchDailyWeatherException($"No daily forecast for {time.Date} ", time);
            }
                
        }

       
        public override string  ToString()
        {
            list = list.OrderBy(it => it.GetTime()).ToList();

            StringBuilder sb = new StringBuilder();
            foreach(DailyForecast df in list)
            {
                sb.Append(df + Environment.NewLine);
            }
            return sb.ToString();
        }
        //11.12.2021. 12:02:41: T=35.455357905689326°C, w=6.927796735860313km/h, h=13.351009792346048%

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            position++;
            return (position < list.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current { get { return list[position]; } }

    }
}

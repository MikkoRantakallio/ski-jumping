using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ski_jumping_score_calculator
{
    public class SiteWeather
    {
        static HttpClient client = new HttpClient();
        public static CurrentWeather localWeather = new CurrentWeather();

        static bool found;

        public double GetTemperature()
        {
            return Math.Round(localWeather.MainData.Temperature - 272.15);
        }

        public double GetWindSpeed()
        {
            return Math.Round(localWeather.Wind.Speed);
        }

        public double GetWindDirection()
        {
            return Math.Round(localWeather.Wind.Degree);
        }

        public double GetHumidity()
        {
            return localWeather.MainData.Humidity;
        }

        //===========================================================

        public SiteWeather()
        {
            string url = "http://api.openweathermap.org/data/2.5/";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            found = true;
        }

        public SiteWeather(string city)
        {
            string url = "http://api.openweathermap.org/data/2.5/";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            found = true;

            localWeather = GetWeather(city);
        }

        public CurrentWeather GetWeather(string city)
        {
            AskOpenWeather(client.BaseAddress + "weather?q=" + city);
            return localWeather;
        }

        //==========================================================================

        static void AskOpenWeather(string path)
        {
            path += "&APPID=52087b841a0e19eae02720bc08ef0b5b";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(path);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string data = string.Empty;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = readStream.ReadToEnd();
                localWeather = JsonConvert.DeserializeObject<CurrentWeather>(data);
                response.Close();
                readStream.Close();
                found = true;
            }
            else
            {
                found = false;
            }
        }
    }
}

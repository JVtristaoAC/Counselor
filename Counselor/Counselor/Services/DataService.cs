using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Counselor.Model;
using Microsoft.CSharp;
namespace Counselor.Services
{
    public class DataService
    {

        public static async Task<Advices> GetAdviceRandom()
        {
            string queryString = "https://api.adviceslip.com/advice";
            dynamic result = await getDataFromService(queryString).ConfigureAwait(false);

            if (result["slip"] != null)
            {
                Advices advice = new Advices();
                advice.Advice = (string)result["slip"]["advice"];
                advice.Slip_ID = (string)result["slip"]["id"];
                return advice;
            }
            else
            {
                return null;
            }

        }

        public static async Task<Advices> GetAdvicebyNum(string Advice_Num)
        {
            string queryString = "https://api.adviceslip.com/advice/" + Advice_Num;
            dynamic result = await getDataFromServiceByNum(queryString).ConfigureAwait(false);

            if (result["slip"] != null)
            {
                Advices advice = new Advices();
                advice.Advice = (string)result["slip"]["advice"];
                advice.Slip_ID = (string)result["slip"]["id"];
                return advice;
            }
            else
            {
                return null;
            }

        }

        public static async Task<dynamic> getDataFromService(string queryString)
        {

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);
            dynamic data = null;

            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;

        }

        public static async Task<dynamic> getDataFromServiceByNum(string url)
        {



            Console.WriteLine(url);


            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            dynamic data = null;

            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }
    }
}

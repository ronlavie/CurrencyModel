using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CurrencyModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CurrencyBL
{
    public class CurrencyManager
    {
        private static string apiUrl = "https://boi.org.il/PublicApi/GetExchangeRates";

        public CurrencyList GetCurrencyList()
        {
            CurrencyList list = new CurrencyList();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Send GET request synchronously
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as string
                        string jsonResponse = response.Content.ReadAsStringAsync().Result;

                        // Parse JSON response
                        JObject data = JObject.Parse(jsonResponse);

                        // Extract and process items
                        JArray itemsArray = (JArray)data["exchangeRates"];
                        foreach (JToken item in itemsArray)
                        {
                            Currency currency = new Currency()
                            {
                                key = item["key"].ToString(),
                                Rate = double.Parse(item["currentExchangeRate"].ToString()),
                                change = double.Parse(item["currentChange"].ToString()),
                                unit = int.Parse(item["unit"].ToString())
                            };
                            list.Add(currency);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Failed to retrieve data. Status code: " + response.StatusCode);
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    return null;
                }
                return list;
            }
        }

        public double convert(Currency source, Currency target, double amount)
        {
            return(source.Rate/source.unit)/(target.Rate/target.unit) * amount; 
        }


    }
}

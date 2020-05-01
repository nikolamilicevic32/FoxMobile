using Fox.Common.Configurations;
using Fox.Common.Models;
using Fox.DataProvider.InterfaceServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fox.DataProvider.Services
{
    public class ItemService : IItemService
    {
        /// <summary>
        /// Method that retrieve all items from WebApi
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Configuration.FoxApiBase);
                    responseMessage = await client.GetAsync($"api/article").ConfigureAwait(false);
                    responseMessage.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<Item>>(await responseMessage.Content.ReadAsStringAsync()) ?? new List<Item>();
            return result;
        }

        /// <summary>
        /// Method that retrieve items specific of category from WebApi
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Item> GetItem(Guid id)
        {
            HttpResponseMessage response = null;

            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(Configuration.FoxApiBase);
                        response = await client.GetAsync($"api/article/{id.ToString()}").ConfigureAwait(false);
                        response.EnsureSuccessStatusCode();
                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

            }

            var result = JsonConvert.DeserializeObject<Item>(await response.Content.ReadAsStringAsync()) ?? null;
            return result;
        }


        /// <summary>
        /// Method that return specific item
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Item>> GetItems(string CategoryId)
        {
            HttpResponseMessage response = null;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(Configuration.FoxApiBase);
                    response = await client.GetAsync($"api/article/{CategoryId}").ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<Item>>(await response.Content.ReadAsStringAsync()) ?? new List<Item>();
            return result;
        }
    }
}

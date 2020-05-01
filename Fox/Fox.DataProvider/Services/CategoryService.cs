using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Fox.Common.Configurations;
using Fox.Common.Models;
using Newtonsoft.Json;

namespace Fox.DataProvider
{
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Get all categories from api
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Configuration.FoxApiBase);
                    response = await client.GetAsync("api/Category").ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            var result = JsonConvert.DeserializeObject<IEnumerable<Category>>(await response.Content.ReadAsStringAsync()) ?? new List<Category>();
            return result;
        }
    }
}

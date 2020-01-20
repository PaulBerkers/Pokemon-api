using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Popups;


namespace Pokemon_api.Assets.Classes
{
    public class PokeAPIWrapper
    {
        public static async Task<List<Result>> GetResults()
        {
            Uri request = new Uri(@"https://pokeapi.co/api/v2/pokemon?limit=-1");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Pokemon api");
            HttpResponseMessage respons = await client.GetAsync(request);
            if (respons.IsSuccessStatusCode == false)
            {
                MessageDialog md = new MessageDialog("Kon geen pokemon vinden op basis van deze naam");
                await md.ShowAsync();
                return null;
            }

            respons.EnsureSuccessStatusCode();

            Pokeapi mc = await respons.Content.ReadAsAsync<Pokeapi>();

            return mc.Results;
        }
    }
}

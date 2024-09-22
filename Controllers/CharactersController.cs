using ApiPersonajes.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace ApiPersonajes.Controllers
{
    [Route("api/characters")]
    public class CharactersController : Controller
    {
        private HttpClient _httpClient;
        public CharactersController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("all")]
        public async Task<Characters> GetAllCharacters(int page, string name = null)
        {
            try
            {
                Characters characters = null;
                string url = string.IsNullOrEmpty(name) ?  $"https://rickandmortyapi.com/api/character?page={page}"
					: $"https://rickandmortyapi.com/api/character?page={page}&name={name}";

				HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(url);

                httpResponseMessage.EnsureSuccessStatusCode();

                string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

                characters = JsonConvert.DeserializeObject<Characters>(responseBody);

                return characters;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

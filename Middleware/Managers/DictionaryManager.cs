using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Middleware.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Middleware.Managers;

public class DictionaryManager
{
    public async Task<List<DictionaryResponse>> GetDefinition(string word)
    {

        HttpClient client = new HttpClient();
        string requestUri = "https://65bc6cad52189914b5bde364.mockapi.io/hugedata/retrieve";

        HttpResponseMessage httpResponseMessage = await client.GetAsync(requestUri);
        List<DictionaryResponse> dictionaryResponse = new List<DictionaryResponse>();
        if (httpResponseMessage.IsSuccessStatusCode)
        {
            var stringResponse = await httpResponseMessage.Content.ReadAsStringAsync();
            dictionaryResponse  = JsonConvert.DeserializeObject<List<DictionaryResponse>>(stringResponse);
        }
        
        return dictionaryResponse;
    }
}

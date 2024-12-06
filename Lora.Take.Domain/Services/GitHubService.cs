using Lora.Take.Domain.Interfaces.Services;
using Lora.Take.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lora.Take.Domain.Services;
public class GitHubService : IGitHubService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _token = "seu_token_aqui";

    public GitHubService(IHttpClientFactory httpClient)
    {
        _httpClientFactory = httpClient;
    }

    /// <summary>
    /// Deve retornar as informações contidas num repositório baseado
    /// nos dados disponibilizados em GiHubInfo
    /// </summary>
    /// <param name="repositoryName"></param>
    /// <returns></returns>
    public async Task<List<GitHubRepositoryInfo>> GetRepositoryInformation(string repositoryName)
    {
       var url = $"https://api.github.com/orgs/{repositoryName}/repos";
       var request = new HttpRequestMessage(HttpMethod.Get, url);

       //user agent
       request.Headers.Add("User-Agent", "DotNetApp");
       request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

       //envia a requisição
       var client = _httpClientFactory.CreateClient("github");

       var response = client.Send(request);
       response.EnsureSuccessStatusCode();

       var jsonResponse = await response.Content.ReadAsStringAsync();

       var items = JsonConvert.DeserializeObject<List<GitHubRepositoryInfo>>(jsonResponse);

        return items
        .Where(repo => repo.Language != null && repo.Language.Equals("C#", StringComparison.OrdinalIgnoreCase))
        .OrderByDescending(repo => repo.CreatedAt)
        .Take(5)
        .ToList();
    }
}

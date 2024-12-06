using Lora.Take.Domain.Interfaces.Services;
using Lora.Take.Domain.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lora.Take.Domain.Services;
public class GitHubService : IGitHubService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly string _githubToken;

    public GitHubService(IHttpClientFactory httpClient, IConfiguration configuration)
    {
        _httpClientFactory = httpClient;
        _githubToken = Environment.GetEnvironmentVariable("GitHub_ApiToken")
                ?? throw new InvalidOperationException("O token da API GitHub não foi configurado.");
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

        request.Headers.Add("User-Agent", "DotNetApp");
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _githubToken);

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

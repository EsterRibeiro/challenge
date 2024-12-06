using Lora.Take.Domain.Interfaces.Services;
using Lora.Take.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lora.Take.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GitHubController : ControllerBase
{
    private readonly IGitHubService _gitHubService;

    public GitHubController(IGitHubService gitHubService)
    {
        _gitHubService = gitHubService;
    }

    /// <summary>
    /// Deve chamar o serviço que irá trazer os últimos 5 repositórios
    /// </summary>
    /// <param name="repositoryName"></param>
    [HttpGet("{repositoryName}")]
    [ProducesResponseType(typeof(List<GitHubRepositoryInfo>), 200)]
    public IActionResult Get(string repositoryName)
    {
        try
        {
            var response = _gitHubService.GetRepositoryInformation(repositoryName);
            return StatusCode(200, response);
        }
        catch (Exception exception) 
        {
            return StatusCode(500, new { exception.Message });
        }
    }


}

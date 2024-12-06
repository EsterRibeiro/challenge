using Lora.Take.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lora.Take.Domain.Interfaces.Services;
public interface IGitHubService
{
    Task<List<GitHubRepositoryInfo>> GetRepositoryInformation(string repositoryName);
}

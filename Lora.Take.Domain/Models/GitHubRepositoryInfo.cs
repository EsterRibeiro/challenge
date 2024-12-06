using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lora.Take.Domain.Models;
public class GitHubRepositoryInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
    public DateTime CreatedAt { get; set; }

    [JsonConstructor]
    public GitHubRepositoryInfo
    (
        string name,
        string description,
        string language,
        DateTime created_at

    )
    {
        Name = name;
        Description = description;
        Language = language;
        CreatedAt = created_at;
    }
}

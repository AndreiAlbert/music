using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace src.Models;

public class Artist
{
    [Key]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("albums")]
    public List<Album> Albums { get; set; }
}
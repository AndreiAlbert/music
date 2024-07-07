using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace src.Models;

public class Album
{
    [Key]
    public int Id { get; set; }
    
    [JsonPropertyName("title")]
    public string Title { get; set;  }

    [JsonPropertyName("songs")] 
    public List<Song> Songs { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonIgnore]
    public int ArtistId { get; set; }
    
    [ForeignKey("ArtistId")]
    public Artist Artist { get; set; }
}
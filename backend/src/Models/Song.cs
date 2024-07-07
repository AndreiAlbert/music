using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace src.Models;

public class Song
{
    [Key]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("length")] 
    public string Length { get; set; }
    
    public int AlbumId { get; set; }
    
    [ForeignKey("AlbumId")]
    public Album Album { get; set; }
}
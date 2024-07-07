using System.Text.Json;
using src.Models;

namespace src.Services;

public class JsonDataLoader
{
    private readonly MusicContext _context;

    public JsonDataLoader(MusicContext context)
    {
        _context = context;
    }

    public async Task LoadJsonData(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        var jsonData = JsonSerializer.Deserialize<List<Artist>>(jsonString);
        await _context.Artists.AddRangeAsync(jsonData);
        await _context.SaveChangesAsync();
    }
}
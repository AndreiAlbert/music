using Microsoft.EntityFrameworkCore;

namespace src.Models;

public class MusicContext: DbContext
{
    public MusicContext(DbContextOptions<MusicContext> options): base(options) {}
    
    public DbSet<Artist> Artists { get; set; }
    
    public DbSet<Song> Songs { get; set; }
    
    public DbSet<Album> Albums { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artist>()
            .HasMany(a => a.Albums)
            .WithOne(a => a.Artist)
            .HasForeignKey(a => a.ArtistId);

        modelBuilder.Entity<Album>()
            .HasMany(a => a.Songs)
            .WithOne(s => s.Album)
            .HasForeignKey(s => s.AlbumId);
    }
}
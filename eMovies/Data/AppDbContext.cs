using eMovies.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActorMovie>()
            .HasKey(am => new { am.MovieId, am.ActorId });

        modelBuilder.Entity<ActorMovie>()
            .HasOne(am => am.Movie)
            .WithMany(m => m.Actors)
            .HasForeignKey(am => am.MovieId);

        modelBuilder.Entity<ActorMovie>()
            .HasOne(am => am.Actor)
            .WithMany(a => a.Movies)
            .HasForeignKey(am => am.ActorId);

        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Cinema)
            .WithMany(c => c.Movies)
            .HasForeignKey(m => m.CinemaId);

        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Director)
            .WithMany(p => p.Movies)
            .HasForeignKey(m => m.DirectorId);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<ActorMovie> Actors_Movies { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
}

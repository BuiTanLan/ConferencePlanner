using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Attendee> Attendees => Set<Attendee>();
    public DbSet<Session> Sessions => Set<Session>();

    public DbSet<Speaker> Speakers => Set<Speaker>();

    public DbSet<Track> Tracks => Set<Track>();
}
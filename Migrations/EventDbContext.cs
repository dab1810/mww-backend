using team_scriptslingers_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace team_scriptslingers_backend.Migrations;

public class EventDbContext : DbContext
{
    public DbSet<Event> Events { get; set; }

    public EventDbContext(DbContextOptions<EventDbContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.eventId);
            entity.Property(e => e.eventTitle);
            entity.Property(e => e.description);
            entity.Property(e => e.location);
            entity.Property(e => e.hostName);
            entity.Property(e => e.attendeeList);
            entity.Property(e => e.eventTime);
            entity.Property(e => e.isFinished);
        });

        modelBuilder.Entity<Event>().HasData(
            new Event
            {
                eventId = 1,
                eventTitle = "Event number ONE",
                description = "This is the first scheduled event on the database",
                hostName = "David"
            },
            new Event
            {
                eventId = 2,
                eventTitle = "Event number TWO",
                description = "This is the SECOND scheduled event on the database",
                hostName = "Marina"
            },
            new Event
            {
                eventId = 3,
                eventTitle = "Event number THREE",
                description = "This is the THIRD scheduled event on the database",
                hostName = "Joseph"
            }
        );
    }
}

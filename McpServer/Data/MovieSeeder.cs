using Bogus;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace McpServer.Data;

public static class MovieSeeder
{
    private static readonly string[] genres = new[] { "Action", "Comedy", "Drama", "Horror", "Sci-Fi" };

    public static async Task SeedAsync(MovieDbContext dbContext)
    {
        if (await dbContext.Movies.AnyAsync())
        {
            return; // Database has already been seeded
        }

        var faker = new Faker<Movie>().
            RuleFor(m => m.Title, f => f.Lorem.Sentence(3)).
            RuleFor(m => m.ReleaseYear, f => f.Random.Number(1950, 2023)).
            RuleFor(m => m.Director, f => f.Name.FullName()).
            RuleFor(m => m.Genre, f => f.PickRandom(genres)).
            RuleFor(m => m.Rating, f => f.Random.Decimal(1, 10));

        await dbContext.Movies.AddRangeAsync(faker.Generate(200));
        await dbContext.SaveChangesAsync();
    }
}

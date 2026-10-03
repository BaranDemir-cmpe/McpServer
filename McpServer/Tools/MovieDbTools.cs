using McpServer.Data;
using ModelContextProtocol.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace McpServer.Tools;

[McpServerToolType]
public class MovieDbTools(MovieDbContext context)
{
    private readonly MovieDbContext _context = context;

    [McpServerTool, Description("Search for movies in the database by title, director, or genre and take up to 10")]
    public async Task<string> SearchMovies(string searchTerm)
    {
        var matches = await _context.Movies
            .Where(m => m.Title.Contains(searchTerm) || m.Director.Contains(searchTerm) || m.Genre.Contains(searchTerm))
            .OrderBy(m => m.Title)
            .Take(10)
            .ToListAsync();

        if (matches.Count == 0)
        {
            return $"No movies found matching '{searchTerm}'.";
        }

        return $"Found {matches.Count} movies matching '{searchTerm}':\n" +
               string.Join("\n", matches.Select(m => $"{m.Title} ({m.ReleaseYear}) - Directed by {m.Director}, Genre: {m.Genre}, Rating: {m.Rating:F1}"));
    }

    [McpServerTool, Description("Get detailed information about a movie by its title")]
    public async Task<string> GetMovieDetailsByMovieTitle(string movieTitle)
    {
        var movie = await _context.Movies.Where(m => m.Title == movieTitle).FirstOrDefaultAsync();
        if (movie == null)
        {
            return $"Movie with title {movieTitle} not found.";
        }
        return $"Title: {movie.Title}\n" +
               $"Director: {movie.Director}\n" +
               $"Genre: {movie.Genre}\n" +
               $"Release Year: {movie.ReleaseYear}\n" +
               $"Rating: {movie.Rating:F1}";
    }
}

# MCP Movie Server

A simple Model Context Protocol (MCP) server built with .NET 10, Entity Framework Core, and SQL Server.

It allows MCP-compatible clients such as Claude Desktop to search a movie database and retrieve movie details.

## Features

- Search movies by title, director, or genre
- Get detailed information about a movie by title
- Entity Framework Core with SQL Server
- MCP tools exposed through stdio transport
- Seeded sample movie data

## Technologies

- .NET 10
- C#
- Model Context Protocol SDK
- Entity Framework Core
- SQL Server
- Bogus

## Configuration

Create an `appsettings.json` file:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=MovieDb;Trusted_Connection=true;TrustServerCertificate=true;"
  }
}
```

## Claude Desktop
After publishing the project, add the executable to your Claude Desktop MCP configuration:
```json
  {
    "mcpServers": {
      "movie-server": {
        "command": "C:/path/to/McpServer.exe",
        "args": []
      }
    }
  }
```

Restart Claude Desktop after updating the configuration.

## Purpose
This project was created to practice building a custom MCP server and connecting an AI client to external database data through MCP tools.

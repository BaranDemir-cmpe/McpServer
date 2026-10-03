using System;
using System.Collections.Generic;
using System.Text;

namespace McpServer.Data;

public sealed class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public int ReleaseYear { get; set; }
    public decimal Rating { get; set; }
}

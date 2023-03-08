using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPIPrectice.Models;

namespace WebAPIPrectice.Data;

public partial class WebAPIContext : DbContext
{
    public WebAPIContext(DbContextOptions<WebAPIContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

﻿using AidManager.API.Authentication.Domain.Model.Entities;
using AidManager.API.Collaborate.Domain.Model.Entities;
using AidManager.API.ManageCosts.Domain.Model.Aggregates;
using AidManager.API.SampleBounded.Domain.Model.Aggregates;
using AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AidManager.API.Shared.Infraestructure.Persistence.EFC.Configuration;

public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions options) : base(options){}
    
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // this method is to configure the database schema and the tables
        base.OnModelCreating(builder);
        
        // here we can configure the tables for books
        builder.Entity<Book>().ToTable("Books");
        builder.Entity<Book>().HasKey(b => b.Id);
        builder.Entity<Book>().Property(b => b.Id).IsRequired().ValueGeneratedOnAdd();
        
        // here we can configure the tables for post
        builder.Entity<Post>().ToTable("Posts");
        builder.Entity<Post>().HasKey(p => p.Id);
        builder.Entity<Post>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        // table for events
        builder.Entity<Event>().ToTable("Events");
        builder.Entity<Event>().HasKey(e => e.Id);
        builder.Entity<Event>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Analytic>().ToTable("Analytics");
        builder.Entity<Analytic>().HasKey(a => a.Id);
        builder.Entity<Analytic>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        
        // this is to the name tables conver to snake case "LuchoPortuano" -> "lucho_portuano"
        builder.UseSnakeCaseNamingConvention();
    }
}
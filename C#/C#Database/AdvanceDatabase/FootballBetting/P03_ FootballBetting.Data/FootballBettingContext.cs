﻿using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Configuration;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext:DbContext
    {
	    public FootballBettingContext()
	    {
		    
	    }

	    public FootballBettingContext(DbContextOptions options):base(options)
	    {
		    
	    }
	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    if (!optionsBuilder.IsConfigured)
		    {
			    optionsBuilder.UseSqlServer("Server=.;Database=FootballBetting;Integrated Security=True;");
		    }
	    }

		public DbSet<Team> Teams { get; set; }
		public DbSet<Bet> Bets { get; set; }
		public DbSet<Color> Colors { get; set; }
		public DbSet<Country> Countries { get; set; }
		public DbSet<Town> Towns { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
		public DbSet<Position> Positions { get; set; }

	    protected override void OnModelCreating(ModelBuilder builder)
	    {
		    builder.ApplyConfiguration(new ColorConfiguration());
		    builder.ApplyConfiguration(new BetConfiguration());
		    builder.ApplyConfiguration(new CountryConfiguration());
		    builder.ApplyConfiguration(new GameConfiguration());
		    builder.ApplyConfiguration(new PlayerConfiguration());
		    builder.ApplyConfiguration(new PositionConfiguration());
		    builder.ApplyConfiguration(new TeamConfiguration());
		    builder.ApplyConfiguration(new TownConfiguration());
		    builder.ApplyConfiguration(new UserConfiguration());
		    builder.ApplyConfiguration(new PlayerStatisticConfiguration());
	    }
	}
}

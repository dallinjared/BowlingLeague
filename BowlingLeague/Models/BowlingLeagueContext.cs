using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BowlingLeague.Models
{
    public partial class BowlingLeagueContext : DbContext
    {
        public BowlingLeagueContext()
        {
        }

        public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BowlerScores> BowlerScores { get; set; }
        public virtual DbSet<Bowlers> Bowlers { get; set; }
        public virtual DbSet<MatchGames> MatchGames { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Tournaments> Tournaments { get; set; }
        public virtual DbSet<TourneyMatches> TourneyMatches { get; set; }
        public virtual DbSet<ZtblBowlerRatings> ZtblBowlerRatings { get; set; }
        public virtual DbSet<ZtblSkipLabels> ZtblSkipLabels { get; set; }
        public virtual DbSet<ZtblWeeks> ZtblWeeks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source = BowlingLeague.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BowlerScores>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GameNumber, e.BowlerId });

                entity.ToTable("Bowler_Scores");

                entity.HasIndex(e => e.BowlerId)
                    .HasName("BowlerID");

                entity.HasIndex(e => new { e.MatchId, e.GameNumber })
                    .HasName("MatchGamesBowlerScores");

                entity.Property(e => e.MatchId)
                    .HasColumnName("MatchID")
                    .HasColumnType("int");

                entity.Property(e => e.GameNumber).HasColumnType("smallint");

                entity.Property(e => e.BowlerId)
                    .HasColumnName("BowlerID")
                    .HasColumnType("int");

                entity.Property(e => e.HandiCapScore)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RawScore)
                    .HasColumnType("smallint")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.WonGame)
                    .IsRequired()
                    .HasColumnType("bit")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Bowler)
                    .WithMany(p => p.BowlerScores)
                    .HasForeignKey(d => d.BowlerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Bowlers>(entity =>
            {
                entity.HasKey(e => e.BowlerId);

                entity.HasIndex(e => e.BowlerLastName)
                    .HasName("BowlerLastName");

                entity.HasIndex(e => e.TeamId)
                    .HasName("BowlersTeamID");

                entity.Property(e => e.BowlerId)
                    .HasColumnName("BowlerID")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.BowlerAddress).HasColumnType("nvarchar (50)");

                entity.Property(e => e.BowlerCity).HasColumnType("nvarchar (50)");

                entity.Property(e => e.BowlerFirstName).HasColumnType("nvarchar (50)");

                entity.Property(e => e.BowlerLastName).HasColumnType("nvarchar (50)");

                entity.Property(e => e.BowlerMiddleInit).HasColumnType("nvarchar (1)");

                entity.Property(e => e.BowlerPhoneNumber).HasColumnType("nvarchar (14)");

                entity.Property(e => e.BowlerState).HasColumnType("nvarchar (2)");

                entity.Property(e => e.BowlerZip).HasColumnType("nvarchar (10)");

                entity.Property(e => e.TeamId)
                    .HasColumnName("TeamID")
                    .HasColumnType("int");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Bowlers)
                    .HasForeignKey(d => d.TeamId);
            });

            modelBuilder.Entity<MatchGames>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.GameNumber });

                entity.ToTable("Match_Games");

                entity.HasIndex(e => e.MatchId)
                    .HasName("TourneyMatchesMatchGames");

                entity.HasIndex(e => e.WinningTeamId)
                    .HasName("Team1ID");

                entity.Property(e => e.MatchId)
                    .HasColumnName("MatchID")
                    .HasColumnType("int");

                entity.Property(e => e.GameNumber).HasColumnType("smallint");

                entity.Property(e => e.WinningTeamId)
                    .HasColumnName("WinningTeamID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.MatchGames)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.HasKey(e => e.TeamId);

                entity.HasIndex(e => e.TeamId)
                    .HasName("TeamID")
                    .IsUnique();

                entity.Property(e => e.TeamId)
                    .HasColumnName("TeamID")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.CaptainId)
                    .HasColumnName("CaptainID")
                    .HasColumnType("int");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasColumnType("nvarchar (50)");
            });

            modelBuilder.Entity<Tournaments>(entity =>
            {
                entity.HasKey(e => e.TourneyId);

                entity.Property(e => e.TourneyId)
                    .HasColumnName("TourneyID")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.TourneyDate).HasColumnType("date");

                entity.Property(e => e.TourneyLocation).HasColumnType("nvarchar (50)");
            });

            modelBuilder.Entity<TourneyMatches>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.ToTable("Tourney_Matches");

                entity.HasIndex(e => e.EvenLaneTeamId)
                    .HasName("Tourney_MatchesEven");

                entity.HasIndex(e => e.OddLaneTeamId)
                    .HasName("TourneyMatchesOdd");

                entity.HasIndex(e => e.TourneyId)
                    .HasName("TourneyMatchesTourneyID");

                entity.Property(e => e.MatchId)
                    .HasColumnName("MatchID")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.EvenLaneTeamId)
                    .HasColumnName("EvenLaneTeamID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Lanes).HasColumnType("nvarchar (5)");

                entity.Property(e => e.OddLaneTeamId)
                    .HasColumnName("OddLaneTeamID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TourneyId)
                    .HasColumnName("TourneyID")
                    .HasColumnType("int")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.EvenLaneTeam)
                    .WithMany(p => p.TourneyMatchesEvenLaneTeam)
                    .HasForeignKey(d => d.EvenLaneTeamId);

                entity.HasOne(d => d.OddLaneTeam)
                    .WithMany(p => p.TourneyMatchesOddLaneTeam)
                    .HasForeignKey(d => d.OddLaneTeamId);

                entity.HasOne(d => d.Tourney)
                    .WithMany(p => p.TourneyMatches)
                    .HasForeignKey(d => d.TourneyId);
            });

            modelBuilder.Entity<ZtblBowlerRatings>(entity =>
            {
                entity.HasKey(e => e.BowlerRating);

                entity.ToTable("ztblBowlerRatings");

                entity.Property(e => e.BowlerRating).HasColumnType("nvarchar (15)");

                entity.Property(e => e.BowlerHighAvg).HasColumnType("smallint");

                entity.Property(e => e.BowlerLowAvg).HasColumnType("smallint");
            });

            modelBuilder.Entity<ZtblSkipLabels>(entity =>
            {
                entity.HasKey(e => e.LabelCount);

                entity.ToTable("ztblSkipLabels");

                entity.Property(e => e.LabelCount)
                    .HasColumnType("int")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ZtblWeeks>(entity =>
            {
                entity.HasKey(e => e.WeekStart);

                entity.ToTable("ztblWeeks");

                entity.Property(e => e.WeekStart).HasColumnType("date");

                entity.Property(e => e.WeekEnd).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TennisTableASP.Models
{
    public class Context : DbContext
    {
        public Context()
        {
        }
        public DbSet<Classements> Classements { get; set; }
        public DbSet<Clubs> Clubs { get; set; }
        public DbSet<Joueurs> Joueurs { get; set; }
        public DbSet<Matchs> Matchs { get; set; }
        public DbSet<Rencontres> Rencontres { get; set; }
        public DbSet<SchemasRencontres> SchemasRencontres { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Sexes> Sexes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Joueurs>()
                    .HasRequired<Sexes>(p => p.SexeId)
                    .WithMany()
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Joueurs>()
                    .HasRequired<Classements>(p => p.ClassementId)
                    .WithMany()
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Joueurs>()
                    .HasRequired<Clubs>(p => p.ClubId)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Joueurs>(p => p.JVe1)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Joueurs>(p => p.JVe2)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Joueurs>(p => p.JVe3)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Joueurs>(p => p.JVe4)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Joueurs>(p => p.JVr1)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Joueurs>(p => p.JVr2)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Joueurs>(p => p.JVr3)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Joueurs>(p => p.JVr4)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Clubs>(p => p.ClubVe)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Clubs>(p => p.ClubVr)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Joueurs>(p => p.JVr1)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Matchs>()
                    .HasRequired<Series>(p => p.Serie)
                    .WithMany()
                    .WillCascadeOnDelete(false);
            modelBuilder.Entity<Rencontres>()
                    .HasRequired<SchemasRencontres>(p => p.Sr)
                    .WithMany()
                    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
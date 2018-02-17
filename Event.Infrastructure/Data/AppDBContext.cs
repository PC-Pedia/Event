using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Event.Model.EntityModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Event.Service.Data
{

    //public class AppRole:IdentityRole<int>
    //{

    //}


    public partial class AppDBContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        { }

        public DbSet<Ewent> Events { get; set; }
        public DbSet<EventCategory> Categories { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<AppUser>()
                .HasMany(x => x.Events)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                    ;

            modelBuilder.Entity<AppUser>()
                .HasMany(x => x.Purchases)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                ;

            modelBuilder.Entity<AppUser>()
             .HasMany(x => x.Comments)
             .WithOne(x => x.User)
             .HasForeignKey(x => x.UserId)
             .OnDelete(DeleteBehavior.Cascade)
            ;

            modelBuilder.Entity<AppUser>()
               .HasOne(x => x.City)
               .WithMany(x => x.Users)
               .HasForeignKey(x => x.CityId)
               .OnDelete(DeleteBehavior.SetNull)
                   ;

            //comment 
            modelBuilder.Entity<Comments>()
           .HasOne(x => x.User)
           .WithMany(x => x.Comments)
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            //purchase 
            modelBuilder.Entity<Purchase>()
            .HasOne(x => x.User)
           .WithMany(x => x.Purchases)
           .HasForeignKey(x => x.UserId)
           .OnDelete(DeleteBehavior.Restrict)
           ;

            //Event

            modelBuilder.Entity<Ewent>()
             .HasMany(x => x.Comments)
             .WithOne(x => x.Event)
             .HasForeignKey(x => x.EventId)
             .OnDelete(DeleteBehavior.Cascade)
            ;

            modelBuilder.Entity<Ewent>()
           .HasMany(x => x.Purchases)
           .WithOne(x => x.Event)
           .HasForeignKey(x => x.EventId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Ewent>()
           .HasOne(x => x.Category)
           .WithMany(x => x.Events)
           .HasForeignKey(x => x.CategoryId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ewent>()
          .HasOne(x => x.City)
          .WithMany(x => x.Events)
          .HasForeignKey(x => x.CityId)
          .OnDelete(DeleteBehavior.Restrict);

            //event category
            modelBuilder.Entity<EventCategory>()
           .HasMany(x => x.Events)
           .WithOne(x => x.Category)
           .HasForeignKey(x => x.CategoryId)
          .OnDelete(DeleteBehavior.Restrict);

            //city
            modelBuilder.Entity<Province>()
            .HasMany(x => x.cities)
            .WithOne(x => x.Province)
            .HasForeignKey(x => x.provinceId)
           .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<City>()
             .HasMany(x => x.Users)
             .WithOne(x => x.City)
             .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);

        }
    }
}

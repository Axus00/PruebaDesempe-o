using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Models;

namespace Veterinaria.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {

        }

        //Models
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        //Aditional Configuration to Models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().HasKey(owner => owner.Id);
            modelBuilder.Entity<Pet>().HasKey(pet => pet.Id);
            modelBuilder.Entity<Quote>().HasKey(quote => quote.Id);
            modelBuilder.Entity<Vet>().HasKey(vet => vet.Id);
        }

    }
}
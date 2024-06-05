using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.Models;
using System.Linq;

namespace Veterinaria.Services.Pets
{
    public class PetRepository : IPetRepository
    {
        private readonly BaseContext _context;
        public PetRepository(BaseContext context)
        {
            _context = context;
        }

        public void Add(Pet pet)
        {
            //you can call Db
            _context.Pets.Add(pet);
            //Then save it
            _context.SaveChanges();
        }

        public Pet GetById(int? id)
        {
            //Call Db
            return _context.Pets.Find(id);
        }

        public IEnumerable<Pet> GetPetBirth()
        {
            //We list all pets with owners with Ur birthday exactly
            return _context.Pets.Where(p => p.DateBirth.Equals(p.DateBirth)).Include(p => p.Owner).ToList();
        }

        public IEnumerable<Owner> GetPetOwner(int id)
        {
            var PetOwner = _context.Owners.Where(o => o.Id == id).ToList();
            
            return PetOwner;
        }

        public IEnumerable<Pet> GetPets()
        {
            //Call Db in MySql
            return _context.Pets.Include(pet => pet.Owner).ToList();
        }

        public void Update(int id, Pet pet)
        {
            //Update object of Pet
            var UpdatePet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
            UpdatePet.Name = pet.Name;
            UpdatePet.Specie = pet.Specie;
            UpdatePet.Race = pet.Race;
            UpdatePet.DateBirth = pet.DateBirth;
            UpdatePet.Photo = pet.Photo;
            
            //Save the information in Db
            _context.SaveChanges();
        }
    }
}
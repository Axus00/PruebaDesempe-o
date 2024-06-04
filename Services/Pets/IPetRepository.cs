using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.Services.Pets
{
    public interface IPetRepository
    {
        IEnumerable<Pet> GetPets(); //List
        Pet GetById(int? id); //ListById
        void Add(Pet pet); //Create or Add
        void Update(int id, Pet pet); //Update
    }
}
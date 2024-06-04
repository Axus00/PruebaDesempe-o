using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.Services.Owners
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> Get(); //List
        Owner GetById(int id); //ListById
        void Add(Owner owner); //Create or Add
        void Update(int id, Owner owner); //Update
    }
}
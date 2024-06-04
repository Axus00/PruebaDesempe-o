using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.Services.Vets
{
    public interface IVetRepository
    {
        IEnumerable<Vet> GetVets(); //List
        Vet GetById(int id); //ListById
    }
}
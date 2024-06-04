using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Data;
using Veterinaria.Models;

namespace Veterinaria.Services.Vets
{
    public class VetRepository : IVetRepository
    {
        private readonly BaseContext _context;
        public VetRepository(BaseContext context)
        {
            _context = context;
        }

        public Vet GetById(int id)
        {
            //Call Db in MySql
            return _context.Vets.Find(id);
        }

        public IEnumerable<Vet> GetVets()
        {
            //Call Db in MySql
            return _context.Vets.ToList();
        }
    }
}
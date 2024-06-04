using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Data;
using Veterinaria.Models;

namespace Veterinaria.Services.Owners
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly BaseContext _context;
        public OwnerRepository(BaseContext context)
        {
            _context = context;
        }

        public void Add(Owner owner)
        {
            //Call Db to Add owner
            _context.Add(owner);
            _context.SaveChanges();
        }

        public IEnumerable<Owner> Get()
        {
            //Call Db
            return  _context.Owners.ToList();
        }

        public Owner GetById(int id)
        {
            //Call Db
            return _context.Owners.Find(id);
        }

        public void Update(int id, [FromBody] Owner owner)
        {
            var UpdateOwner = _context.Owners.FirstOrDefault(o => o.Id == id);
            UpdateOwner.Names = owner.Names;
            UpdateOwner.LastNames = owner.LastNames;
            UpdateOwner.Phone = owner.Phone;
            UpdateOwner.Address = owner.Address;
            UpdateOwner.Email = owner.Email;
            
            //Save information
            _context.SaveChanges();
        }
    }
}
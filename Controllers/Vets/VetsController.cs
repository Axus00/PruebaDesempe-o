using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
using Veterinaria.Services.Vets;

namespace Veterinaria.Controllers.Vets
{
    [ApiController]
    [Route("api/[controller]")]
    public class VetsController : ControllerBase
    {
        private readonly IVetRepository _vetRepository;
        public VetsController(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }

        //Endpoint
        [HttpGet]
        public IEnumerable<Vet> Get()
        {
            if(!ModelState.IsValid)
            {
                BadRequest();
            }

            //Call interface
            return _vetRepository.GetVets();
        
        }

        [HttpGet("{id}")]
        public Vet VetById(int id)
        {
            if(!ModelState.IsValid)
            {
                NotFound();
            }

            return _vetRepository.GetById(id); 
            
        }
    }
}
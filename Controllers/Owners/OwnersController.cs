using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
using Veterinaria.Services.Owners;

namespace Veterinaria.Controllers.Owners
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        //Endpoitns
        [HttpGet]
        public IEnumerable<Owner> Get()
        {

            //We validate that the information is correct
            if(!ModelState.IsValid)
            {
                BadRequest();
            }
            
            //We call to interface
            return _ownerRepository.Get();


        }

        [HttpGet("{id}")]
        public Owner GetById(int id)
        {

            if(!ModelState.IsValid)
            {
                StatusCode(204, $"Error: parameters icoreects");
            }

            //We call to interface
            return _ownerRepository.GetById(id);
            
            
        }

        //post
        [HttpPost]
        public IActionResult Create(Owner owner)
        {

            //We verify the action
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                //Call to interface
                _ownerRepository.Add(owner);
                return Ok("The owner has been created");
            }
            finally
            {
                Created();
            }
        }

        //Update information
        [HttpPut("{id}")]
        public IActionResult UpdateOwner(int id, Owner owner)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }


            //Call interface in file service/
            _ownerRepository.Update(id, owner);
            return Ok("The owner has been updated");
             
        }
    }
}
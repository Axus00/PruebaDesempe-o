using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Veterinaria.Models;
using Veterinaria.Services.Pets;

namespace Veterinaria.Controllers.Pets
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        public PetsController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        //endpoint
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            if(!ModelState.IsValid)
            {
                BadRequest();
            }

            try
            {
                //Call interface in file service
                return _petRepository.GetPets();
            }
            finally
            {
                //Response
                Ok("The information has been send.");
            }

        }

        //Details of a pet
        [HttpGet("{id}")]
        public Pet PetById(int id)
        {
            
            if(!ModelState.IsValid)
            {
                NotFound("The information maybe is wrong send");
            }


            try
            {
                //Call interface in file service
                return _petRepository.GetById(id);
                
            }
            finally
            {
                Ok("This is the information about of pet.");
            }
        }

        [HttpGet("{id}/owner")]
        public IEnumerable<Owner> GetOwnerPet(int id)
        {
            return _petRepository.GetPetOwner(id);
        }

        //Get pet with brithday
        [HttpGet("{date}/birthday")]
        public IEnumerable<Pet> GetPetBirth()
        {
            if(!ModelState.IsValid)
            {
                NotFound("The resquest isn't valid to response"); 
            }

            //Call interface on file services
            return _petRepository.GetPetBirth();
        }

        //Create Pet
        [HttpPost]
        public IActionResult CreatePet(Pet pet)
        {
            try
            {
                //Call interface in file Service
                _petRepository.Add(pet);
                return Ok("The pet has been created correct.");
            }
            catch
            {
                return Created();
            }
            
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult UpdatePet(int id, Pet pet)
        {
            try
            {
                //Interface
                _petRepository.Update(id, pet);
                return Ok("Has been updated the information");
            }
            catch (Exception ex)
            {
                return StatusCode(404, $"Error: {ex.Message}");
            }
        }
    }
}
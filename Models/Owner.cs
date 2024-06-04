using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Address { get; set; }

        //We verify that phone is correct
        [Required]
        [Phone]
        public string Phone { get; set; }

        [JsonIgnore]
        List<Pet>? Pets { get; set; } // connection 
    }
}
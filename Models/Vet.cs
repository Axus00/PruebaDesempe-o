using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    public class Vet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //We verify that phone is correct
        [Required]
        [Phone]
        public string Phone { get; set; }
        
        [Required]
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [JsonIgnore]
        List<Quote>? Quotes { get; set; } // connection
    }
}
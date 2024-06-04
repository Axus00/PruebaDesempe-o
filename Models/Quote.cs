using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PetId { get; set; } //Foreign Key
        public int VetId { get; set; } //Foreign Key

        public Vet Vet { get; set; } //navigation to vet

        public Pet Pet { get; set; } //navigation to pet

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
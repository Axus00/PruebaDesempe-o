using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinaria.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specie { get; set; }
        public string Race { get; set; }
        public DateOnly DateBirth { get; set; }
        public int OwnerId { get; set; } //Foreign Key
        public string Photo { get; set; }

        List<Quote>? Quotes { get; set; } // connection
        public Owner Owner { get; set; } //navigation to Owners
    }
}
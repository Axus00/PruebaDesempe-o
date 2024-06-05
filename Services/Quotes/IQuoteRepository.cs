using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinaria.Models;

namespace Veterinaria.Services.Quotes
{
    public interface IQuoteRepository
    {
        IEnumerable<Quote> GetQuotes(); //List
        IEnumerable<Quote> QuotesDate(); //endpoint medium
        IEnumerable<Quote> QuotesVet(int id); //endpoint medium
        Quote GetById(int id); //ListById
        void Add(Quote quote); //Create or Add
        void Update(int id, Quote owner); //Update
    }
}
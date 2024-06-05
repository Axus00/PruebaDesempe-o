using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.Models;

namespace Veterinaria.Services.Quotes
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly BaseContext _context;
        public QuoteRepository(BaseContext context)
        {
            _context = context;
        }

        public void Add(Quote quote)
        {
            //Call Db
            _context.Quotes.Add(quote);
            //Then we save information
            _context.SaveChanges();
        }

        public IEnumerable<Quote> GetQuotes()
        {
            //We include the navigation pet and vet
            return _context.Quotes.Include(q => q.Pet).Include(q => q.Vet).ToList();
            
        }

        public Quote GetById(int id)
        {
            return _context.Quotes.Find(id);
        }

        public void Update(int id, [FromBody] Quote quote)
        {
            
            var UpdateQuote = _context.Quotes.FirstOrDefault(quo => quo.Id == id);
            UpdateQuote.Date = quote.Date;
            UpdateQuote.Description = quote.Description;

            //Save information in Db
            _context.SaveChanges();
        }

        public IEnumerable<Quote> QuotesDate()
        {
            //We list all quote exactly of date
            return _context.Quotes.Where(q => q.Date.Equals(q.Date)).Include(q => q.Vet).Include(q => q.Pet).ToList();
            
        }

        public IEnumerable<Quote> QuotesVet(int id)
        {
            //We list all quote about exactly vet
            return _context.Quotes.Where(q => q.VetId == id).Include(q => q.Pet).ToList();
        }
    }
}
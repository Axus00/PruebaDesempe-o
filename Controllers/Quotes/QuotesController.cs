using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.Models;
using Veterinaria.Services.Quotes;

namespace Veterinaria.Controllers.Quotes
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private IQuoteRepository _quoteRepository;
        public QuotesController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        //endpoints
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            if(!ModelState.IsValid)
            {
                BadRequest();
            }

            //call file service with interface quote
            return _quoteRepository.GetQuotes();
            
        }

        [HttpGet("{id}")]
        public Quote QuoteById(int id)
        {
            if(!ModelState.IsValid)
            {  
                NotFound("The parameter isn't");
            }

            return _quoteRepository.GetById(id);
        }

        //Create quote
        [HttpPost]
        public IActionResult CreateQuote(Quote quote)
        {
            try
            {
                //call interface
                _quoteRepository.Add(quote);
                return Ok("The quote has been created.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
            
            
        }

        //Update Quote
        [HttpPut("{id}")]
        public IActionResult UpdateQuote(int id, Quote quote)
        {
            try
            {
                //get information of interface in file services
                _quoteRepository.Update(id, quote);
                return Ok("The quote has been updated");
            }
            catch
            {
                return StatusCode(203, $"The action is correct."); 
            }
        }
    }
}
using System;
using BookLoans.API.Models;
using BookLoans.API.Services.Contracts;
using BookLoans.API.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BookLoans.API.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly ILoansService _loansService;

        public LoansController(ILoansService loansService)
        {
            _loansService = loansService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var loans = _loansService.GetAll();
            return Ok(loans);
        }

        [HttpPost]
        public IActionResult LoanBook([FromBody] LoanBookRequest request)
        {
            try
            {
                _loansService.LoanBook(request);
                return Ok();
            }
            catch (BookNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
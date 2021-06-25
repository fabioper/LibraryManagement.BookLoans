using System;

namespace BookLoans.API.Services.Exceptions
{
    public class LoanNotFoundException : Exception
    {
        public LoanNotFoundException() : base("Loan not found")
        {
        }
    }
}
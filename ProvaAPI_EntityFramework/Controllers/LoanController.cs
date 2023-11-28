using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaAPI_EntityFramework.Database;
using ProvaAPI_EntityFramework.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaAPI_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : Controller
    {
        public readonly LoanRepository _loanRepository;

        public LoanController(LoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        [HttpGet("id")]
        public IActionResult GetLoanById(int idLoan)
        {
            LoanEntity loan = _loanRepository.GetLoanById(idLoan);

            if (loan == null)
                return NotFound();

            LoanModel l = MapLoanEntityToLoanModel(loan);

            return Ok(l);
        }

        [HttpGet("idBook")]
        public IActionResult GetLoanByIdBook(int idBook)
        {
            List<LoanEntity> loans = _loanRepository.GetLoansByIdBook(idBook);

            if (loans.Count == 0)
                return NotFound();

            List<LoanModel> l = loans.Select(MapLoanEntityToLoanModel).ToList();

            return Ok(l);
        }

        [HttpGet("idUser")]
        public IActionResult GetLoanByIdUser(int idUser)
        {
            List<LoanEntity> loans = _loanRepository.GetLoansByIdUser(idUser);

            if (loans.Count == 0)
                return NotFound();

            List<LoanModel> l = loans.Select(MapLoanEntityToLoanModel).ToList();

            return Ok(l);
        }

        [HttpGet("returned")]
        public IActionResult GetLoanReturned()
        {
            List<LoanEntity> loans = _loanRepository.GetLoansReturned();

            if (loans.Count == 0)
                return NotFound();

            List<LoanModel> l = loans.Select(MapLoanEntityToLoanModel).ToList();

            return Ok(l);
        }

        [HttpGet("notReturned")]
        public IActionResult GetLoanNotReturned()
        {
            List<LoanEntity> loans = _loanRepository.GetLoansNotReturned();

            if (loans.Count == 0)
                return NotFound();

            List<LoanModel> l = loans.Select(MapLoanEntityToLoanModel).ToList();

            return Ok(l);
        }

        [HttpGet("all")]
        public IActionResult AllLoans()
        {
            List<LoanEntity> loans = _loanRepository.GetAllLoans();
            List<LoanModel> l = loans.Select(MapLoanEntityToLoanModel).ToList();

            return Ok(l);
        }

        [HttpPost("add")]
        public IActionResult AddLoan(int idBook, int idUser, int day)
        {
            _loanRepository.AddLoan(idBook, idUser, day);

            return Ok();
        }

        [HttpPut("update")]
        public IActionResult UpdateLoan([FromBody] LoanEntity loan)
        {
            _loanRepository.UpdateLoan(loan);

            return Ok(loan);
        }

        [HttpPut("updateByLine")]
        public IActionResult UpdateBook(int idLoan, int idBook, int idUser, DateTime loanDate, DateTime dueDate, bool isReturned)
        {
            var loan = new LoanEntity
            {
                IdLoan = idLoan,
                IdBook = idBook,
                IdUser = idUser,
                LoanDate = loanDate,
                DueDate = dueDate,
                IsReturned = isReturned
            };

            _loanRepository.UpdateLoan(loan);

            return Ok(loan);
        }

        [HttpDelete("delete")]
        public IActionResult DeleteLoan(int idLoan)
        {
            bool result = _loanRepository.DeleteLoan(idLoan);

            if (!result)
                return NotFound();

            return Ok();
        }

        private LoanModel MapLoanEntityToLoanModel(LoanEntity loan)
        {
            return new LoanModel
            {
                IdLoan = loan.IdLoan,
                IdBook = loan.IdBook,
                IdUser = loan.IdUser,
                LoanDate = loan.LoanDate,
                DueDate = loan.DueDate,
                IsReturned = loan.IsReturned
            };
        }
    }
}


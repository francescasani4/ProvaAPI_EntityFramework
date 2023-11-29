using System;

namespace ProvaAPI_EntityFramework.Database
{
	/*public class LoanRepository
	{
        private readonly FakeDatabase _fakeDatabase;

        public LoanRepository()
		{
			_fakeDatabase = FakeDatabaseSingleton.Instance;
		}

        public List<LoanEntity> GetAllLoans()
        {
            return _fakeDatabase.Loans.ToList();
        }

        public LoanEntity GetLoanById(int idLoan)
        {
            
            var loan = _fakeDatabase.Loans.FirstOrDefault(l => l.IdLoan == idLoan);

            return loan;
        }

        public List<LoanEntity> GetLoansByIdBook(int idBook)
        {
            var loan = _fakeDatabase.Loans.Where(l => l.IdBook == idBook).ToList();

            return loan;
        }

        public List<LoanEntity> GetLoansByIdUser(int idUser)
        {
            var loan = _fakeDatabase.Loans.Where(l => l.IdUser == idUser).ToList();

            return loan;
        }

        public List<LoanEntity> GetLoansReturned()
        {
            var loan = _fakeDatabase.Loans.Where(l => l.IsReturned == true).ToList();

            return loan;
        }

        public List<LoanEntity> GetLoansNotReturned()
        {
            var loan = _fakeDatabase.Loans.Where(l => l.IsReturned == false).ToList();

            return loan;
        }

        public void AddLoan(int idBook, int idUser, int loanDays)
        {
            _fakeDatabase.AddLoan(idBook, idUser, loanDays);
        }

        public bool DeleteLoan(int idLoan)
        {
            var loan = _fakeDatabase.Loans.FirstOrDefault(l => l.IdLoan == idLoan);
            bool flag = false;

            if(loan != null)
            {
                _fakeDatabase.Loans.Remove(loan);
                flag = true;
            }

            return flag;
        }
    
        public void UpdateLoan(LoanEntity loan)
        {
            var existingLoan = _fakeDatabase.Loans.FirstOrDefault(l => l.IdLoan == loan.IdLoan);

            if (existingLoan != null)
            {
                existingLoan.IdBook = loan.IdBook;
                existingLoan.IdUser = loan.IdUser;
                existingLoan.LoanDate = loan.LoanDate;
                existingLoan.DueDate = loan.DueDate;
                existingLoan.IsReturned = loan.IsReturned;
            }
        }
    }*/
}


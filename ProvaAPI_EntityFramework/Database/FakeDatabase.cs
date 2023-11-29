using System;
namespace ProvaAPI_EntityFramework.Database
{
    public class UserEntity
    {
        public int IdUser { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }

    public class BookEntity
    {
        public int IdBook { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public int? IdUser { get; set; }
    }

    /*public class LoanEntity
    {
        public int IdLoan { get; set; }

        public int IdBook { get; set; }

        public int IdUser { get; set; }

        public DateTime LoanDate { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }

    }*/

    public class FakeDatabaseSingleton
    {
        private static readonly Lazy<FakeDatabase> instance = new Lazy<FakeDatabase>(() => new FakeDatabase());

        public static FakeDatabase Instance => instance.Value;
    }

    public class FakeDatabase
    {
        private static int GlobalIdUser = 0;
        private static int GlobalIdBook = 0;
        /*private static int GlobalIdLoan = 0;*/

        public List<UserEntity> Users { get; set; }
        public List<BookEntity> Books { get; set; }
        /*public List<LoanEntity> Loans { get; set; }*/

        public FakeDatabase()
        {
            Users = new List<UserEntity>();
            Books = new List<BookEntity>();
            /*Loans = new List<LoanEntity>();*/

            AddUserInternal(new UserEntity
            {
                UserName = "UserName1",
                Password = "Password1",
                Name = "Name1",
                Surname = "Surname1"
            });

            AddUserInternal(new UserEntity
            {
                UserName = "UserName2",
                Password = "Password2",
                Name = "Name2",
                Surname = "Surname2"
            });

            AddUserInternal(new UserEntity
            {
                UserName = "UserName3",
                Password = "Password3",
                Name = "Name3",
                Surname = "Surname3"
            });

            AddUserInternal(new UserEntity
            {
                UserName = "UserName4",
                Password = "Password4",
                Name = "Name4",
                Surname = "Surname4"
            });

            AddBookInternal(new BookEntity
            {
                Title = "Title1",
                Author = "Author1",
                PublicationDate = new DateTime(2020, 1, 1),
                IdUser = null
            }) ;

            AddBookInternal(new BookEntity
            {
                Title = "Title2",
                Author = "Author2",
                PublicationDate = new DateTime(2018, 4, 4),
                IdUser = null
            });

            AddBookInternal(new BookEntity
            {
                Title = "Title3",
                Author = "Author3",
                PublicationDate = new DateTime(2000, 12, 4),
                IdUser = null
            });

            /*AddLoanInternal(new LoanEntity
            {
                IdBook = 1,
                IdUser = 2,
                LoanDate = new DateTime(2023, 11, 23),
                DueDate = new DateTime(2023, 12, 23),
                IsReturned = false
            });

            AddLoanInternal(new LoanEntity
            {
                IdBook = 3,
                IdUser = 4,
                LoanDate = new DateTime(2023, 10, 20),
                DueDate = new DateTime(2024, 1, 20),
                IsReturned = false
            });*/
        }

        public void AddUser(UserEntity user)
        {
            AddUserInternal(user);
        }

        private void AddUserInternal(UserEntity user)
        {
            GlobalIdUser++;

            user.IdUser = GlobalIdUser;

            Users.Add(user);
        }

        public void AddBook(BookEntity book)
        {
            AddBookInternal(book);
        }

        private void AddBookInternal(BookEntity book)
        {
            GlobalIdBook++;

            book.IdBook = GlobalIdBook;

            Books.Add(book);
        }

        /*public void AddLoan(int idBook, int idUser, int loanDays)
        {

            BookEntity book = Books.FirstOrDefault(b => b.IdBook == idBook);
            UserEntity user = Users.FirstOrDefault(u => u.IdUser == idUser);

            if (book == null || user == null)
                throw new ArgumentException("Id Libro o Id Utente non validi!");

            DateTime loanDate = DateTime.Now;
            DateTime dueDate = loanDate.AddDays(loanDays);

            LoanEntity loan = new LoanEntity
            {
                IdBook = idBook,
                IdUser = idUser,
                LoanDate = loanDate,
                DueDate = dueDate,
                IsReturned = false
            };

            AddLoanInternal(loan);
        }

        public void AddLoanInternal(LoanEntity loan)
        {
            GlobalIdLoan++;

            loan.IdLoan = GlobalIdLoan;

            Loans.Add(loan);
        }*/
    }
}


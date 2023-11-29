using System;
using Microsoft.EntityFrameworkCore;

namespace ProvaAPI_EntityFramework.Database
{
	public class BookRepository
	{
        // private readonly MyDbContext _dbContext;
        private readonly FakeDatabase _fakeDatabase;

        public BookRepository()
        {
            // _dbContext = dbContext;
            _fakeDatabase = FakeDatabaseSingleton.Instance;
        }

        public List<BookEntity> GetAllBooks()
        {
            // return _dbContext.Books.ToList();
            return _fakeDatabase.Books.ToList();
        }

        public BookEntity GetBookById(int idBook)
        {
            // var book = _dbContext.Books.FirstOrDefault(b => b.IdBook == idBook);
            var book = _fakeDatabase.Books.FirstOrDefault(b => b.IdBook == idBook);

            return book;
        }

        public List<BookEntity> GetBooksByTitle(string title)
        {
            //var books = _dbContext.Books.Where(b => b.Title == title).ToList();
            var books = _fakeDatabase.Books.Where(b => b.Title == title).ToList();

            return books;
        }

        public List<BookEntity> GetBooksByAuthor(string author)
        {
            // var books = _dbContext.Books.Where(b => b.Author == author).ToList();
            var books = _fakeDatabase.Books.Where(b => b.Author == author).ToList();

            return books;
        }

        public List<BookEntity> GetBooksByTitleAndAuthor(string title, string author)
        {
            var books = _fakeDatabase.Books.Where(b => b.Title == title && b.Author == author).ToList();

            return books;
        }

        public List<BookEntity> GetBooksByPublicationDate(DateTime publicationDate)
        {
            // var books = _dbContext.Books.Where(b => b.PublicationDate == publicationDate).ToList();
            var books = _fakeDatabase.Books.Where(b => b.PublicationDate == publicationDate).ToList();

            return books;
        }

        public void AddBook(BookEntity book)
        {
            // _dbContext.Books.Add(book);
            // _dbContext.SaveChanges();
            _fakeDatabase.AddBook(book);
        }

        public bool DeleteBook(int idBook)
        {
            // var book = _dbContext.Books.FirstOrDefault(b => b.IdBook == idBook);
            var book = _fakeDatabase.Books.FirstOrDefault(b => b.IdBook == idBook);
            bool flag = false;

            if (book != null)
            {
                // _dbContext.Books.Remove(book);
                // _dbContext.SaveChanges();
                _fakeDatabase.Books.Remove(book);
                flag = true;
            }

            return flag;
        }

        public bool UpdateBook(BookEntity book)
        {
            // var existingBook = _dbContext.Books.FirstOrDefault(b => b.IdBook == book.IdBook);
            var existingBook = _fakeDatabase.Books.FirstOrDefault(b => b.IdBook == book.IdBook);
            bool flag = false;

            if (existingBook != null) //&& existingUser != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PublicationDate = book.PublicationDate;

                if(book.IdUser != null)
                {
                    var existingUser = _fakeDatabase.Users.FirstOrDefault(u => u.IdUser == book.IdUser); //controllo se l'id dell'utente esiste

                    if (existingUser != null)
                        flag = true;
                }
                    
                existingBook.IdUser = book.IdUser;
                flag = true;

                //_dbContext.SaveChanges();
            }

            return flag;
        }
    }
}


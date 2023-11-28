using System;
using Microsoft.EntityFrameworkCore;

namespace ProvaAPI_EntityFramework.Database
{
	public class BookRepository
	{
        private readonly MyDbContext _dbContext;

        public BookRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BookEntity> GetAllBooks()
        {
            return _dbContext.Books.ToList();
        }

        public BookEntity GetUsersById(int idBook)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.IdBook == idBook);

            return book;
        }

        public List<BookEntity> GetUsersByTitle(string title)
        {
            var books = _dbContext.Books.Where(b => b.Title == title).ToList();

            return books;
        }

        public List<BookEntity> GetUsersByAuthor(string author)
        {
            var books = _dbContext.Books.Where(b => b.Author == author).ToList();

            return books;
        }

        public void AddBook(BookEntity book)
        {
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

        public void DeleteBook(int idBook)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.IdBook == idBook);

            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateBook(BookEntity book)
        {
            var existingBook = _dbContext.Books.FirstOrDefault(b => b.IdBook == book.IdBook);

            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.PublicationDate = book.PublicationDate;

                _dbContext.SaveChanges();
            }
        }
    }
}


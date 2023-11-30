using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProvaAPI_EntityFramework.Database;
using ProvaAPI_EntityFramework.Model;
using ProvaAPI_EntityFramework.Model.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProvaAPI_EntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly BookRepository _bookRepository;

        public BooksController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        [Route("{idBook}")]
        public IActionResult GetBookById(int idBook)
        {
            BookEntity book = _bookRepository.GetBookById(idBook);

            if (book == null)
                return NotFound();

            BookModel b = MapBookEntityToBookModel(book);

            return Ok(b);
        }

        /*[HttpGet("title")]
        public IActionResult GetBookByTitle(string title)
        {
            List<BookEntity> books = _bookRepository.GetBooksByTitle(title);

            if (books.Count == 0)
                return NotFound();

            List<BookModel> b = books.Select(MapBookEntityToBookModel).ToList();

            return Ok(b);
        }*/

        /*[HttpGet("author")]
        public IActionResult GetBookByAuthor(string author)
        {
            List<BookEntity> books = _bookRepository.GetBooksByAuthor(author);
            

            if (books.Count == 0)
                return NotFound();

            List<BookModel> b = books.Select(MapBookEntityToBookModel).ToList();

            return Ok(b);
        }*/

        /*[HttpGet("publicationDate")]
        public IActionResult GetBookByPublicationDate(DateTime publicationDate)
        {
            List<BookEntity> books = _bookRepository.GetBooksByPublicationDate(publicationDate);


            if (books.Count == 0)
                return NotFound();

            List<BookModel> b = books.Select(MapBookEntityToBookModel).ToList();

            return Ok(b);
        }*/

        [HttpGet]
        public IActionResult AllBooks(string? title, string? author)
        {
            if(title == null && author == null)
            {
                List<BookEntity> allBooks = _bookRepository.GetAllBooks();
                List<BookModel> bk = allBooks.Select(MapBookEntityToBookModel).ToList();

                return Ok(bk);
            }
            else if(title != null && author == null)
            {
                List<BookEntity> booksT = _bookRepository.GetBooksByTitle(title);

                if (booksT.Count == 0)
                    return NotFound();

                List<BookModel> bk = booksT.Select(MapBookEntityToBookModel).ToList();

                return Ok(bk);
            }
            else if(title == null && author != null)
            {
                List<BookEntity> booksA = _bookRepository.GetBooksByAuthor(author);


                if (booksA.Count == 0)
                    return NotFound();

                List<BookModel> bk = booksA.Select(MapBookEntityToBookModel).ToList();

                return Ok(bk);
            }

            List<BookEntity> books = _bookRepository.GetBooksByTitleAndAuthor(title, author);

            if (books.Count == 0)
                return NotFound();

            List<BookModel> b = books.Select(MapBookEntityToBookModel).ToList();

            return Ok(b);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookRequest bookRequest)
        {
            var book = new BookEntity
            {
                Title = bookRequest.Title,
                Author = bookRequest.Author,
                PublicationDate = bookRequest.PublicationDate,
                IdUser = null
            };

            _bookRepository.AddBook(book);

            return Ok();
        }

        /*[HttpPost("addByLine")]
        public IActionResult AddBook(string title, string author, DateTime publicationDate)
        {
            var book = new BookEntity
            {
                Title = title,
                Author = author,
                PublicationDate = publicationDate,
                IdUser = null
            };

            _bookRepository.AddBook(book);

            return Ok(book);
        }*/

        [HttpPut]
        [Route("{idBook}")]
        public IActionResult UpdateBook([FromBody] BookEntity book)
        {
            bool result = _bookRepository.UpdateBook(book);

            return Ok(book);
        }

        /*[HttpPut("updateByLine")]
        public IActionResult UpdateBook(int idBook, string title, string author, DateTime publicationDate)
        {
            var book = new BookEntity
            {
                IdBook = idBook,
                Title = title,
                Author = author,
                PublicationDate = publicationDate
            };

            _bookRepository.UpdateBook(book);

            return Ok(book);
        }*/

        [HttpDelete]
        [Route("{idBook}")]
        public IActionResult DeleteBook([FromRoute] int idBook)
        {
            bool result = _bookRepository.DeleteBook(idBook);

            if (!result)
                return NotFound();

            return Ok();
        }

        private BookModel MapBookEntityToBookModel(BookEntity book)
        {
            return new BookModel
            {
                IdBook = book.IdBook,
                Title = book.Title,
                Author = book.Author,
                PublicationDate = book.PublicationDate,
                IdUser = book.IdUser
            };
        }
    }
}


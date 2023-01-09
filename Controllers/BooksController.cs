namespace BooksWebApi.Controllers
{
    using BooksWebApi.Data.ViewModels;
    using BooksWebApi.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook(BookViewModel model)
        {
            bookService.AddBook(model);

            return Ok();
        }

        [HttpGet("get-all-books")]
        public IActionResult GetBooks()
        {
            var allBooks = this.bookService.AllBooks();

            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = this.bookService.GetById(id);

            return Ok(book);
        }
    }
}

namespace BooksWebApi.Controllers
{
    using BooksWebApi.Data.ViewModels;
    using BooksWebApi.Services;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor(AuthorViewModel model)
        {
            authorService.AddAuthor(model);
            return Ok();
        }

        [HttpGet("get-author-with-books")]
        public IActionResult GetAuthorsWithBooks(int id)
        {
            var response = authorService.GetAuthorWithBooks(id);
            return Ok(response);
        }
    }
}

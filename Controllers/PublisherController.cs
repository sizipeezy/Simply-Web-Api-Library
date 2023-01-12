namespace BooksWebApi.Controllers
{
    using BooksWebApi.Data.ViewModels;
    using BooksWebApi.Services;
    using Microsoft.AspNetCore.Mvc;


    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddAuthor(PublisherViewModel model)
        {
            publisherService.AddPublisher(model);
            return Ok();
        }

        [HttpGet("publisher-with-books-authors/{id}")]
        public IActionResult GetPublisher(int id)
        {
            var response = this.publisherService.GetPublisherData(id);
            return Ok(response);
        }
    }
}

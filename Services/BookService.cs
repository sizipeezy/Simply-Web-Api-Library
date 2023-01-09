namespace BooksWebApi.Services
{
    using BooksWebApi.Data;
    using BooksWebApi.Data.Models;
    using BooksWebApi.Data.ViewModels;


    public class BookService : IBookService
    {
        private readonly AppDbContext data;

        public BookService(AppDbContext data)
        {
            this.data = data;
        }

        public void AddBook(BookViewModel model)
        {
            var book = new Book()
            {
                Title = model.Title,
                Description = model.Description,
                IsRead = model.IsRead,
                DateRead = model.IsRead ? model.DateRead.Value : null,
                CoverUrl = model.CoverUrl,
                Rate = model.IsRead ? model.Rate.Value : null,
                Genre = model.Genre,
                Author = model.Author,
                DateAdded = DateTime.UtcNow,

            };

            data.Books.Add(book);
            data.SaveChanges();
        }
    }
}

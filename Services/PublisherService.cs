namespace BooksWebApi.Services
{
    using BooksWebApi.Data;
    using BooksWebApi.Data.Models;
    using BooksWebApi.Data.ViewModels;


    public class PublisherService : IPublisherService
    {
        private AppDbContext data;

        public PublisherService(AppDbContext data)
        {
            this.data = data;
        }

        public void AddPublisher(PublisherViewModel model)
        {
            var publisher = new Publisher()
            {
                Name = model.Name,
            };

            this.data.Publishers.Add(publisher);

            this.data.SaveChanges();
        }

        public PublisherWithBooksAndAuthors GetPublisherData(int id)
        {
            var publisher = this.data.Publishers.Where(x => x.Id == id)
                .Select(x => new PublisherWithBooksAndAuthors
                {
                    Name = x.Name,
                    BookAuthors = x.Books.Select(x => new BookAuthorViewModel
                    {
                        BookName = x.Title,
                        BookAuthors = x.BookAuthors.Select(x => x.Author.Name).ToList()
                    }).ToList()
                }).FirstOrDefault();

            return publisher;
        }
    }
}

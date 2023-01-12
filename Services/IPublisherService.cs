namespace BooksWebApi.Services
{
    using BooksWebApi.Data.ViewModels;
    public interface IPublisherService
    {
        public void AddPublisher(PublisherViewModel model);

        public PublisherWithBooksAndAuthors GetPublisherData(int id);
    }
}

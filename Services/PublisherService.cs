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
    }
}

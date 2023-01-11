namespace BooksWebApi.Data
{
    using BooksWebApi.Data.Models;


    public class AppDbInitiliazer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "Harry Potter",
                        Description = "Mystic history about the movie",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 5,
                        Genre = "Fantasy",
                        CoverUrl = "https..",
                        DateAdded = DateTime.Now,
                        PublisherId = 2,

                    }, new Book()
                    {
                        Title = "Harry Potter 2",
                        Description = "Mystic history about the movie",
                        IsRead = false,
                        Genre = "Fantasy",
                        CoverUrl = "https..",
                        DateAdded = DateTime.Now,
                        PublisherId = 2,

                    }, new Book()
                    {
                        Title = "Harry Potter 3",
                        Description = "Mystic history about the movie",
                        IsRead = false,
                        Genre = "Fantasy",
                        CoverUrl = "https..",
                        DateAdded = DateTime.Now,
                       PublisherId = 1,
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}

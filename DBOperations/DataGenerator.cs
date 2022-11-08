using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange(
                    new Author
                    {
                        FirstName = "Eric",
                        LastName = "Ries",
                        Birthday = new DateTime(1978,09,22),
                        
                    },
                    new Author
                    {
                        FirstName = "Charlotte Perkins",
                        LastName = "Gilman",
                        Birthday = new DateTime(1860,06,03),
                        
                    },
                    new Author
                    {
                        FirstName = "Frank",
                        LastName = "Herbert",
                        Birthday = new DateTime(1920,10,08),
                        
                    }
                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                     new Genre
                    {
                        Name = "Science Fiction"
                    },
                     new Genre
                    {
                        Name = "Romance"
                    }

                );
                
                
                context.Books.AddRange
                (
                    new Book 
                    {
                        //Id= 1, 
                        Title="Lean Statrup",
                        GenreId=1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001,06,12),
                        AuthorId=1
                        
                    },
                    new Book 
                    {
                        //Id= 2, 
                        Title="Herland",
                        GenreId=2,
                        PageCount = 250,
                        PublishDate = new DateTime(2010,05,23),
                        AuthorId=2
                    },
                    new Book 
                    {
                        //Id= 3, 
                        Title="Dune",
                        GenreId=2,
                        PageCount = 540,
                        PublishDate = new DateTime(2001,12,21),
                        AuthorId=3
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
using AutoMapper;
using WebApi.Application.GenreOperations.Queries;
using WebApi.BookOperations.GetAuthorDetail;
using WebApi.BookOperations.GetBookDetail;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;
using static WebApi.AuthorOperations.CreateAuthor.CreateAuthorCommand;
using static WebApi.BookOperations.CreateBook.CreateBookCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
   {
       public MappingProfile()
       {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,BookDetailViewModel>().ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=> src.Genre.Name))
            .ForMember(dest=> dest.Author, opt=> opt.MapFrom(src=> src.Author.FirstName + " " + src.Author.LastName));
            CreateMap<Book,BooksViewModel>()
            .ForMember(dest=> dest.Genre, opt=> opt.MapFrom(src=> src.Genre.Name))
            .ForMember(dest=> dest.Author, opt=> opt.MapFrom(src=> src.Author.FirstName + " " + src.Author.LastName));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<CreateAuthorModel,Author>();
            CreateMap<Author,AuthorsViewModel>().ForMember(dest=> dest.Book, opt=> opt.MapFrom(src=> src.Book.Title));
            CreateMap<Author,AuthorDetailViewModel>();
       }
   }
}
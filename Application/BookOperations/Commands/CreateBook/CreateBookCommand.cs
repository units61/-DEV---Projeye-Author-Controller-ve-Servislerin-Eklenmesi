using AutoMapper;
using WebApi.Common;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommand
    {
        public CreateBookModel Model {get; set;}
        private readonly BookStoreDbContext _dbcontext;
        private readonly IMapper _mapper;
        public CreateBookCommand(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbcontext.Books.SingleOrDefault(x=> x.Title == Model.Title);
           if(book is not null)
                throw new InvalidOperationException("Kitap zaten mevcut");
           if(_dbcontext.Books.Any(x=> x.Id == Model.AuthorId))
                throw new InvalidOperationException("Bir kitabın yalnızca bir yazarı olabilir...");
            
           
            book = _mapper.Map<Book>(Model);
           
            
            _dbcontext.Books.Add(book);
            _dbcontext.SaveChanges();
        }

        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
            public int AuthorId { get; set; }
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.BookOperations.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public int AuthorId {get; set;}

        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var book = _context.Authors.Where(author=> author.Id == AuthorId).SingleOrDefault(); 
            if(book is null)
                throw new InvalidOperationException("Yazar bulunamadı...");  
            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(book);
            return vm;      
        }
    }
     public class AuthorDetailViewModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string BirthDay { get; set; }
        }
}


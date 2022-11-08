using WebApi.Common;
using WebApi.DBOperations;

namespace WebApi.AuthorOperations.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId {get; set;}
        public DeleteAuthorModel Model { get; set; }
        
        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Silinecek yazar bulunamadı ...");
           if(_context.Books.Any(x=> x.Id == AuthorId))
                throw new InvalidOperationException("Yazarın kitapları mevcut olduğundan silinemez ...");
            
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }

      public class DeleteAuthorModel
    {   
       public int BookId {get; set;}
    }

}

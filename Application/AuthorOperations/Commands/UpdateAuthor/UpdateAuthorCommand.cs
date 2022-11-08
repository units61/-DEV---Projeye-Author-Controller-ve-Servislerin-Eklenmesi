

using WebApi.DBOperations;

namespace WebApi.AuthorOperations.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly BookStoreDbContext _context;
        
        public int AuthorId{get; set;}

        public UpdateAuthorModel Model{get; set;}
        
        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }

      public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);
            if(author is null)
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı...");
            
            author.FirstName = Model.FirstName != default ? Model.FirstName : author.FirstName;
            author.LastName = Model.LastName != default ? Model.LastName : author.LastName;
            

            _context.SaveChanges();
        }
    }
     public class UpdateAuthorModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            
            
        }
}
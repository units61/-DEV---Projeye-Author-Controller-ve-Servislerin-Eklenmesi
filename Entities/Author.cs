using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Author
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public DateTime Birthday {get; set;}
        public bool IsActive { get; set; } = true;
        public int BookId {get; set;}
        public Book Book {get; set;}

    }
}

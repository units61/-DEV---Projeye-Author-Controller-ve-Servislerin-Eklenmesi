using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Queries;
using WebApi.AuthorOperations.CreateAuthor;
using WebApi.AuthorOperations.DeleteAuthor;
using WebApi.AuthorOperations.UpdateAuthor;
using WebApi.BookOperations.GetAuthorDetail;
using WebApi.DBOperations;
using static WebApi.AuthorOperations.CreateAuthor.CreateAuthorCommand;



namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController : ControllerBase
    {

        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthor()
        {
           GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
           var result = query.Handle();
           return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AuthorDetailViewModel result;
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper);
            query.AuthorId = id;
            GetAuthorDetailQeuryValidator validator = new GetAuthorDetailQeuryValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();
            return Ok(result);
           
        }  

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newauthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            var author = _context.Authors.SingleOrDefault(x=> x.FirstName == newauthor.FirstName);
           
            command.Model = newauthor;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
             
            return Ok();
        }

         [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id,[FromBody] UpdateAuthorModel updateauthor)
        {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context);
            command.AuthorId = id;

            command.Model = updateauthor;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
                
            validator.ValidateAndThrow(command);
            command.Handle();
            
            return Ok();
        
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
                DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
                command.AuthorId = id;
                DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
        
            return Ok();
           
        }

    }
}
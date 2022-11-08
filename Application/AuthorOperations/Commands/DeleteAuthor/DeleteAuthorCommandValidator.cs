using FluentValidation;

namespace WebApi.AuthorOperations.DeleteAuthor
{
   public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
   {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            
            
        }
   }
}
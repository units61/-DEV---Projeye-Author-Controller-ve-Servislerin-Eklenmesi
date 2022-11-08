using FluentValidation;

namespace WebApi.AuthorOperations.CreateAuthor
{
   public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
   {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.LastName).NotEmpty().MinimumLength(4);
            RuleFor(command => command.Model.BirthDay.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
   }
}
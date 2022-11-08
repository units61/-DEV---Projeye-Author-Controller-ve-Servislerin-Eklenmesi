using FluentValidation;

namespace WebApi.BookOperations.GetAuthorDetail
{
   public class GetAuthorDetailQeuryValidator : AbstractValidator<GetAuthorDetailQuery>
   {
        public GetAuthorDetailQeuryValidator()
        {
            RuleFor(query => query.AuthorId).GreaterThan(0);
        }
   }
}
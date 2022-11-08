using FluentValidation;

namespace WebApi.BookOperations.GetBookDetail
{
   public class GetBookDetailQeuryValidator : AbstractValidator<GetBookDetailQuery>
   {
        public GetBookDetailQeuryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
   }
}
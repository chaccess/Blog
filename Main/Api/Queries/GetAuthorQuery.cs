using MediatR;

namespace Main.Api.Queries
{
    public class GetAuthorQuery : IRequest<string>
    {
        public long AuthorId { get; set; }
    }
}

using MediatR;

namespace Main.Queries
{
    public class GetAuthorQuery : IRequest<string>
    {
        public long AuthorId { get; set; }
    }
}

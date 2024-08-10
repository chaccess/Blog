using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Api.Queries
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, string>
    {
        public async Task<string> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            return "Работает";
        }
    }
}

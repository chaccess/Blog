using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Commands
{
    public class SaveRecordCommandHandler : IRequestHandler<SaveRecordCommand, bool>
    {
        public Task<bool> Handle(SaveRecordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

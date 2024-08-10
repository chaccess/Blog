using AutoMapper;
using Main.Api.Data;
using Main.Api.Models;
using MediatR;

namespace Main.Api.Commands
{
    public class SaveRecordCommandHandler(IApplicationDBRepository repository, IMapper mapper) : IRequestHandler<SaveRecordCommand, bool>
    {
        private readonly IMapper _mapper = mapper;
        private readonly IApplicationDBRepository _repository = repository;

        public async Task<bool> Handle(SaveRecordCommand request, CancellationToken cancellationToken)
        {
            var record = _mapper.Map<Record>(request);

            return await _repository.PostRecord(record);
        }
    }
}

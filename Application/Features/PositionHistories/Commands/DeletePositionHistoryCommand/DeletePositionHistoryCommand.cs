using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PositionHistories.Commands.DeletePositionHistoryCommand
{
    public class DeletePositionHistoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
    }

    public class DeletePositionHistoryCommandHandler : IRequestHandler<DeletePositionHistoryCommand, Response<int>>
    {
        private readonly IRepositoryAsync<PositionHistory> _repositoryAsync;

        public DeletePositionHistoryCommandHandler(IRepositoryAsync<PositionHistory> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeletePositionHistoryCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                await _repositoryAsync.DeleteAsync(record);
                return new Response<int>(record.Id);
            }                        
        }
    }
}

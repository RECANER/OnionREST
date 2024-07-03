using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.PositionHistories.Commands.UpdatePositionHistoryCommand
{
    public class UpdatePositionHistoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class UpdatePositionHistoryCommandHandler : IRequestHandler<UpdatePositionHistoryCommand, Response<int>>
    {
        private readonly IRepositoryAsync<PositionHistory> _repositoryAsync;

        public UpdatePositionHistoryCommandHandler(IRepositoryAsync<PositionHistory> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdatePositionHistoryCommand request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            }
            else
            {
                record.EmployeeId = request.EmployeeId;
                record.Position = request.Position;
                record.StartDate = request.StartDate;
                record.EndDate = request.EndDate;

                await _repositoryAsync.UpdateAsync(record);
                return new Response<int>(record.Id);
            }                        
        }
    }
}

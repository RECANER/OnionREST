using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.PositionHistories.Commands.CreatePositionHistoryCommand
{
    public class CreatePositionHistoryCommand : IRequest<Response<int>>
    {
        public int EmployeeId { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class CreatePositionHistoryCommandHandler : IRequestHandler<CreatePositionHistoryCommand, Response<int>>
    {
        private readonly IRepositoryAsync<PositionHistory> _repositoryAsync;

        public CreatePositionHistoryCommandHandler(IRepositoryAsync<PositionHistory> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(CreatePositionHistoryCommand request, CancellationToken cancellationToken)
        {
            var positionHistory = new PositionHistory
            {
                EmployeeId = request.EmployeeId,
                Position = request.Position,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            var data = await _repositoryAsync.AddAsync(positionHistory);

            return new Response<int>(data.Id);
        }
    }
}

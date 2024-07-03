using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PositionHistories.Queries.GetAllPositionHistories
{
    public class GetAllPositionHistoriesQuery : IRequest<PagedResponse<List<PositionHistoryDto>>>
    {
        public GetAllPositionHistoriesParameters Parameters { get; set; }
    }

    public class GetAllPositionHistoriesQueryHandler : IRequestHandler<GetAllPositionHistoriesQuery, PagedResponse<List<PositionHistoryDto>>>
    {
        private readonly IRepositoryAsync<PositionHistory> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllPositionHistoriesQueryHandler(IRepositoryAsync<PositionHistory> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<List<PositionHistoryDto>>> Handle(GetAllPositionHistoriesQuery request, CancellationToken cancellationToken)
        {
            // You should use the parameters from the request to create a specification
            // and pass it to the ListAsync method. For this example, we're not using any specification
            var records = await _repositoryAsync.ListAllAsync();
            var dtos = _mapper.Map<List<PositionHistoryDto>>(records);
            return new PagedResponse<List<PositionHistoryDto>>(dtos, request.Parameters.PageNumber, request.Parameters.PageSize);
        }
    }
}

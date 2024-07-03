using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PositionHistories.Queries.GetPositionHistoryById
{
    public class GetPositionHistoryByIdQuery : IRequest<Response<PositionHistoryDto>>
    {
        public int Id { get; set; }
    }

    public class GetPositionHistoryByIdQueryHandler : IRequestHandler<GetPositionHistoryByIdQuery, Response<PositionHistoryDto>>
    {
        private readonly IRepositoryAsync<PositionHistory> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetPositionHistoryByIdQueryHandler(IRepositoryAsync<PositionHistory> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<PositionHistoryDto>> Handle(GetPositionHistoryByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await _repositoryAsync.GetByIdAsync(request.Id);
            var dto = _mapper.Map<PositionHistoryDto>(record);
            return new Response<PositionHistoryDto>(dto);
        }
    }
}

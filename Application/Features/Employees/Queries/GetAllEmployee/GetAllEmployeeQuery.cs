using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<PagedResponse<List<EmployeeDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public int CurrentPosition { get; set; }
    }

    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, PagedResponse<List<EmployeeDto>>>
    {
        private readonly IRepositoryAsync<Employee> _repositoryAsync;
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IRepositoryAsync<Employee> repositoryAsync, IMapper mapper, IDistributedCache distributedCache)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<PagedResponse<List<EmployeeDto>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var cacheKey = $"listadoEmpleados_{request.PageSize}_{request.PageNumber}_{request.Name}_{request.CurrentPosition}";
            string serializedListadoEmpleados;
            var listadoEmpleados = new List<Employee>();

            var redisListadoEmpleados = await _distributedCache.GetAsync(cacheKey);

            if (redisListadoEmpleados != null)
            {
                serializedListadoEmpleados = Encoding.UTF8.GetString(redisListadoEmpleados);
                listadoEmpleados = JsonConvert.DeserializeObject<List<Employee>>(serializedListadoEmpleados);
            }
            else
            {
                listadoEmpleados = await _repositoryAsync.ListAsync(new PagedEmployeesSpecification(request.PageSize, request.PageNumber, request.Name, request.CurrentPosition));
                serializedListadoEmpleados = JsonConvert.SerializeObject(listadoEmpleados);
                redisListadoEmpleados = Encoding.UTF8.GetBytes(serializedListadoEmpleados);

                // Cache duration
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                await _distributedCache.SetAsync(cacheKey, redisListadoEmpleados, options);
            }

            var employeesDto = _mapper.Map<List<EmployeeDto>>(listadoEmpleados);
            return new PagedResponse<List<EmployeeDto>>(employeesDto, request.PageNumber, request.PageSize);
        }
    }
}

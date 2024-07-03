using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Employees.Commands.CreateEmployeeCommand
{
    public class CreateEmployeeCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public int CurrentPosition { get; set; }
        public decimal Salary { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Employee> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IRepositoryAsync<Employee> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var newEmployee = _mapper.Map<Employee>(request);
            var data = await _repositoryAsync.AddAsync(newEmployee);
            return new Response<int>(data.Id);
        }
    }
}

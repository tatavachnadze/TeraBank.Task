using Bank.Service.Interfaces.Services;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Queries
{
    public record GetCustomersQuery() : IRequest<IQueryable<Customer>>;

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IQueryable<Customer>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomersQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;

        }
        public async Task<IQueryable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomers();
            //await _customerService.SaveAsync(cancellationToken);
        }
    }
}

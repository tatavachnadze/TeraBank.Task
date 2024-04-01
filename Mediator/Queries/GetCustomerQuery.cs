using Infrastructure.DTO;
using MediatR;
using Bank.Service.Interfaces.Services;

namespace Mediator.Queries;

public record GetCustomerQuery(int Id) : IRequest<Customer>; // es scoria???

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
{
    private readonly ICustomerService _customerService;

    public GetCustomerQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        return await _customerService.GetCustomer(request.Id);                                              

    }
}

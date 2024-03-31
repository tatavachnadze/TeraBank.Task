using Infrastructure.DTO;
using Bank.Service.Interfaces.Repositories;
using MediatR;

namespace Mediator.Queries;

public record GetCustomerQuery(int Id) : IRequest<Customer>; // es scoria???

//public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Customer>
//{
//    private readonly ICustomerRepository _customerRepository;

//    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
//    {
//        _customerRepository = customerRepository;
//    }

    //public async Task<Customer> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    //{
    //    var customer = await _customerRepository.Query(x => x.Id == request.Id)
    //                                          .FirstAsync(cancellationToken);

    //    return new Customer
    //    {
    //        Id = customer.Id,
    //        FirstName = customer.Name,
    //        LastName = customer.LastName,
    //        Gender = customer.Gender,
    //        PersonalNumber = customer.PersonalNumber,
    //        Email = customer.Email,
    //        IsActive = customer.IsActive,
    //        User = customer.User,
    //        Accounts = customer.Accounts,
    //        CreateDate = customer.CreateDate,
    //        LastChangeDate = customer.LastChangeDate,
    //    };
    //}
//}

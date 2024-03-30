using Bank.Service.Interfaces.Repositories;
using Infrastructure.DTO;
using MediatR;


namespace Mediator.Commands;

public record AddCustomerCommand(string FirstName, string LastName, string Gender, string PersonalNumber, string Email) 
        : IRequest<Customer>;

//public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
//{
//    private readonly IUnitOfWork _unitOfWork;
//    private readonly ICustomerRepository _customerRepository;

//    public AddCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
//    {
//        _unitOfWork = unitOfWork;
       
//    }

    //public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    //{
    //    var customer = new Customer
    //    {
    //        FirstName = request.FirstName,
    //        LastName = request.LastName,
    //        Gender = request.Gender,
    //        PersonalNumber = request.PersonalNumber,
    //        Email = request.Email,          
    //        CreateDate = DateTime.Now.ToUniversalTime(),
    //    };

    //    await _unitOfWork.CustomerRepository.Insert(customer);

    //    await _unitOfWork.SaveAsync(cancellationToken);
      
    //}
}



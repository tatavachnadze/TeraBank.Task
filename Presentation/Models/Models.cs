﻿namespace TeraBank.API.Models
{
    public record SignUpModel(string Email, string Password);
    public record SignInModel(string Email, string Password);
    public record UserModel(int Id, string UserName, string Password);
    public record AccountModel(string IBAN, decimal Balance, int customerId, int cardId);
    public record CustomerModel(string FirstName, string Lastname, string PersonalNumber, string Email);
    public record CardModel(int OwnerId, int CardType, string Number, string Cvc, DateTime ExpirationDate);
    public record TransactionModel(decimal Amount, int TransactionType, int FromAccountId, int ToAccountId);
}

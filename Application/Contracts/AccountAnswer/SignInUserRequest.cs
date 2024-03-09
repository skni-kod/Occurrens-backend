namespace Application.Contracts.AccountAnswer;

public record SignInUserRequest(
    string Login,
    string Password
    );
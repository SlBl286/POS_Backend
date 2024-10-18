namespace POS.Presentation.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Username,
    string Password
);
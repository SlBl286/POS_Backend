namespace POS.Presentation.Authentication;

public record AuthenticationResponse(
    string Id,
    string FirstName,
    string LastName,
    string Username,
    string Token
);
namespace POS.Presentation.Authentication;

public record AuthenticationResponse(
    string Token,
    string RefreshToken
);
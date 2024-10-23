namespace POS.Presentation.Unit;

public record UpdateUnitRequest(
    Guid Id,
    string? Code,
    string? Name
);
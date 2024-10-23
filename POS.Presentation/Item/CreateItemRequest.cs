namespace POS.Presentation.Item;

public record CreateItemRequest(
    string Code,
    string Name,
    decimal? ImportPrice,
    decimal RetailPrice,
    decimal? WholesalePrice,
    Guid UnitId,
    string?  Avatar,
    string? Description,
    List<BarcodeRequest> Barcodes
);

public record BarcodeRequest(
    string Code
);
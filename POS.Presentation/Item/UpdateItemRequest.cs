namespace POS.Presentation.Item;

public record UpdateItemRequest(
    Guid Id,
    string? Code,
    string? Name,
    decimal? ImportPrice,
    decimal? RetailPrice,
    decimal? WholesalePrice,
    Guid? UnitId,
    string?  Avatar,
    string? Description,
    List<BarcodeRequest>? Barcodes
);


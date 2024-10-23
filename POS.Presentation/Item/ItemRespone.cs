namespace POS.Presentation.Item;

public record ItemRespone(
    string Id,
    string Code,
    string Name,
    decimal? ImportPrice,
    decimal RetailPrice,
    decimal? WholesalePrice,
    string UnitId,
    string? Avatar,
    List<BarcodeRespone> Barcodes
);

public record BarcodeRespone(
    string Code
);
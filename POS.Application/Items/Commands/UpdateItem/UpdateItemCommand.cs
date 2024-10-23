using ErrorOr;
using MediatR;
using POS.Application.Items.Commands.CreateItem;
using POS.Application.Items.Common;

namespace POS.Application.Items.Commands.UpdateItem;

public record UpdateItemCommand(
    Guid Id,
    string? Code,
    string? Name,
    decimal? ImportPrice,
    decimal? RetailPrice,
    decimal? WholesalePrice,
    Guid? UnitId,
    string? Avatar,
    string? Description,
    List<BarcodeCommand>? Barcodes
) : IRequest<ErrorOr<ItemResult>>;

using ErrorOr;
using MediatR;
using POS.Application.Items.Common;
using POS.Domain.ItemAggregate.Entities;

namespace POS.Application.Items.Commands.CreateItem;

public record CreateItemCommand(
    string Code,
    string Name,
    decimal? ImportPrice,
    decimal RetailPrice,
    decimal? WholesalePrice,
    Guid UnitId,
    string? Avatar,
    string? Description,
    List<BarcodeCommand> Barcodes
) : IRequest<ErrorOr<ItemResult>>;

public record BarcodeCommand(
    string Code
);
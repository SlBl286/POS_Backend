using ErrorOr;
using MediatR;
using POS.Application.Units.Common;

namespace POS.Application.Units.Commands.UpdateUnit;

public record UpdateUnitCommand(
    Guid Id,
    string? Code,
    string? Name
) : IRequest<ErrorOr<UnitResult>>;
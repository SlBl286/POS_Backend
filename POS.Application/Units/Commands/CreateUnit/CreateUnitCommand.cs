using ErrorOr;
using MediatR;
using POS.Application.Units.Common;

namespace POS.Application.Units.Commands.CreateUnit;

public record CreateUnitCommand(
    string Code,
    string Name
) : IRequest<ErrorOr<UnitResult>>;
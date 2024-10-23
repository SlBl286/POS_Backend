using ErrorOr;
using MediatR;

namespace POS.Application.Units.Commands.DeleteUnits;

public record DeleteUnitsCommand(
    List<Guid> Ids
) : IRequest<ErrorOr<int>>;
using ErrorOr;
using MediatR;
using POS.Application.Units.Common;

namespace POS.Application.Units.Queries.GetUnit;

public record GetUnitQuery(
    Guid Id
) : IRequest<ErrorOr<UnitResult>>;
using ErrorOr;
using MediatR;
using POS.Application.Units.Common;

namespace POS.Application.Units.Queries.GetListUnit;

public record GetListUnitQuery(
    string? Keyword
) : IRequest<ErrorOr<List<UnitResult>>>;
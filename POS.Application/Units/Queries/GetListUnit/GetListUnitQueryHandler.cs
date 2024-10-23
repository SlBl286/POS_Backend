using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Units.Common;
using POS.Domain.Common.Errors;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Application.Units.Queries.GetListUnit;

public class GetListUnitQueryHandler : IRequestHandler<GetListUnitQuery, ErrorOr<List<UnitResult>>>
{
    private readonly IUnitRepository _unitRepository;

    public GetListUnitQueryHandler(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<ErrorOr<List<UnitResult>>> Handle(GetListUnitQuery query, CancellationToken cancellationToken)
    {
        var units = await _unitRepository.GetList();
        if (units is null)
        {
            return Errors.Unit.NotExsits;
        }
        return units.ConvertAll(u => new UnitResult(u)).ToList();
    }
}
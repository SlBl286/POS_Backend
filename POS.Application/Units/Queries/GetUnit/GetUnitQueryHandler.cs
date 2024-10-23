using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Units.Common;
using POS.Domain.Common.Errors;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Application.Units.Queries.GetUnit;

public class UpdateUnitCommandHandler : IRequestHandler<GetUnitQuery, ErrorOr<UnitResult>>
{
    private readonly IUnitRepository _unitRepository;

    public UpdateUnitCommandHandler(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<ErrorOr<UnitResult>> Handle(GetUnitQuery query, CancellationToken cancellationToken)
    {
        var unit = await _unitRepository.GetById(UnitId.Create(query.Id));
        if (unit is null)
        {
            return Errors.ItemCategory.NotExsits;
        }
        return new UnitResult(unit);
    }
}
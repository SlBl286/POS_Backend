using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Units.Common;
using POS.Domain.Common.Errors;
using POS.Domain.UnitAggregate;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Application.Units.Commands.UpdateUnit;

public class UpdateUnitCommandHandler : IRequestHandler<UpdateUnitCommand, ErrorOr<UnitResult>>
{
    private readonly IUnitRepository _unitRepository;

    public UpdateUnitCommandHandler(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<ErrorOr<UnitResult>> Handle(UpdateUnitCommand command, CancellationToken cancellationToken)
    {
        var unit = await _unitRepository.GetById(UnitId.Create(command.Id));
        if (unit is null)
        {
            return Errors.ItemCategory.NotExsits;
        }
        var unitUpdated = Domain.UnitAggregate.Unit.Create(
            UnitId.Create(command.Id),
            command.Code ?? unit.Code,
            command.Name ?? unit.Name,
            createdAt: unit.CreatedAt);
        await _unitRepository.Update(unitUpdated);
        return new UnitResult(unit);
    }
}
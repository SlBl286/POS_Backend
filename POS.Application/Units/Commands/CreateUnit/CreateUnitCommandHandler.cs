using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Units.Common;
using POS.Domain.Common.Errors;
using POS.Domain.UnitAggregate;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Application.Units.Commands.CreateUnit;

public class CreateUnitCommandHandler : IRequestHandler<CreateUnitCommand, ErrorOr<UnitResult>>
{
    private readonly IUnitRepository _unitRepository;

    public CreateUnitCommandHandler(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<ErrorOr<UnitResult>> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
    {
        if(await _unitRepository.ExistsAsync(request.Code)){
            return Errors.Unit.DuplicateCode;
        }
        var unit = Domain.UnitAggregate.Unit.Create(UnitId.CreateUnique(),request.Code,request.Name);
        await _unitRepository.Add(unit);

        return new UnitResult(unit);
    }
}
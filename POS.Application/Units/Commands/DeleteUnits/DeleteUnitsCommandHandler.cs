using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Domain.UnitAggregate.ValueObjects;

namespace POS.Application.Units.Commands.DeleteUnits;

public sealed class DeleteUnitsCommandHandler : IRequestHandler<DeleteUnitsCommand,ErrorOr<int>>
{
    private readonly IUnitRepository _unitRepository;

    public DeleteUnitsCommandHandler(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task<ErrorOr<int>> Handle(DeleteUnitsCommand command, CancellationToken cancellationToken)
    {
       await _unitRepository.Delete(command.Ids.ConvertAll(id => UnitId.Create(id)));

       return 0;
    }
}
using ErrorOr;
using MediatR;
using POS.Application.Common.Interfaces.Persistence;
using POS.Application.Items.Common;

namespace POS.Application.Items.Commands.Create;

public class CreateCommandHandler : IRequestHandler<CreateCommand, ErrorOr<ItemResult>>
{
    private readonly IItemRepository _itemRepository;
    public CreateCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public Task<ErrorOr<ItemResult>> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
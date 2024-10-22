using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Authentication.Commands.Register;
using POS.Application.Authentication.Common;
using POS.Application.Authentication.Queries.Login;
using POS.Application.Items.Commands.Create;
using POS.Application.Items.Common;
using POS.Presentation.Authentication;
using POS.Presentation.Item;

namespace POS.WebApi.Controllers;

[Route("item")]
public class ItemController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ItemController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    /// <summary>
    /// Create item
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateRequest request)
    {
        var command = _mapper.Map<CreateCommand>(request);
        ErrorOr<ItemResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors: errors)
        );
    }


    [HttpPost("update")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);
        return authResult.Match(
           authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
           errors => Problem(errors)
       );
    }
}
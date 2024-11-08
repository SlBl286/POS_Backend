using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Authentication.Commands.Register;
using POS.Application.Authentication.Common;
using POS.Application.Items.Commands.CreateItem;
using POS.Application.Items.Commands.UpdateItem;
using POS.Application.Items.Common;
using POS.Application.Items.Queries.GetItem;
using POS.Application.Items.Queries.GetListItem;
using POS.Application.Users.Common;
using POS.Application.Users.Queries.GetUser;
using POS.Presentation.Authentication;
using POS.Presentation.Item;
using POS.Presentation.User;

namespace POS.WebApi.Controllers;

[Route("")]
public class UserController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UserController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpGet("Current")]
    public async Task<IActionResult> GetUserInfor()
    {
        var traceId = HttpContext?.TraceIdentifier;
        var userId = Guid.Parse(GetCurrentUserId());
        var query = _mapper.Map<GetUserQuery>(userId);
        ErrorOr<UserResult> userResult = await _mediator.Send(query);
        return userResult.Match(
           userResult => Ok(_mapper.Map<UserResponse>(userResult)),
           errors => Problem(errors)
       );
    }

}

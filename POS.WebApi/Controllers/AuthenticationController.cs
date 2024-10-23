using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Authentication.Commands.Register;
using POS.Application.Authentication.Common;
using POS.Application.Authentication.Queries.Login;
using POS.Presentation.Authentication;
using LoginRequest = POS.Presentation.Authentication.LoginRequest;
using RegisterRequest = POS.Presentation.Authentication.RegisterRequest;

namespace POS.WebApi.Controllers;

[Route("")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors: errors)
        );
    }


    [HttpPost("login")]
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
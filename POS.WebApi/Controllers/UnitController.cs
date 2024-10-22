using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Units.Commands.CreateUnit;
using POS.Presentation.Unit;

namespace POS.WebApi.Controllers;

[Route("Unit")]
public sealed class UnitController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;
    public UnitController(ISender mediatr, IMapper mapper)
    {
        _mediatr = mediatr;
        _mapper = mapper;
    }

    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] CreateUnitRequest request)
    {
        var command = _mapper.Map<CreateUnitCommand>(request);
        var unitResult = await _mediatr.Send(command);

        return unitResult.Match(
            unitResult => Ok(),
            errors => Problem(errors: errors)
        );

    }
}
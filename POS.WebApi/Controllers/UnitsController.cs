using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Units.Commands.CreateUnit;
using POS.Application.Units.Commands.DeleteUnits;
using POS.Application.Units.Commands.UpdateUnit;
using POS.Application.Units.Queries.GetListUnit;
using POS.Application.Units.Queries.GetUnit;
using POS.Presentation.ItemCategory;
using POS.Presentation.Unit;

namespace POS.WebApi.Controllers;

[Route("Units")]
public sealed class UnitsController : ApiController
{
    private readonly ISender _mediatr;
    private readonly IMapper _mapper;
    public UnitsController(ISender mediatr, IMapper mapper)
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
            unitResult => Ok(_mapper.Map<UnitResponse>(unitResult)),
            errors => Problem(errors: errors)
        );

    }
    [HttpPut("")]
    public async Task<IActionResult> Update([FromBody] UpdateUnitRequest request)
    {
        var command = _mapper.Map<UpdateUnitCommand>(request);
        var unitResult = await _mediatr.Send(command);

        return unitResult.Match(
            unitResult => Ok(_mapper.Map<UnitResponse>(unitResult)),
            errors => Problem(errors: errors)
        );

    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var query = _mapper.Map<GetUnitQuery>(id);
        var unitResult = await _mediatr.Send(query);

        return unitResult.Match(
            unitResult => Ok(_mapper.Map<UnitResponse>(unitResult)),
            errors => Problem(errors: errors)
        );

    }
    [HttpGet("")]
    public async Task<IActionResult> Get([FromQuery] GetListUnitRequest request)
    {
        var query = _mapper.Map<GetListUnitQuery>(request);
        var unitsResult = await _mediatr.Send(query);

        return unitsResult.Match(
            unitsResult => Ok(unitsResult.ConvertAll(u => _mapper.Map<UnitResponse>(u))),
            errors => Problem(errors: errors)
        );

    }

    [HttpDelete("")]
    public async Task<IActionResult> DeleteRange([FromBody] List<Guid> ids)
    {
        var query = _mapper.Map<DeleteUnitsCommand>(ids);
        ErrorOr<int> deleteResult = await _mediatr.Send(query);
        return deleteResult.Match(
           deleteResult => Ok(deleteResult),
           errors => Problem(errors)
       );
    }
}
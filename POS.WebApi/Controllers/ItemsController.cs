using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Authentication.Commands.Register;
using POS.Application.Authentication.Common;
using POS.Application.Authentication.Queries.Login;
using POS.Application.Items.Commands.CreateItem;
using POS.Application.Items.Commands.UpdateItem;
using POS.Application.Items.Common;
using POS.Application.Items.Queries.GetItem;
using POS.Application.Items.Queries.GetListItem;
using POS.Presentation.Authentication;
using POS.Presentation.Item;

namespace POS.WebApi.Controllers;

[Route("Items")]
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
    [HttpPost("")]
    public async Task<IActionResult> Create(CreateItemRequest request)
    {
        var command = _mapper.Map<CreateItemCommand>(request);
        ErrorOr<ItemResult> itemResult = await _mediator.Send(command);

        return itemResult.Match(
            itemResult => Ok(_mapper.Map<ItemRespone>(itemResult)),
            errors => Problem(errors: errors)
        );
    }


    [HttpPut("")]
    public async Task<IActionResult> Update(UpdateItemRequest request)
    {
        var traceId =  HttpContext?.TraceIdentifier;
        var command = _mapper.Map<UpdateItemCommand>(request);
        ErrorOr<ItemResult> itemResult = await _mediator.Send(command);
        return itemResult.Match(
           itemResult => Ok(_mapper.Map<ItemRespone>(itemResult)),
           errors => Problem(errors)
       );
    }

    [HttpGet("")]
    public async Task<IActionResult> GetList([FromQuery]GetListItemRequest request)
    {
        var traceId =  HttpContext?.TraceIdentifier;
        var query = _mapper.Map<GetListItemQuery>(request);
        var itemsResult = await _mediator.Send(query);
        return itemsResult.Match(
           itemsResult => Ok(),
           errors => Problem(errors)
       );
    }
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var traceId =  HttpContext?.TraceIdentifier;
        var query = _mapper.Map<GetItemQuery>(id);
        var itemResult = await _mediator.Send(query);
        return itemResult.Match(
           itemResult => Ok(_mapper.Map<ItemRespone>(itemResult)),
           errors => Problem(errors)
       );
    }
}

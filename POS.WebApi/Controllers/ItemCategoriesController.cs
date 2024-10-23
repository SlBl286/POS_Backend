using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using POS.Application.ItemCategorys.Commands.CreateItemCategory;
using POS.Application.ItemCategorys.Commands.DeleteItemCategory;
using POS.Application.ItemCategorys.Commands.PatchItemCategory;
using POS.Application.ItemCategorys.Commands.PutItemCategory;
using POS.Application.ItemCategorys.Common;
using POS.Application.ItemCategorys.Queries.GetItemCategory;
using POS.Application.ItemCategorys.Queries.GetListItemCategory;
using POS.Presentation.ItemCategory;

namespace POS.WebApi.Controllers;

[Route("itemCategories")]
public class ItemCategoriesController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public ItemCategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("")]
    public async Task<IActionResult> Create(CreateItemCategoryRequest request)
    {
        var command = _mapper.Map<CreateItemCategoryCommand>(request);
        ErrorOr<ItemCategoryResult> itemCategoryResult = await _mediator.Send(command);

        return itemCategoryResult.Match(
            itemCategoryResult => Ok(_mapper.Map<ItemCategoryResponse>(itemCategoryResult)),
            errors => Problem(errors: errors)
        );
    }
    [HttpPut("")]
    public async Task<IActionResult> Update(PutItemCategoryRequest request)
    {
        var command = _mapper.Map<PutItemCategoryCommand>(request);
        ErrorOr<ItemCategoryResult> itemCategoryResult = await _mediator.Send(command);

        return itemCategoryResult.Match(
            itemCategoryResult => Ok(_mapper.Map<ItemCategoryResponse>(itemCategoryResult)),
            errors => Problem(errors: errors)
        );
    }
    [HttpPatch("")]
    public async Task<IActionResult> UpdatePatch(PatchItemCategoryRequest request)
    {
        var command = _mapper.Map<PatchItemCategoryCommand>(request);
        ErrorOr<ItemCategoryResult> itemCategoryResult = await _mediator.Send(command);

        return itemCategoryResult.Match(
            itemCategoryResult => Ok(_mapper.Map<ItemCategoryResponse>(itemCategoryResult)),
            errors => Problem(errors: errors)
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var query = _mapper.Map<GetItemCategoryQuery>(id);
        ErrorOr<ItemCategoryResult> itemCategoryResult = await _mediator.Send(query);
        return itemCategoryResult.Match(
           itemCategoryResult => Ok(_mapper.Map<ItemCategoryResponse>(itemCategoryResult)),
           errors => Problem(errors)
       );
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var query = _mapper.Map<DeleteItemCategoryCommand>(new List<Guid> { id });
        ErrorOr<bool> deleteResult = await _mediator.Send(query);
        return deleteResult.Match(
           deleteResult => Ok(deleteResult),
           errors => Problem(errors)
       );
    }
    [HttpDelete("")]
    public async Task<IActionResult> DeleteRange([FromBody] List<Guid> ids)
    {
        var query = _mapper.Map<DeleteItemCategoryCommand>(ids);
        ErrorOr<bool> deleteResult = await _mediator.Send(query);
        return deleteResult.Match(
           deleteResult => Ok(deleteResult),
           errors => Problem(errors)
       );
    }
    [HttpGet("")]
    public async Task<IActionResult> GetList([FromQuery] GetListRequest request)
    {
        var query = _mapper.Map<GetListItemCategoryQuery>(request);
        ErrorOr<List<ItemCategoryResult>> itemCategoriesResult = await _mediator.Send(query);
        return itemCategoriesResult.Match(
           itemCategoriesResult => Ok(itemCategoriesResult.ConvertAll(c => _mapper.Map<ItemCategoryResponse>(c)).ToList()),
           errors => Problem(errors)
       );
    }
}
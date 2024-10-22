

using Mapster;
using POS.Application.ItemCategorys.Commands.CreateItemCategory;
using POS.Application.ItemCategorys.Commands.DeleteItemCategory;
using POS.Application.ItemCategorys.Commands.PatchItemCategory;
using POS.Application.ItemCategorys.Commands.PutItemCategory;
using POS.Application.ItemCategorys.Common;
using POS.Application.ItemCategorys.Queries.GetItemCategory;
using POS.Application.ItemCategorys.Queries.GetListItemCategory;
using POS.Domain.ItemCategoryAggregate.ValueObjects;
using POS.Presentation.ItemCategory;

namespace POS.WebApi.Mapping;

public class ItemCategoryMapptingConfig : IRegister
{
        public void Register(TypeAdapterConfig config)
        {
                config.NewConfig<CreateItemCategoryRequest, CreateItemCategoryCommand>();
                config.NewConfig<PutItemCategoryRequest, PutItemCategoryCommand>();
                config.NewConfig<GetListRequest, GetListItemCategoryQuery>();
                config.NewConfig<List<Guid>, DeleteItemCategoryCommand>()
                        .Map(dest => dest.Ids, src => src);
                config.NewConfig<Guid, GetItemCategoryQuery>()
                        .Map(dest => dest.Id, src => src);
                config.NewConfig<ItemCategoryResult, ItemCategoryResponse>()
                        .Map(dest => dest.Id, src => src.ItemCategory.Id.Value.ToString())
                         .Map(dest => dest, src => src.ItemCategory);

        }
}
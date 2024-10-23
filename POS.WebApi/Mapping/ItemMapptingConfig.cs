

using Mapster;
using POS.Application.Items.Commands.CreateItem;
using POS.Application.Items.Commands.UpdateItem;
using POS.Application.Items.Common;
using POS.Presentation.Item;

namespace POS.WebApi.Mapping;

public class ItemMapptingConfig : IRegister
{
        public void Register(TypeAdapterConfig config)
        {
                config.NewConfig<CreateItemRequest, CreateItemCommand>();
                config.NewConfig<UpdateItemRequest, UpdateItemCommand>();
                config.NewConfig<ItemResult, ItemRespone>()
                        .Map(dest => dest.Id, src => src.Item.Id.Value.ToString())
                        .Map(dest => dest.UnitId, src => src.Item.UnitId.Value.ToString())
                        .Map(dest => dest, src => src.Item);

                config.NewConfig<BarcodeRequest, BarcodeCommand>();
        }
}
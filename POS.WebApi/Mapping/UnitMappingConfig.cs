

using Mapster;
using POS.Application.ItemCategorys.Commands.CreateItemCategory;
using POS.Application.ItemCategorys.Commands.DeleteItemCategory;
using POS.Application.ItemCategorys.Commands.PatchItemCategory;
using POS.Application.ItemCategorys.Commands.PutItemCategory;
using POS.Application.ItemCategorys.Common;
using POS.Application.ItemCategorys.Queries.GetItemCategory;
using POS.Application.ItemCategorys.Queries.GetListItemCategory;
using POS.Application.Units.Commands.CreateUnit;
using POS.Application.Units.Commands.DeleteUnits;
using POS.Application.Units.Commands.UpdateUnit;
using POS.Application.Units.Common;
using POS.Application.Units.Queries.GetListUnit;
using POS.Application.Units.Queries.GetUnit;
using POS.Domain.ItemCategoryAggregate.ValueObjects;
using POS.Presentation.ItemCategory;
using POS.Presentation.Unit;

namespace POS.WebApi.Mapping;

public class UnitMappingConfig : IRegister
{
        public void Register(TypeAdapterConfig config)
        {
                config.NewConfig<CreateUnitRequest, CreateUnitCommand>();
                config.NewConfig<UpdateUnitRequest, UpdateUnitCommand>();
                config.NewConfig<GetListUnitRequest, GetListUnitQuery>();
                config.NewConfig<Guid, GetUnitQuery>()
                        .Map(dest => dest.Id, src => src);
                config.NewConfig<UnitResult, UnitResponse>()
                        .Map(dest => dest.Id, src => src.Unit.Id.Value.ToString())
                         .Map(dest => dest, src => src.Unit);
                   config.NewConfig<List<Guid>, DeleteUnitsCommand>()
                        .Map(dest => dest.Ids, src => src);
        }
}
// using CA.Application.Menus.Commnads.CreateMenu;
// using CA.Presentation.Menus;

// using Mapster;

// using MenuSectionRoot = CA.Domain.MenuAggregate.Entities.MenuSection;
// using MenuItemRoot = CA.Domain.MenuAggregate.Entities.MenuItem;
// using CA.Domain.Dinner.ValueObjects;
// using CA.Domain.MenuAggregate;

// namespace CA.WebApi.Mapping;

// public class MenuMapptingConfig : IRegister
// {
//     public void Register(TypeAdapterConfig config)
//     {
//         config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
//         .Map(dest => dest.HostId, src => src.HostId)
//         .Map(dest => dest, src => src.Request);


//         config.NewConfig<Menu, MenuResponse>()
//         .Map(dest => dest.Id, src => src.Id.Value)
//         .Map(dest => dest.HostId, src => src.HostId.Value)
//         .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
//         .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(dinnerId => dinnerId.Value.ToString()))
//         .Map(dest => dest.MenuReviewIds, src=> src.MenuReviewIds.Select(menuReviewId => menuReviewId.Value.ToString()));

//         config.NewConfig<MenuSectionRoot, MenuSectionReponse>()
//         .Map(dest => dest.Id, src => src.Id.Value);

//         config.NewConfig<MenuItemRoot, MenuItemReponse>()
//         .Map(dest => dest.Id, src => src.Id.Value);

//     }
// }
using POS.Domain.ItemCategoryAggregate;

namespace POS.Application.ItemCategorys.Common;


public record ItemCategoriesPagedResult(
    List<ItemCategoryResult> ItemCategories,
    int Total,
    int PageCount,
    int PageIndex

);
public record ItemCategoriesResult(
    List<ItemCategoryResult> ItemCategories
);
public record ItemCategoryResult(
    ItemCategory ItemCategory
);
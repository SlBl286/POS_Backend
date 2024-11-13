using POS.Domain.ItemCategoryAggregate;

namespace POS.Application.ItemCategorys.Common;


public record ItemCategoriesResult(
    List<ItemCategoryResult> ItemCategories,
    int Total,
    int PageCount,
    int PageIndex

);
public record ItemCategoryResult(
    ItemCategory ItemCategory
);
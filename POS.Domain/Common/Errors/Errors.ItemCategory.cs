using ErrorOr;

namespace POS.Domain.Common.Errors;

public static partial class Errors
{
    public static class ItemCategory
    {
        public static Error DuplicateCode=> Error.Conflict(code: "ItemCategory.DuplicateCode",description: " Category already exists.");
        public static Error NotExsits=> Error.Conflict(code: "ItemCategory.NotExsits",description: " Category does not exists.");

    }
}
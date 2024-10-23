using ErrorOr;

namespace POS.Domain.Common.Errors;

public static partial class Errors
{
    public static class Item
    {
        public static Error DuplicateCode=> Error.Conflict(code: "Item.DuplicateCode",description: " Item already exists.");
        public static Error DuplicateBarcode=> Error.Conflict(code: "Item.DuplicateBarcode",description: " Barcode already exists.");

        public static Error NotExsits=> Error.Conflict(code: "Item.NotExsits",description: " Item does not exists.");

    }
}
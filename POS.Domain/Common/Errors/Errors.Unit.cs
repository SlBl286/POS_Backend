using ErrorOr;

namespace POS.Domain.Common.Errors;

public static partial class Errors
{
    public static class Unit
    {
        public static Error DuplicateCode=> Error.Conflict(code: "Unit.DuplicateCode",description: " Unit already exists.");
        public static Error NotExsits=> Error.Conflict(code: "Unit.NotExsits",description: " Unit does not exists.");

    }
}
using ErrorOr;

namespace POS.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateUserName => Error.Conflict(code: "User.DuplicateUserName",description: " User already exists.");

    }
}
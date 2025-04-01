
using ErrorOr;

namespace Posly.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class Authentication
        {
            public static Error InvalidCredentials => Error.Conflict(code: "User.InvalidCred", description: "Invalid Credentials.");
        }
    }
}

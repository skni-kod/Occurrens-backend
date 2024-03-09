using ErrorOr;

namespace Application.Common.Errors;

public static partial class  Errors
{
    public static class Permision
    {
        public static Error PermissionDenied => Error.Conflict(
            code: "Permision denied",
            description: "Wybrana specjalizacja nie istnieje");
    }
}
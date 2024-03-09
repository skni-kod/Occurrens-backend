using ErrorOr;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class DoctorInfoErrors
    {
        public static Error WrongAddressId => Error.Conflict(
            code: "Bad Id",
            description: "Gabinet z takim adresem nie istnieje!");
        
        public static Error NotAccess => Error.Conflict(
            code: "Wrong user",
            description: "Nie posiadasz takiego gabinetu!");

        public static Error DataExists => Error.Conflict(
            code: "Data Exist",
            description: "Nie możesz utworzyć informacji dla gabinetu który posiada już informacje!");
        
        public static Error WrongSpecializationId => Error.Conflict(
            code: "Wrong id",
            description: "Wybierz poprawny gabinet!");
        
        public static Error NotLogged => Error.Conflict(
            code: "Logged error",
            description: "Aby wykonać tą akcję musisz być zalogowany!");

        public static Error WrongOffice => Error.Conflict(
            code: "Wrong id",
            description: "Wybierz poprawny gabinet!");
        
        public static Error NotDataToDisplay => Error.Conflict(
            code: "You haven't any data to display",
            description: "Brak danych do wyświetlenia");
    }
}
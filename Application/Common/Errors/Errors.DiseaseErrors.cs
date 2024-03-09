using ErrorOr;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class DiseaseErrors
    {
        public static Error NotLogged => Error.Conflict(
            code: "Logged error",
            description: "Aby wykonać tą akcję musisz być zalogowany!");
        
        public static Error PatientNotExist => Error.Conflict(
            code: "Patient not exist",
            description: "Nie możesz dodać nieistniejącemu pacjentowi choroby!");
        
        public static Error WrongPatient => Error.Conflict(
            code: "Wrong patient",
            description: "Wybrałeś złego pacjenta");
        
        public static Error WrongDisease => Error.Conflict(
            code: "Wrong disease",
            description: "Wybrałeś złą chorobę");

        public static Error NothingToDisplay => Error.Conflict(
            code: "Nothing to display",
            description: "Brak danych");
    }
}
using ErrorOr;

namespace Application.Common.Errors;

public static partial class Errors
{
    public static class UserErrors
    {
        public static Error DuplicateEmail => Error.Conflict
        (
        code: "Duplicate e-mail",
        description: "Niepoprawne dane rejestracji!");

        public static Error NullEmailOrPasswork => Error.Conflict
        (
            code: "E-mail or password is null",
            description: "Podałeś niepoprawne dane logowania!");

        public static Error AccountNotVerified => Error.Conflict
        (
            code: "Account not verified!", 
            description: "Zweryfikuj adres e-mail!");

        public static Error SomethinkWentWrong => Error.Conflict
        (
            code:"Somethink went wrong!", 
            description:"Coś poszło nie tak!");
        
        public static Error BadEmail => Error.Conflict
        (
            code:"Bad e-mail!", 
            description:"Podałeś niepoprawny e-mail");
    }
}
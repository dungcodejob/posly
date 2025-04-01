
using System.Net;

namespace Posly.Application.Common.Errors;


public class DuplicateEmailError: IError
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exists.";
}
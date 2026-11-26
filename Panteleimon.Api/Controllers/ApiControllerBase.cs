using Microsoft.AspNetCore.Mvc;
using Panteleimon.Api.Http;
using Panteleimon.Domain.Errors;

namespace Panteleimon.Api.Controllers;

[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    protected ObjectResult Problem(Error error) => ApiProblemFactory.ToResult([error]);
}
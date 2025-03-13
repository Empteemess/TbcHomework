using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Web.api.MiddleWare.Localizer;

namespace Web.api.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly JsonLocalizer _localizer;

    public HomeController(JsonLocalizationService localizationService, IHttpContextAccessor httpContextAccessor)
    {
        _localizer = new JsonLocalizer(localizationService, "HomeController", httpContextAccessor);
    }

    [HttpGet]
    [SwaggerOperation
    (
        Summary = "Get Information Based on Language"
    )]
    public IActionResult Get()
    {
        return Ok(new { Message = _localizer["Welcome"] });
    }
}
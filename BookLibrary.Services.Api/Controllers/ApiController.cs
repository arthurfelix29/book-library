using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Services.Api.Controllers
{
	[ApiController]
	[Route("api/v{version:apiVersion}")]
	public abstract class ApiController : ControllerBase
	{
	}
}
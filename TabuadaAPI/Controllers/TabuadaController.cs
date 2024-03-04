using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabuadaAPI.Services;

namespace TabuadaAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TabuadaController : ControllerBase
	{
		private readonly ITabuadaService _tabuadaService;

		public TabuadaController(ITabuadaService tabuadaService)
		{
			_tabuadaService = tabuadaService;
		}

		[HttpPost("processar")]
		public async Task<IActionResult> ProcessarTabuada([FromBody] List<int> numeros)
		{
			var resultados = await _tabuadaService.ProcessarTabuadasAsync(numeros);
			return Ok(resultados);
		}
	}
}

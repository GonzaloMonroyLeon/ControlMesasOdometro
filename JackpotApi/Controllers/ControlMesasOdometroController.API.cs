using Microsoft.AspNetCore.Mvc;
using ControlMesasOdometro.ControlMesasOdometro;
using JackpotApi.Services;

namespace JackpotApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JackpotController : ControllerBase
    {
        private readonly IControlMesasOdometroRepository _jackpotInterface;
        private readonly ILogger<JackpotController> _logger;
        private readonly ControlMesasOdometroService _jackpotService;

        public JackpotController(IControlMesasOdometroRepository jackpotInterface, ILogger<JackpotController> logger, ControlMesasOdometroService jackpotService)
        {
            _jackpotInterface = jackpotInterface;
            _logger = logger;
            _jackpotService = jackpotService;
        }

        [HttpGet("GetVistaJackPot")]
        public async Task<IActionResult> GetJackpots()
        {
            try
            {
                _logger.LogInformation("Iniciando la obtención de jackpots...");

                var jackpots = await _jackpotInterface.GetJackpotsAsync();

                var filteredJackpots = jackpots
                    .Where(j => j.TypeGameId == 1 || j.TypeGameId == 2)
                    .Select(j => new
                    {
                        j.TypeGameId,
                        j.NameWin,
                        j.VisualValue
                    })
                    .ToList();

                if (filteredJackpots == null || !filteredJackpots.Any())
                {
                    _logger.LogWarning("No se encontraron jackpots con TypeGameId 1 o 2.");
                    return NotFound("No se encontraron jackpots con los TypeGameId especificados.");
                }

                _logger.LogInformation("Jackpots obtenidos exitosamente.");
                return Ok(filteredJackpots);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los jackpots.");
                return StatusCode(500, "Error interno del servidor al obtener los jackpots.");
            }
        }
    //    [HttpPost("GetJackpotDifference")]
    //    public async Task<IActionResult> GetJackpotDifference(int typeGameId)
    //    {
    //        try
    //        {
    //            Consulta la tabla temporal para obtener la última diferencia registrada para el juego
    //           var difference = await _jackpotInterface.GetJackpotDifferenceAsync(typeGameId);

    //            if (difference == null)
    //            {
    //                _logger.LogWarning($"No se encontraron diferencias para TypeGameId {typeGameId}.");
    //                return NotFound($"No se encontraron diferencias para TypeGameId {typeGameId}.");
    //            }

    //            Retorna la diferencia al frontend
    //            return Ok(new { TypeGameId = typeGameId, Difference = difference });
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "Error al obtener la diferencia del jackpot.");
    //            return StatusCode(500, "Error interno del servidor al obtener la diferencia.");
    //        }
    //    }

    }

}
using ControlMesasOdometroApi.Data;
using ControlMesasOdometro.ControlMesasOdometro;

namespace JackpotApi.Services
{
    public class ControlMesasOdometroService
    {
        private readonly IControlMesasOdometroRepository _repository;
        private readonly ControlMesasOdometroContext _context;

        public ControlMesasOdometroService(IControlMesasOdometroRepository repository, ControlMesasOdometroContext context)
        {
            _repository = repository;
            _context = context;
        }

        public async Task<List<ControlMesasOdometroModel>> GetJackpotsAsync()
        {
            return await _repository.GetJackpotsAsync();
        }

        public async Task UpdateJackpotAsync(ControlMesasOdometroModel jackpot)
        {
            var existingJackpot = await _context.Jackpots.FindAsync(jackpot.TypeGameId);
            if (existingJackpot != null)
            {
                existingJackpot.VisualValue = jackpot.VisualValue;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Jackpot no encontrado.");
            }
        }
    }
}
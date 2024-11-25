using ControlMesasOdometroApi.Data;
using Microsoft.EntityFrameworkCore;
using ControlMesasOdometro.ControlMesasOdometro;

namespace ControlmesasOdometroRepository.Repositories
{
    public class ControlMesasRepository : IControlMesasOdometroRepository
    {
        private readonly ControlMesasOdometroContext _context;

        public ControlMesasRepository(ControlMesasOdometroContext context)
        {
            _context = context;
        }

        public async Task<List<ControlMesasOdometroModel>> GetJackpotsAsync()
        {
            try
            {
                var response = await _context.Jackpots.ToListAsync();

                return response;
            }
            catch(Exception ex)
            {
                throw new Exception($"Error al obtener los formularios corporativos: {ex.Message}");
            }
        }
        public async Task UpdateJackpotVisualValueAsync(int typeGameId, int VisualValue)
        {
            var jackpotsToUpdate = await _context.Jackpots
                .Where(j => j.TypeGameId == typeGameId)
                .ToListAsync();

            foreach (var jackpot in jackpotsToUpdate)
            {
                jackpot.VisualValue = VisualValue;
            }

            await _context.SaveChangesAsync();
        }
    }

}

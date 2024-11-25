using ControlMesasOdometro.ControlMesasOdometro;
public interface IControlMesasOdometroRepository
{
    Task<List<ControlMesasOdometroModel>> GetJackpotsAsync();
      Task UpdateJackpotVisualValueAsync(int typeGameId, int VisualValue);
    
}

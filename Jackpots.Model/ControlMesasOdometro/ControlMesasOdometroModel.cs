using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ControlMesasOdometro.ControlMesasOdometro;

[Table("TypeGameProgressive")]
public class ControlMesasOdometroModel
{
    [Key]
    public int TypeGameId { get; set; }
    public string? NameWin { get; set; }
    public int VisualValue { get; set; }
    
}

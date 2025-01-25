using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mathExpression.Model
{
    public class MathExpression
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Expression { get; set; }
        public ICollection<MathExpressionSensor> MathExpressionSensors { get; set; } = new List<MathExpressionSensor>();    }
}

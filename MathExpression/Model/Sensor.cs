using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mathExpression.Model
{
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public ICollection<MathExpressionSensor> MathExpressionSensors { get; set; } = new List<MathExpressionSensor>();
    }
}

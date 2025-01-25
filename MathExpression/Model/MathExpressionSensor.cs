using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mathExpression.Model
{
    public class MathExpressionSensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int MathExpressionId { get; set; }
        public MathExpression MathExpression { get; set; }

        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }

        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

using mathExpression;
using mathExpression.Model;
using Microsoft.EntityFrameworkCore;
using NCalc;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Criar nova expressão");
                Console.WriteLine("2 - Obter expressão salva");
                Console.WriteLine("3 - Listar expressões por sensor");
                Console.WriteLine("4 - Sair");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateExpression(context);
                        break;
                    case "2":
                        GetSavedExpression(context);
                        break;
                    case "3":
                        ListExpressionsBySensor(context);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }

    static void CreateExpression(AppDbContext context)
    {
        Console.WriteLine("Sensores disponíveis:");
        var sensors = context.Sensors.ToList();
        foreach (var sensor in sensors)
        {
            Console.WriteLine($"S{sensor.Id} ({sensor.Name}) = {sensor.Value}");
        }

        Console.WriteLine("\nDigite a expressão matemática (use S1, S2, etc. para sensores):");
        string userExpression = Console.ReadLine().ToUpper();

        if (ValidateExpression(userExpression, sensors, out string errorMessage, out string dbExpression))
        {
            var result = EvaluateExpression(dbExpression, sensors);
            Console.WriteLine($"Resultado: {result}");

            var mathExpression = new MathExpression
            {
                Expression = dbExpression // Já contém S1, S2, etc.
            };

            foreach (var sensorId in ExtractSensorIds(dbExpression))
            {
                var sensor = sensors.First(s => s.Id == sensorId);
                mathExpression.MathExpressionSensors.Add(new MathExpressionSensor
                {
                    Sensor = sensor
                });
            }

            context.MathExpressions.Add(mathExpression);
            context.SaveChanges();

            Console.WriteLine($"Expressão salva com ID: {mathExpression.Id}");
        }
        else
        {
            Console.WriteLine($"Erro na expressão: {errorMessage}");
        }
    }

    static void GetSavedExpression(AppDbContext context)
    {
        Console.WriteLine("Digite o ID da expressão:");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var mathExpression = context.MathExpressions
                .Include(m => m.MathExpressionSensors)
                .ThenInclude(mes => mes.Sensor)
                .FirstOrDefault(m => m.Id == id);

            if (mathExpression != null)
            {
                var sensors = mathExpression.MathExpressionSensors.Select(mes => mes.Sensor).ToList();
                string userExpression = ConvertToUserExpression(mathExpression.Expression);
                string calculationExpression = ReplaceWithValues(mathExpression.Expression, sensors);
                decimal result = EvaluateExpression(mathExpression.Expression, sensors);

                Console.WriteLine($"Expressão original: {userExpression}");
                Console.WriteLine($"Expressão com valores: {calculationExpression}");
                Console.WriteLine($"Resultado: {result}");
            }
            else
            {
                Console.WriteLine("Expressão não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("ID inválido.");
        }
    }

    static void ListExpressionsBySensor(AppDbContext context)
    {
        Console.WriteLine("Digite o ID do sensor:");
        if (int.TryParse(Console.ReadLine(), out int sensorId))
        {
            var expressions = context.MathExpressionSensors
                .Where(mes => mes.SensorId == sensorId)
                .Select(mes => mes.MathExpression)
                .ToList();

            if (expressions.Any())
            {
                foreach (var expr in expressions)
                {
                    Console.WriteLine($"ID: {expr.Id}, Expressão: {ConvertToUserExpression(expr.Expression)}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma expressão encontrada para este sensor.");
            }
        }
        else
        {
            Console.WriteLine("ID de sensor inválido.");
        }
    }

    static bool ValidateExpression(string userExpression, List<Sensor> sensors, out string errorMessage, out string dbExpression)
    {
        errorMessage = string.Empty;
        dbExpression = userExpression.ToUpper(); // Garantir que S1, S2, etc. estejam em maiúsculas

        try
        {
            var expr = new Expression(dbExpression);
            var parameters = sensors.ToDictionary(s => $"S{s.Id}", s => (object)s.Value);
            expr.Parameters = parameters;
            expr.Evaluate();
        }
        catch (Exception ex)
        {
            errorMessage = $"Expressão matemática inválida: {ex.Message}";
            return false;
        }

        var sensorIds = ExtractSensorIds(dbExpression);
        var invalidSensorIds = sensorIds.Except(sensors.Select(s => s.Id)).ToList();
        if (invalidSensorIds.Any())
        {
            errorMessage = $"Sensores não encontrados: {string.Join(", ", invalidSensorIds.Select(id => $"S{id}"))}";
            return false;
        }

        return true;
    }

    static decimal EvaluateExpression(string expression, List<Sensor> sensors)
    {
        var expr = new Expression(expression);
        expr.Parameters = sensors.ToDictionary(s => $"S{s.Id}", s => (object)s.Value);
        return Convert.ToDecimal(expr.Evaluate());
    }

    static List<int> ExtractSensorIds(string expression)
    {
        return Regex.Matches(expression, @"S(\d+)")
                    .Cast<Match>()
                    .Select(m => int.Parse(m.Groups[1].Value))
                    .Distinct()
                    .ToList();
    }

    static string ConvertToUserExpression(string dbExpression)
    {
        return Regex.Replace(dbExpression, @"Sensor(\d+)", "S$1");
    }

    static string ReplaceWithValues(string dbExpression, List<Sensor> sensors)
    {
        // Substitui S1, S2, etc. pelos valores correspondentes
        return Regex.Replace(dbExpression, @"S(\d+)", match =>
        {
            int sensorId = int.Parse(match.Groups[1].Value);
            var sensor = sensors.FirstOrDefault(s => s.Id == sensorId);
            return sensor != null ? sensor.Value.ToString() : match.Value;
        });
    }
}
using System.Data;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // create some data
        int[] amounts = new int[] { 100, 150, 200, 300, 250, 3000, 100, 250, 270, 260, 130, 300 };

        List<Withdrawl> withdrawls =
            amounts.Select(amount => new Withdrawl { Amount = amount }).ToList();

        // instantiate machine learning context
        var machineLearningContext = new MLContext();

        // create your algorithm
        var estimator = machineLearningContext.Transforms.DetectIidSpike(
            outputColumnName: nameof(Predication.Output),
            inputColumnName: nameof(Withdrawl.Amount),
            confidence: 99,
            pvalueHistoryLength: amounts.Length / 2);

        // link
        IDataView amountsData = machineLearningContext.Data.LoadFromEnumerable(withdrawls);
        IDataView transformedAmountsData = estimator.Fit(amountsData).Transform(amountsData);

        List<Predication> predictions =
            machineLearningContext.Data
                .CreateEnumerable<Predication>(transformedAmountsData, reuseRowObject: false)
                .ToList();

        foreach (var prediction in predictions)
        {
            double isAnomaly = prediction.Output[0];
            double originalValue = prediction.Output[1];
            double confidenceLevel = prediction.Output[2];

            Console.WriteLine
                ($"Anomaly: {isAnomaly}, Value: {originalValue}, Confidence: {confidenceLevel}");
        }

        Console.ReadKey();
    }
}

public class Withdrawl
{
    public float Amount { get; set; }
}

public class Predication
{
    [VectorType]
    public double[] Output { get; set; }
}
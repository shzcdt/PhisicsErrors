using System.Formats.Asn1;
using Phisics;

int countErrors;
double u;
double o;
double t;
List<double> ValuesOfErrors = new List<double>();
List<double> Oxi = new List<double>();
List<double> Txi = new List<double>();

Console.WriteLine("Set the const of U:");
u = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Set the Instrument error (0):");
o = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Set the Student's Coefficient (t):");
t = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Set the number of error values (N):");
countErrors = Convert.ToInt32(Console.ReadLine());
            
Console.WriteLine("Enter the value of each error");
for (int i = 0; i < countErrors; i++)
{
    Console.Write($"X({i + 1})   ");
    double Errors;
    Errors = Convert.ToDouble(Console.ReadLine());
    ValuesOfErrors.Add(Errors);
}
Console.WriteLine("For Indirect errors:" +
                  " Enter the Ti:");
for (int i = 0; i < countErrors; i++)
{
    Console.Write($"T({i + 1})   ");
    double ti;
    ti = Convert.ToDouble(Console.ReadLine());
    Txi.Add(ti);
}

DirectErrors directErrors = new DirectErrors(countErrors, ValuesOfErrors, 0, u, o, t,0, false);
IndirectErrors indirectErrors = new IndirectErrors(countErrors, 0, ValuesOfErrors, t, 0, 0, 0, Oxi, Txi);
directErrors.Sorted();
directErrors.Scoped();
directErrors.SampleMeanSquareDeviation();

indirectErrors.IntermediateValue();
indirectErrors.CalculateAverageSx();
indirectErrors.Average();
indirectErrors.CalculateDX();

Console.WriteLine($"Sorted Values:");

for (int i = 0; i < ValuesOfErrors.Count; i++)
{
    
    Console.Write($"{ValuesOfErrors[i]} ;");
}
Console.WriteLine();
Console.WriteLine($"Scope of List ({directErrors.Scope})");
directErrors.CheckErrors();
if (directErrors.Check == true)
{
    Console.WriteLine($"Miss");
}
else
{
    Console.WriteLine("Good work");
}
Console.WriteLine($"Average of Values ({directErrors.Average()}) (x̄)");
Console.WriteLine($"S ({directErrors.SLast})");
Console.WriteLine($"d X ({directErrors.RandomError()})");
Console.WriteLine($"d X- ({directErrors.TotalError()})");
Console.WriteLine($"X = ({directErrors.Average()}) +- ({directErrors.TotalError()})");

Console.WriteLine($"For Indirect errors: " +
                  $"Sx ({indirectErrors.Sx}) " +
                  $"Average Sx ({indirectErrors.AverageSx}) " +
                  $"DX ({indirectErrors.DX}) ");
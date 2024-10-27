namespace Phisics;

public class DirectErrors
{
    public int Count;
    public List<double> ValuesOfErrors;
    public double Scope;
    public double U;
    public double O;
    public double T;
    public bool Check;
    public double SLast;
    public double DeltaX;

    public DirectErrors(int count, List<double> valuesOfErrors, double scope, double u, double o, double t, double sLast, bool check)
    {
        Check = check;
        U = u;
        O = o;
        T = t;
        SLast = sLast;
        Count = count;
        ValuesOfErrors = valuesOfErrors;
        Scope = scope;
    }

    public virtual void Sorted()
    {
        ValuesOfErrors.Sort();
    }

    public virtual void Scoped()
    {
        Scope = ValuesOfErrors[Count - 1] - ValuesOfErrors[0];
    }

    public virtual void CheckErrors()
    {
        
        double Temp = U * Scope;
        for (int i = 0; i < ValuesOfErrors.Count - 1; i++)
        {
            if (ValuesOfErrors[i + 1] - ValuesOfErrors[i] > Temp)
            {
                Check = true;
            }
            else
            {
                Check = false;
            }
        }
    }

    public virtual double Average()
    {
        double Sum = 0;
        double Average;
        for (int i = 0; i < ValuesOfErrors.Count; i++)
        {
            Sum += ValuesOfErrors[i];
        }
        Average = Sum / ValuesOfErrors.Count;
        return Average;
    }

    public virtual void SampleMeanSquareDeviation()
    {
        double S;
        S = 0;
        for (int i = 0; i < ValuesOfErrors.Count; i++)
        {
            S += Math.Pow((ValuesOfErrors[i] - Average()), 2);
            // Console.WriteLine($"({ValuesOfErrors[i]} - {Average()}) ** 2 ={S}");
        }

        SLast = Math.Pow(S / Count * (Count - 1), 0.5);
    }
    public virtual double RandomError()
    {
        DeltaX = T * SLast;
        return DeltaX;
    }

    public virtual double TotalError()
    {
        double deltaXstreak;
        deltaXstreak = Math.Pow(Math.Pow(O, 2) + Math.Pow(DeltaX, 2), 0.5);
        return deltaXstreak;
    }
}
namespace Phisics;

public class IndirectErrors
{
    public int Count;
    public double AverageX;
    public List<double> ValuesOfErrors;
    public double T;
    public double Sx;
    public double AverageSx;
    public double DX;
    public List<double> Oxi;
    public List<double> Txi;

    public IndirectErrors(int count ,double averageX, List<double> valuesOfErrors, double t, double sx, double averageSx, double dX, List<double> oxi, List<double> txi)
    {
        Count = count;
        AverageX = averageX;
        ValuesOfErrors = valuesOfErrors;
        T = t;
        Sx = sx;
        AverageSx = averageSx;
        DX = dX;
        Oxi = oxi;
        Txi = txi;
    }

    public virtual void Average()
    {
        double Sum = 0;
        for (int i = 0; i < ValuesOfErrors.Count; i++)
        {
            Sum += ValuesOfErrors[i];
        }
        AverageX = Sum / ValuesOfErrors.Count;
    }
    public virtual void IntermediateValue()
    {
        double Sum = 0;
        
        for (int i = 0; i < ValuesOfErrors.Count; i++)
        {
            Sum += Math.Pow(ValuesOfErrors[i] - AverageX, 2);
        }

        Sx = Math.Pow(Math.Pow(Sum / Count - 1, 0.5), 2);
    }

    public virtual void CalculateAverageSx()
    {
        AverageSx = Sx / Math.Pow(Count, 0.5);
    }

    public virtual void CalculateDX()
    {
        DX = T * AverageSx;
    }

    public virtual void CalculateOxi()
    {
        
    }
}
namespace ContainerSchip.Interfaces;

public interface IContainer
{
    public int weight
    {
        get { throw new NotImplementedException(); }
    }

    public double fitness
    {
        get { throw new NotImplementedException(); }
    }

    public bool valuable
    {
        get { throw new NotImplementedException(); }
    }

    public bool coolable
    {
        get { throw new NotImplementedException(); }
    }
    public double CalculateFitness(int width, int height, int length, IContainer[,,] shipData);
}
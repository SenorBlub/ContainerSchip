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

    bool IsTopContainer(int i, int i1, int i2, IContainer[,,] shipData)
    {
        throw new NotImplementedException();
    }

    bool HasContainerInFront(int i, int i1, int i2, IContainer[,,] shipData)
    {
        throw new NotImplementedException();
    }

    bool HasContainerBehind(int i, int i1, int i2, IContainer[,,] shipData)
    {
        throw new NotImplementedException();
    }
}
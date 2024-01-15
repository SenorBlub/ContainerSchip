using ContainerSchip.Interfaces;

namespace ContainerSchip.Classes;

public class ValuableCoolableContainer : IContainer
{

    public int weight { get; }
    public double fitness { get; set; }
    public bool valuable { get; }
    public bool coolable { get; }

    public ValuableCoolableContainer(int _weight)
    {
        weight = _weight;
        valuable = true;
        coolable = true;
    }

    public ValuableCoolableContainer()
    {
        weight = new Random().Next(0, 26);
        valuable = true;
        coolable = true;
    }

    public double CalculateFitness(int width, int height, int length, IContainer[,,] shipData)
    {
        double dWidth = (double)width;
        double dHeight = (double)height;
        dWidth += 1;
        dHeight += 1;
        fitness = weight / ((width / (width * 0.5)) * height);
        if (length > 0)
        {
            fitness += 1000000;
        }

        if (!IsTopContainer(length, width, height, shipData))
        {
            fitness += 1000000;
        }

        if (!HasContainerInFront(length, width, height, shipData) || !HasContainerBehind(length, width, height, shipData))
        {
            fitness += 1000000;
        }

        return fitness;
    }

    bool IsTopContainer(int length, int width, int height, IContainer[,,] shipData)
    {
        return height == shipData.GetLength(2) - 1 || shipData[length, width, height + 1] == null;
    }

    bool HasContainerInFront(int length, int width, int height, IContainer[,,] shipData)
    {
        return length > 0 && shipData[length - 1, width, height] != null;
    }

    bool HasContainerBehind(int length, int width, int height, IContainer[,,] shipData)
    {
        return length < shipData.GetLength(0) - 1 && shipData[length + 1, width, height] != null;
    }

}
using ContainerSchip.Interfaces;

namespace ContainerSchip.Classes;

public class CoolableContainer : IContainer
{
    public int weight { get; }
    public double fitness { get; set; }
    public bool valuable { get; }
    public bool coolable { get; }

    public CoolableContainer(int _weight)
    {
        weight = _weight;
        valuable = false;
        coolable = true;
    }

    public CoolableContainer()
    {
        weight = new Random().Next(0, 26);
        valuable = false;
        coolable = true;
    }

    public double CalculateFitness(int width, int height, int length, IContainer[,,] shipData)
    {
        double dWidth = (double)width;
        double dHeight = (double)height;
        dWidth += 1;
        dHeight += 1;
        fitness = weight / ((width / (width * 0.5)) * (1 / height));
        if (length > 0)
        {
            fitness += 1000000;
        }
        return fitness;
    }
}
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

    public double CalculateFitness(int width, int height, int length, bool isTopContainer, bool frontAccessible, bool backAccessible)
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

        if (!isTopContainer)
        {
            fitness += 1000000;
        }

        if (!frontAccessible || backAccessible)
        {
            fitness += 1000000;
        }

        return fitness;
    }

}
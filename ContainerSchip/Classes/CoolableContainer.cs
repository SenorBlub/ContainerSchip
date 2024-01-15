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

    public double CalculateFitness(int width, int height)
    {
        width += 1;
        height += 1;
        fitness = weight / ((width / (width * 0.5)) * height);
        return weight / ((width / (width * 0.5)) * height);
    }
}
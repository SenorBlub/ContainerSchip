using ContainerSchip.Interfaces;

namespace ContainerSchip.Classes;

public class ValuableContainer : IContainer
{
    public int weight { get; }
    public bool valuable { get; }
    public bool coolable { get; }

    public ValuableContainer(int _weight)
    {
        weight = _weight;
        valuable = true;
        coolable = false;
    }

    public ValuableContainer()
    {
        weight = new Random().Next(0, 26);
        valuable = true;
        coolable = false;
    }

}
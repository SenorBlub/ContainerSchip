using ContainerSchip.Interfaces;

namespace ContainerSchip.Classes;

public class ValuableCoolableContainer : IContainer
{

    public int weight { get; }
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

}
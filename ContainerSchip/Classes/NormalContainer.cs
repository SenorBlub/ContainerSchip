using ContainerSchip.Interfaces;

namespace ContainerSchip.Classes;

public class NormalContainer : IContainer
{
    public int weight { get; }
    public bool valuable { get; }
    public bool coolable { get; }

    public NormalContainer(int _weight)
    {
        weight = _weight;
        valuable = false;
        coolable = false;
    }

    public NormalContainer()
    {
        weight = new Random().Next(0, 26);
        valuable = false;
        coolable = false;
    }

}
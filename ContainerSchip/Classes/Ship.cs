using ContainerSchip.Interfaces;

namespace ContainerSchip.Classes;

public class Ship
{
    public int Length { get; }
    public int Width { get; }

    public double fitness { get; set; }

    public int MaxWeight { get; }

    public IContainer[,,] ShipData { get; }

    public Ship(int length, int width)
    {
        Length = length;
        Width = width;
        MaxWeight = 120000 * length * width;
        ShipData = new IContainer[length, width, 4];
    }

    public double CalculateFitness()
    {
        double tempFitness = 0;
        foreach (var container in ShipData)
        {
            if(container.fitness != null)
                tempFitness += container.fitness;
        }
        fitness = tempFitness;
        return tempFitness;
    }
}
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
        weight = new Random().Next(10, 26) + 4;
        valuable = false;
        coolable = true;
    }

    public double CalculateFitness(int width, int height, int length, IContainer[,,] shipData)
    {
        double conditionMissedVal = 1000000;
        double maxWidth = shipData.GetLength(1)+0.5;
        double dWidth = (double)width;
        double dHeight = (double)height;
        dWidth += 1;
        dHeight += 1;
        fitness = (weight * Math.Abs(dWidth - (maxWidth / 2.0))) / (1 / dHeight);
        if (length > 0)
        {
            fitness += conditionMissedVal;
            conditionMissedVal = 0;
        }

        conditionMissedVal = 1000000;

        if (height > 0)
        {
            if ((shipData[length, width, height - 1] is Object) && shipData[length, width, height - 1].valuable || !(shipData[length, width, height - 1] is Object))
            {
                fitness += conditionMissedVal;
                conditionMissedVal = 0;
            }
        }

        return fitness;
    }
}
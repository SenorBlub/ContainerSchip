using ContainerSchip.Interfaces;

namespace ContainerSchip.Classes;

public class ValuableContainer : IContainer
{
    public int weight { get; }
    public double fitness { get; set;
    }
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
        weight = new Random().Next(10, 26) + 4;
        valuable = true;
        coolable = false;
    }

    public double CalculateFitness(int width, int height, int length, IContainer[,,] shipData)
    {
        double conditionMissedVal = 1000000;
        double maxWidth = shipData.GetLength(0)+0.5;
        double dWidth = (double)width;
        double dHeight = (double)height;
        dWidth += 1;
        dHeight += 1;
        fitness = (weight * Math.Abs(dWidth - (maxWidth / 2.0))) / (dHeight);

        if (!IsTopContainer(length, width, height, shipData))
        {
            fitness += conditionMissedVal;
            conditionMissedVal = 0;
        }

        if (HasContainerInFront(length, width, height, shipData) && HasContainerBehind(length, width, height, shipData))
        {
            fitness += conditionMissedVal;
            conditionMissedVal = 0;
        }

        conditionMissedVal = 1000000;

        if (HasContainerBehind(length, width, height, shipData) && length == shipData.GetLength(0) - 1)
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

    bool IsTopContainer(int length, int width, int height, IContainer[,,] shipData)
    {
        if (height == 3)
            return true;
        if (!(shipData[length, width, height + 1] is Object))
            return true;
        return false;
    }

    bool HasContainerInFront(int length, int width, int height, IContainer[,,] shipData)
    {
        return length > 0 && (shipData[length - 1, width, height] is Object);
    }

    bool HasContainerBehind(int length, int width, int height, IContainer[,,] shipData)
    {
        return length < shipData.GetLength(0) - 1 && (shipData[length + 1, width, height] is Object);
    }

}
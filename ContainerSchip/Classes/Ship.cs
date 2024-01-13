using ContainerSchip.Interfaces;

namespace ContainerSchip.Classes;

public class Ship
{
    public int Length { get; }
    public int Width { get; }

    private int MaxWeight { get; }

    public IContainer[,] ShipData { get; }

    public Ship(int length, int width)
    {
        Length = length;
        Width = width;
        MaxWeight = 120000 * length * width;
        ShipData = new IContainer[length, width];
    }

    public bool IsBalanced()
    {
        int leftWeight = 0;
        int rightWeight = 0;

        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (j > Width / 2)
                {
                    leftWeight =+ ShipData[i, j].weight;
                }
                else
                {
                    rightWeight =+ ShipData[i, j].weight;
                }
            }
        }

        return rightWeight / leftWeight - 1 < .2 && rightWeight / leftWeight > -.2;
    }

    public bool IsHeavyEnough()
    {
        int weight = 0;
        foreach (var container in ShipData)
        {
            weight = +container.weight;
        }
        return weight > MaxWeight/2;
    }

    public bool AllAccessible()
    {
        for (int i = 0; i < Length; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (ShipData[i, j].coolable)
                {
                    if (i != 0)
                    {
                        return false;
                    }
                }

                if (0 <= i && i < ShipData.Length)
                {
                    if (ShipData[i + 1, j] != null || ShipData[i - 1, j] != null)
                    {
                        return false;
                    }
                }

                if (i == 0)
                {
                    if (ShipData[i + 1, j] != null)
                    {
                        return false;
                    }
                }
                else if (i == ShipData.Length - 1)
                {
                    if (ShipData[i - 1, j] != null)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public bool IsShipCorrect()
    {
        if (IsBalanced() && AllAccessible() && IsBalanced())
            return true;
        return false;
    }
}
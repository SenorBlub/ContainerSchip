using ContainerSchip.Interfaces;
using ContainerSchip.Classes;

public class ShipDisplay
{
    public void DisplayShips(List<Ship> ships)
    {
        foreach (var ship in ships)
        {
            string rowSeparator = "";
            for (int i = 0; i < ship.Length; i++)
            {
                rowSeparator += "/";
            }

            Console.WriteLine();

            for (int i = 0; i < ship.Length; i++)
            {
                string[] containerData = new string[ship.Width];
                for (int j = 0; j < ship.Width; j++)
                {
                    IContainer container = ship.ShipData[i, j];
                    if (container == null)
                    {
                        containerData[j] = ",,";
                    }
                    else
                    {
                        string containerTypeString = "";
                        switch (container.GetType().Name)
                        {
                            case "NormalContainer": containerTypeString = "N"; break;
                            case "ValuableContainer": containerTypeString = "V"; break;
                            case "CoolableContainer": containerTypeString = "C"; break;
                            case "ValuableCoolableContainer": containerTypeString = "VC"; break;
                        }

                        containerData[j] = containerTypeString + "--" + container.weight.ToString() + "kg";
                    }
                }

                Console.WriteLine(string.Join(" ", containerData) + rowSeparator);
            }

            Console.WriteLine();
        }
    }
}
using ContainerSchip.Classes;

Console.WriteLine("Normal container count: ");
int normalContainerCount = int.Parse(Console.ReadLine());
Console.WriteLine("Coolable container count: ");
int coolableContainerCount = int.Parse(Console.ReadLine());
Console.WriteLine("Valuable container count: ");
int valuableContainerCount = int.Parse(Console.ReadLine());
Console.WriteLine("Valuable coolable container count: ");
int valuableCoolableContainerCount = int.Parse(Console.ReadLine());

int[,] shipParameters = new int[100, 3];
bool done = false;
int tempWidth = 0;
int tempLength = 0;
int tempCount = 0;
int cycleCounter = 0;
string YN = "";

while (!done)
{
    Console.WriteLine("Ship Width: ");
    tempWidth = int.Parse(Console.ReadLine());
    Console.WriteLine("Ship Length: ");
    tempLength = int.Parse(Console.ReadLine());
    Console.WriteLine("Amount of specified ships: ");
    tempCount = int.Parse(Console.ReadLine());

    shipParameters[cycleCounter, 0] = tempWidth;
    shipParameters[cycleCounter, 1] = tempLength;
    shipParameters[cycleCounter, 2] = tempCount;

    Console.WriteLine("Add more ships? (y/n): ");
    YN = Console.ReadLine();
    if (YN == "n" || YN == "N")
    {
        done = true;
    }
    else
    {
        done = false;
    }
}

Dock dock = new Dock(normalContainerCount, coolableContainerCount, valuableContainerCount, valuableCoolableContainerCount, shipParameters);

dock.PlaceContainers(dock.FindShipsToUse(), dock.containers);

foreach (var ship in dock.ships)
{
    new ShipDisplay(ship).Display();
}
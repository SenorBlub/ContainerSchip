using ContainerSchip.Classes;

int normalContainerCount = int.Parse(Console.ReadLine());
int coolableContainerCount = int.Parse(Console.ReadLine());
int valuableContainerCount = int.Parse(Console.ReadLine());
int valuableCoolableContainerCount = int.Parse(Console.ReadLine());

Dock dock = new Dock(normalContainerCount, coolableContainerCount, valuableContainerCount, valuableCoolableContainerCount);
dock.PutContainersOnShips();

new ShipDisplay().DisplayShips(dock.ships);
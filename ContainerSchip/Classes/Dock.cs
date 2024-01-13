using ContainerSchip.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContainerSchip.Classes
{
    public class Dock
    {
        public List<IContainer> containers = new List<IContainer>();

        public List<Ship> ships = new List<Ship>();

        public Dock(int normalContainerCount, int coolableContainerCount, int valuableContainerCount,
            int valuableCoolableContainerCount)
        {
            for (int i = 0; i < normalContainerCount; i++)
                containers.Add(new NormalContainer());
            for (int i = 0; i < coolableContainerCount; i++)
                containers.Add(new CoolableContainer());
            for (int i = 0; i < valuableContainerCount; i++)
                containers.Add(new ValuableContainer());
            for (int i = 0; i < valuableCoolableContainerCount; i++)
                containers.Add(new ValuableCoolableContainer());
        }

        public List<Ship> MakeShips(int Count, int Length, int Width)
        {
            List<Ship> ships = new List<Ship>();
            for(int i = 0; i < Count; i++)
                ships.Add(new Ship(Length, Width));
            return ships;
        }

        public void PutContainersOnShips()
        {

        }
    }

}
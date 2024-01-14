﻿using ContainerSchip.Interfaces;
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

        public List<Ship> FindShipsToUse()
        {
            int valuableContainerCount = 0;
            int coolableContainerCount = 0;
            int valuableCoolableContainerCount = 0;
            int normalContainerCount = 0;

            Dictionary<int, List<Ship>> shipsByWidthDictionary = new Dictionary<int, List<Ship>>();
            foreach (var container in containers)
            {
                switch ((container.valuable, container.coolable))
                {
                    case (true, true):
                        valuableCoolableContainerCount++;
                        break;
                    case (true, false):
                        valuableContainerCount++;
                        break;
                    case (false, true):
                        coolableContainerCount++;
                        break;
                    default:
                        normalContainerCount++;
                        break;
                }
            }

            foreach (var ship in ships)
            {
                if (shipsByWidthDictionary.ContainsKey(ship.Width))
                {
                    shipsByWidthDictionary[ship.Width].Add(ship);
                }
                else
                {
                    shipsByWidthDictionary.Add(ship.Width, new List<Ship>
                    {
                        ship
                    });
                }

            }

            var sortedWidths = shipsByWidthDictionary.Keys.OrderByDescending(x => x).ToList();

            int currentCapacity = 0;
            List<Ship> usedShips = new List<Ship>();

            foreach (var width in sortedWidths)
            {

                foreach (var ship in shipsByWidthDictionary[width])
                {
                    if (currentCapacity >= valuableCoolableContainerCount)
                    {
                        break; 
                    }

                    currentCapacity += width;
                    usedShips.Add(ship);

                    if (currentCapacity >= valuableCoolableContainerCount)
                    {
                        break;
                    }
                }

                if (currentCapacity >= valuableContainerCount)
                {
                    break; 
                }
            }

            if (coolableContainerCount > 3 * valuableCoolableContainerCount || valuableContainerCount > valuableCoolableContainerCount)
            {
                int additionalCapacityNeeded = Math.Max(valuableContainerCount, coolableContainerCount) - valuableCoolableContainerCount;

                foreach (var width in sortedWidths)
                {
                    if (additionalCapacityNeeded <= 0)
                    {
                        break;
                    }

                    foreach (var ship in shipsByWidthDictionary[width])
                    {
                        if (!usedShips.Contains(ship))
                        {
                            additionalCapacityNeeded -= width;
                            usedShips.Add(ship);
                        }

                        if (additionalCapacityNeeded <= 0)
                        {
                            break;
                        }
                    }
                }
            }
            int totalCapacityForNormalContainers = 0;

            foreach (var ship in usedShips)
            {
                int shipCapacityForNormal = ship.Length * ship.Width * 4;

                shipCapacityForNormal -= (valuableContainerCount + coolableContainerCount + valuableCoolableContainerCount);

                totalCapacityForNormalContainers += shipCapacityForNormal;
            }

            while (totalCapacityForNormalContainers < normalContainerCount)
            {
                bool shipAdded = false;

                foreach (var width in sortedWidths)
                {
                    foreach (var ship in shipsByWidthDictionary[width])
                    {
                        if (!usedShips.Contains(ship))
                        {
                            usedShips.Add(ship);
                            shipAdded = true;

                            int shipCapacityForNormal = ship.Length * ship.Width * 4;
                            shipCapacityForNormal -= (valuableContainerCount + coolableContainerCount + valuableCoolableContainerCount);
                            totalCapacityForNormalContainers += shipCapacityForNormal;

                            if (totalCapacityForNormalContainers >= normalContainerCount)
                            {
                                break;
                            }
                        }
                    }

                    if (shipAdded || totalCapacityForNormalContainers >= normalContainerCount)
                    {
                        break;
                    }
                }

                if (!shipAdded)
                {
                    break;
                }
            }

            return usedShips;
        }
    }

}
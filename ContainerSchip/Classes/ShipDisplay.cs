using ContainerSchip.Interfaces;
using System;
using System.Collections.Generic;

namespace ContainerSchip.Classes
{
    public class ShipDisplay
    {
        public Ship Ship { get; private set; }

        public ShipDisplay(Ship ship)
        {
            Ship = ship;
        }

        public void Display()
        {
            for (int height = Ship.ShipData.GetLength(2) - 1; height >= 0; height--)
            {
                Console.WriteLine($"Layer {height + 1}:");
                for (int length = 0; length < Ship.ShipData.GetLength(0); length++)
                {
                    for (int width = 0; width < Ship.ShipData.GetLength(1); width++)
                    {
                        IContainer container = Ship.ShipData[length, width, height];
                        if (container != null)
                        {
                            Console.Write(DisplayContainer(container) + " " + container.fitness);
                        }
                        else
                        {
                            Console.Write("E ");
                        }
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        private string DisplayContainer(IContainer container)
        {
            // Customize this method based on how you want to represent different container types
            if (container.valuable && container.coolable)
                return "VC"; // Valuable-Coolable
            else if (container.valuable)
                return "V "; // Valuable
            else if (container.coolable)
                return "C "; // Coolable
            else
                return "N "; // Normal
        }
    }
}
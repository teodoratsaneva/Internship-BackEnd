using System;

namespace LambdaCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            PowerPlant powerPlant = new PowerPlant();
            string input;
            while ((input = Console.ReadLine()) != "System Shutdown!")
            {
                string[] commandArgs = input.Split(':');
                string command = commandArgs[0];
                string[] parameters = commandArgs[1].Split('@');

                switch (command)
                {
                    case "CreateCore":
                        string type = parameters[1];
                        int durability = int.Parse(parameters[2]);
                        try
                        {
                            powerPlant.CreateCore(type, durability);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Failed to create Core!");
                        }
                        break;

                    case "RemoveCore":
                        string name = parameters[1];
                        try
                        {
                            powerPlant.RemoveCore(name);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine($"Failed to remove Core {name}!");
                        }
                        break;

                    case "SelectCore":
                        string selectedCoreName = parameters[1];
                        try
                        {
                            powerPlant.SelectCore(selectedCoreName);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine($"Failed to select Core {selectedCoreName}!");
                        }
                        break;

                    case "AttachFragment":
                        string fragmentType = parameters[1];
                        string fragmentName = parameters[2];
                        int pressureAffection = int.Parse(parameters[3]);
                        try
                        {
                            powerPlant.AttachFragment(fragmentName, pressureAffection, fragmentType);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine($"Failed to attach Fragment {fragmentName}!");
                        }
                        break;

                    case "DetachFragment":
                        try
                        {
                            powerPlant.DetachFragment();
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Failed to detach Fragment!");
                        }
                        break;

                    case "Status":
                        powerPlant.PrintStatus();
                        break;
                }
            }
        }

    }
}
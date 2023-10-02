using System;
using System.Runtime.InteropServices;

namespace LambdaCore
{
    public class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, TypeCore> coreTypeMapping = new Dictionary<string, TypeCore>();
            coreTypeMapping["System"] = TypeCore.SystemCore;
            coreTypeMapping["Para"] = TypeCore.ParaCore;

            Dictionary<string, FragmentType> fragmentTypeMapping = new Dictionary<string, FragmentType>();
            fragmentTypeMapping["Nuclear"] = FragmentType.NuclearFragment;
            fragmentTypeMapping["Cooling"] = FragmentType.CoolingFragment;

            Dictionary<string, Command> commandMapping = new Dictionary<string, Command>();
            commandMapping["CreateCore"] = Command.CreateCore;
            commandMapping["RemoveCore"] = Command.RemoveCore;
            commandMapping["SelectCore"] = Command.SelectCore;
            commandMapping["AttachFragment"] = Command.AttachFragment;
            commandMapping["DetachFragment"] = Command.DetachFragment;
            commandMapping["Status"] = Command.Status;

            try
            {
                PowerPlant powerPlant = new PowerPlant();
                string input;

                while ((input = Console.ReadLine()) != "System Shutdown!")
                {
                    string[] commandArgs = input.Split(':');
                    Command command = commandMapping[commandArgs[0]];
                    string[] parameters = commandArgs[1].Split('@');

                    switch (command)
                    {
                        case Command.CreateCore:
                            TypeCore coreType = coreTypeMapping[parameters[1]];
                            int durability = int.Parse(parameters[2]);
                            powerPlant.CreateCore(coreType, durability);
                            break;

                        case Command.RemoveCore:
                            string name = parameters[1];
                            powerPlant.RemoveCore(name);
                            break;

                        case Command.SelectCore:
                            string selectedCoreName = parameters[1];
                            powerPlant.SelectCore(selectedCoreName);
                            command = Command.CreateCore;
                            string input2;

                            while ((input2 = Console.ReadLine()) != "Quit")
                            {
                                string[] commandArgs2 = input2.Split(':');
                                Command command2 = commandMapping[commandArgs2[0]];
                                string[] parameters2 = commandArgs2[1].Split('@');

                                switch (command2)
                                {
                                    case Command.AttachFragment:
                                        FragmentType fragmentType = fragmentTypeMapping[parameters2[1]];
                                        string fragmentName = parameters2[2];
                                        int pressureAffection = int.Parse(parameters2[3]);
                                        powerPlant.AttachFragment(fragmentName, pressureAffection, fragmentType);
                                        break;

                                    case Command.DetachFragment:
                                        powerPlant.DetachFragment();
                                        break;
                                    default:
                                        Console.WriteLine("Invalid command! Please try again!");
                                        break;
                                }
                            }
                            break;

                        case Command.Status:
                            Console.WriteLine(powerPlant.ToString());
                            break;

                        default:
                            Console.WriteLine("Invalid command! Please try again!");
                            break;
                    }
                }
            }
            catch (InvalidCoreTypeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidFragmentTypeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FailedDetachException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key is not found.");
            }
        }
    }
}
using System;

namespace LambdaCore
{
    public class PowerPlant
    {
        private List<Core> cores = new List<Core>();
        private Core selectedCore = null;

        public void CreateCore(string type, int durability)
        {
            char coreName = (char)('A' + cores.Count());

            if (type == "System")
            {
                Core core = new Core(TypeCore.SystemCore, coreName.ToString(), durability);
                cores.Add(core);
                Console.WriteLine($"Successfully created Core {coreName}!");
            }
            else if (type == "Para")
            {
                Core core = new Core(TypeCore.ParaCore, coreName.ToString(), durability);
                cores.Add(core);
                Console.WriteLine($"Successfully created Core {coreName}!");
            }
            else
            {
                throw new ArgumentException();
            }
        }
        public Core FindCoreByName(string coreName)
        {
            foreach (Core core in cores)
            {
                if (core.CoreName == coreName && core != null)
                {
                    return core;
                }
            }

            throw new ArgumentException();
        }
        public void RemoveCore(string coreName)
        {
            Core core = FindCoreByName(coreName);
            cores.Remove(core);
            Console.Write($"Successfully removed Core {coreName}!");
        }

        public void SelectCore(string coreName)
        {
            selectedCore = FindCoreByName(coreName);
            Console.WriteLine($"Currently selected Core {coreName}!");
        }

        public void AttachFragment(string nameFragment, int pressureAffection, string type)
        {
            if (type == "Nuclear")
            {
                Fragment fragment = new Fragment(FragmentType.NuclearFragment, nameFragment, pressureAffection);
                selectedCore.AddFragment(fragment);
                selectedCore.IncreasePressure(pressureAffection * 2);
                Console.WriteLine($"Successfully attached Fragment {nameFragment} to Core {selectedCore.CoreName}!");
            }
            else if (type == "Cooling")
            {
                Fragment fragment = new Fragment(FragmentType.CoolingFragment, nameFragment, pressureAffection);
                selectedCore.AddFragment(fragment);
                selectedCore.DecreasePressure(pressureAffection * 3);
                Console.WriteLine($"Successfully attached Fragment {nameFragment} to Core {selectedCore.CoreName}!");
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void DetachFragment()
        {
            if (selectedCore == null || selectedCore.Fragments.Count == 0)
            {
                throw new ArgumentException();
            }

            Fragment fragmentToRemove = selectedCore.Fragments.ElementAt(selectedCore.Fragments.Count - 1);
            selectedCore.Fragments.RemoveAt(selectedCore.Fragments.Count - 1);
            if (fragmentToRemove.Type == FragmentType.NuclearFragment)
            {
                selectedCore.DecreasePressure(fragmentToRemove.PressureAffection);
            }
            else if (fragmentToRemove.Type == FragmentType.CoolingFragment)
            {
                selectedCore.IncreasePressure(fragmentToRemove.PressureAffection);
            }
            Console.WriteLine($"Successfully detached Fragment {fragmentToRemove.Name} from Core {selectedCore.CoreName}!");
        }

        public void PrintStatus()
        {
            Console.WriteLine("Lambda Core Power Plant Status:");
            Console.WriteLine($"Total Durability: {cores.Sum(c => c.Durability)}");
            Console.WriteLine($"Total Cores: {cores.Count}");
            Console.WriteLine($"Total Fragments: {cores.Sum(c => c.Fragments.Count)}");

            foreach (Core core in cores)
            {
                Console.WriteLine($"Core {core.CoreName}:");
                Console.WriteLine($"####Durability: {core.Durability}");
                Console.WriteLine($"####Status: {(core.IsCritical ? "CRITICAL" : "NORMAL")}");
            }
        }
    }
}
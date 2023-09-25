using System;

namespace LambdaCore
{
    public class PowerPlant
    {
        private List<Core> cores = new List<Core>();
        private Core selectedCore = null;

        public void CreateCore(TypeCore type, int durability)
        {
            if (type != TypeCore.SystemCore && type != TypeCore.ParaCore)
            {
                throw new InvalidCoreTypeException();
            }

            char coreName = (char)('A' + cores.Count());

            Core core = (type == TypeCore.SystemCore) ? new SystemCore(type, coreName.ToString(), durability) : new ParaCore(type, coreName.ToString(), durability);
            cores.Add(core);
            Console.WriteLine($"Successfully created Core {coreName}!");
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

            throw new FailedFindCoreException();
        }

        public void RemoveCore(string coreName)
        {
            try
            {
                Core core = FindCoreByName(coreName);
                cores.Remove(core);
                Console.Write($"Successfully removed Core {coreName}!");
            }
            catch (FailedFindCoreException)
            {
                Console.WriteLine($"Failed to remove Core {coreName}!");
            }
        }

        public void SelectCore(string coreName)
        {
            try
            {
                selectedCore = FindCoreByName(coreName);
                Console.WriteLine($"Currently selected Core {coreName}!");
            }
            catch (FailedFindCoreException)
            {
                Console.WriteLine($"Failed to select Core {coreName}!");
            }
        }

        public void AttachFragment(string nameFragment, int pressureAffection, FragmentType type)
        {
            if (type != FragmentType.NuclearFragment && type != FragmentType.CoolingFragment)
            {
                throw new InvalidFragmentTypeException();
            }

            if (selectedCore != null)
            {
                Fragment fragment = (type == FragmentType.NuclearFragment) ? new NuclearFragment(type, nameFragment, pressureAffection) : new CoolingFragment(type, nameFragment, pressureAffection);
                selectedCore.AddFragment(fragment);
                selectedCore.DecreasePressure(pressureAffection * 3);
                Console.WriteLine($"Successfully attached Fragment {nameFragment} to Core {selectedCore.CoreName}!");
            }
        }

        public void DetachFragment()
        {
            if (selectedCore == null || selectedCore.Fragments.Count == 0)
            {
                throw new FailedDetachExeption();
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

        public override string ToString()
        {
            return "Lambda Core Power Plant Status:\n" + $"Total Durability: {cores.Sum(c => c.Durability)}\n"
                    + $"Total Cores: {cores.Count}\n" + $"Total Fragments: {cores.Sum(c => c.Fragments.Count)}\n"
                    + string.Join("", cores);
        }
    }
}
using System;

namespace LambdaCore
{
    public class PowerPlant
    {
        private List<Core> cores = new List<Core>();
        private Core selectedCore = null;

        public List<Core> Cores
        {
            get
            {
                if (cores == null)
                {
                    cores = new List<Core>();
                }
                return cores;
            }
            set { cores = value; }
        }

        public Core SelectedCore { get; set; }

        public void CreateCore(TypeCore type, int durability)
        {
            if (!Enum.IsDefined(typeof(TypeCore), type))
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
                if (core.CoreName == coreName)
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
                SelectedCore = FindCoreByName(coreName);
                Console.WriteLine($"Currently selected Core {coreName}!");
            }
            catch (FailedFindCoreException)
            {
                Console.WriteLine($"Failed to select Core {coreName}!");
            }
        }

        public void AttachFragment(string nameFragment, int pressureAffection, FragmentType type)
        {
            if (!Enum.IsDefined(typeof(FragmentType), type) || SelectedCore == null)
            {
                throw new InvalidFragmentTypeException();
            }

            Fragment fragment = (type == FragmentType.NuclearFragment) ? new NuclearFragment(type, nameFragment, pressureAffection) : new CoolingFragment(type, nameFragment, pressureAffection);
            SelectedCore.AddFragment(fragment);

            if (fragment.Type == FragmentType.NuclearFragment)
            {
                SelectedCore.IncreasePressure(fragment.PressureAffection);
            }
            else if (fragment.Type == FragmentType.CoolingFragment)
            {
                SelectedCore.DecreasePressure(fragment.PressureAffection);
            }

            Console.WriteLine($"Successfully attached Fragment {nameFragment} to Core {SelectedCore.CoreName}!");
        }

        public void DetachFragment()
        {
            if (SelectedCore == null || SelectedCore.Fragments.Count == 0)
            {
                throw new FailedDetachException();
            }

            Fragment fragmentToRemove = SelectedCore.Fragments.ElementAt(SelectedCore.Fragments.Count - 1);
            SelectedCore.IncreasePressure(fragmentToRemove.PressureAffection);
            SelectedCore.Fragments.RemoveAt(SelectedCore.Fragments.Count - 1);

            Console.WriteLine($"Successfully detached Fragment {fragmentToRemove.Name} from Core {SelectedCore.CoreName}!");
        }

        public override string ToString()
        {
            return "Lambda Core Power Plant Status:\n" + $"Total Durability: {cores.Sum(c => c.Durability)}\n"
                    + $"Total Cores: {cores.Count}\n" + $"Total Fragments: {cores.Sum(c => c.Fragments.Count)}\n"
                    + string.Join("", cores);
        }
    }
}
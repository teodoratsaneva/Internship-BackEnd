using System;

namespace LambdaCore
{
        public class Program
    {
        static void Main(string[] args)
        {
            Core core1 = new Core(TypeCore.SystemCore, 'A', 100);
            Fragment nuclearFragment1 = new Fragment(FragmentType.NuclearFragment, "N1", 10);
            Fragment coolingFragment1 = new Fragment(FragmentType.CoolingFragment, "C1", 5);

            core1.AddFragment(nuclearFragment1);
            core1.AddFragment(coolingFragment1);

            core1.RemoveFragment(nuclearFragment1);
            
            core1.UpdatePressure();

            Console.WriteLine(core1.ToString());
        }
    }
}
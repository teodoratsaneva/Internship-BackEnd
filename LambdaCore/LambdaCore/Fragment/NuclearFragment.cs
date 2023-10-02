using System;

namespace LambdaCore
{
    public class NuclearFragment : Fragment
    {
        public NuclearFragment(FragmentType type, string name, int pressureAffection) : base(type, name, pressureAffection)
        {
        }
        public override int CalculatePressureAffection(int value)
        {
            return value * 2;
        }
    }
}
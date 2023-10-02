using System;

namespace LambdaCore
{
    public class CoolingFragment : Fragment
    {
        public CoolingFragment(FragmentType type, string name, int pressureAffection) : base(type, name, pressureAffection)
        {
        }
        public override int CalculatePressureAffection(int value)
        {
            return value * 3;
        }
    }
}
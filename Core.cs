using System;
using System.Runtime.InteropServices;

namespace LambdaCore
{

    public enum TypeCore
    {
        SystemCore,
        ParaCore
    }

    public class Core
    {
        public TypeCore type;
        private char coreName;
        private int durability;
        public List<Fragment> fragments = new List<Fragment>();

        public int Durability
        {
            get { return durability; }
            set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Durability cannotbe negative");
                }

                if (Type == TypeCore.SystemCore)
                {
                    durability = value;
                }
                else if (Type == TypeCore.ParaCore)
                {
                    durability = value / 3;
                }
                else
                {
                    throw new InvalidOperationException("Invaild Operation");
                }
            }
        }

        public TypeCore Type
        {
            get { return type; }
            set
            {
                if (value != TypeCore.ParaCore && value != TypeCore.SystemCore)
                {
                    throw new InvalidOperationException("Incorrect type of core");
                }

                type = value;
            }
        }

        public char CoreName
        {
            get { return coreName; }
            set
            {
                if (value >= 'A' && value <= 'Z')
                {
                    coreName = value;
                }
                else
                {
                    throw new InvalidOperationException("Name must be capital letter");
                }
            }
        }

        public Core()
        {
            Type = TypeCore.SystemCore;
        }

        public Core(TypeCore type, char coreName, int durability)
        {
            Type = type;
            CoreName = coreName;
            Durability = durability;
        }

        public void AddFragment(Fragment fragment)
        {
            fragments.Add(fragment);
        }

        public void RemoveFragment(Fragment fragment)
        {
            fragments.Remove(fragment);
        }

        public void UpdatePressure()
        {
            int pressure = 0;

            foreach (var fragment in fragments)
            {
                if (fragment.Type == FragmentType.CoolingFragment)
                    pressure -= fragment.PressureAffection;
                else if (fragment.Type == FragmentType.NuclearFragment)
                    pressure += fragment.PressureAffection;
            }

            if (pressure > 0)
            {
                Durability -= pressure;
            }
            else
            {
                Durability += Math.Abs(pressure);
            }
        }

        public override string ToString()
        {
            return coreName.ToString() + " " + type.ToString() + " " + durability.ToString() + " " + string.Join(" ", fragments);
        }
    }
}
using System;
using System.Dynamic;
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
        private string coreName;
        private int durability;
        private List<Fragment> fragments = new List<Fragment>();

        private bool isCritical = false;

        public bool IsCritical
        {
            get { return isCritical; }
            set { isCritical = value; }
        }

        public int Durability
        {
            get { return durability; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
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
                    throw new ArgumentException();
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
                    throw new ArgumentException();
                }

                type = value;
            }
        }

        public List<Fragment> Fragments
        {
            get { return fragments; }
            set { fragments = value; }
        }

        public string CoreName
        {
            get { return coreName; }
            set
            {
                if (String.Compare(value, "A") >= 0 && String.Compare(value, "Z") <= 0)
                {
                    coreName = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public Core()
        {
            Type = TypeCore.SystemCore;
        }

        public Core(TypeCore type, string coreName, int durability)
        {
            try
            {
                Type = type;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Incorrect type of core");
            }

            try
            {
                CoreName = coreName;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Name must be capital letter");
            }

            try
            {
                Durability = durability;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Incorrect operation");
            }
        }

        public void AddFragment(Fragment fragment)
        {
            fragments.Add(fragment);
        }

        public void RemoveFragment(Fragment fragment)
        {
            fragments.Remove(fragment);
        }

        // public void UpdatePressure()
        // {
        //     int pressure = 0;

        //     foreach (var fragment in fragments)
        //     {
        //         if (fragment.Type == FragmentType.CoolingFragment)
        //             pressure -= fragment.PressureAffection;
        //         else if (fragment.Type == FragmentType.NuclearFragment)
        //             pressure += fragment.PressureAffection;
        //     }

        //     if (pressure > 0)
        //     {
        //         Durability -= pressure;
        //     }
        //     else
        //     {
        //         Durability += Math.Abs(pressure);
        //     }

        //     if (Durability <= 0)
        //     {
        //         IsCritical = true;
        //     }
        // }

        public void IncreasePressure(int value)
        {
            int pressure = 0; 
            pressure += value;
            if (pressure > 0)
            {
                Durability -= pressure;
                if (Durability <= 0)
                {
                    IsCritical = true;
                }
            }
        }

        public void DecreasePressure(int value)
        {
            int pressure = 0;
            pressure -= value;
            if (pressure < 0)
            {
                pressure = 0;
            }
            if (Durability <= 0)
            {
                IsCritical = true;
            }
        }

        public override string ToString()
        {
            return coreName.ToString() + " " + type.ToString() + " " + durability.ToString() + " " + string.Join(" ", fragments);
        }
    }
}
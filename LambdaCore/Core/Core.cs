using System;
using System.Dynamic;
using System.Runtime.InteropServices;

namespace LambdaCore
{
    public abstract class Core
    {
        private TypeCore type;
        private string coreName;
        private int durability;
        private List<Fragment> fragments = new List<Fragment>();

        private bool isCritical = false;

        public bool IsCritical
        {
            get { return isCritical; }
            private set { isCritical = value; }
        }

        public int Durability
        {
            get { return durability; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidDurabilityOfCoreException();
                }

                durability = CalculateDurability(value);
            }
        }

        public abstract int CalculateDurability(int value);

        public TypeCore Type
        {
            get { return type; }
            private set
            {
                if (value != TypeCore.ParaCore && value != TypeCore.SystemCore)
                {
                    throw new InvalidCoreTypeException();
                }

                type = value;
            }
        }

        public List<Fragment> Fragments
        {
            get { return fragments; }
            private set { fragments = value; }
        }

        public string CoreName
        {
            get { return coreName; }
            private set
            {
                if (String.Compare(value, "A") <= 0 && String.Compare(value, "Z") >= 0)
                {
                    throw new InvalidCoreNameException();
                }
                
                coreName = value;
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
                CoreName = coreName;
                Durability = durability;
            }
            catch(InvalidDurabilityOfCoreException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(InvalidCoreTypeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(InvalidCoreNameException e)
            {
                Console.WriteLine(e.Message);
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
            return $"Core {CoreName}\n" + $"####Durability: {Durability}\n" + $"####Status: {(IsCritical ? "CRITICAL" : "NORMAL")}\n";
        }

    }
}
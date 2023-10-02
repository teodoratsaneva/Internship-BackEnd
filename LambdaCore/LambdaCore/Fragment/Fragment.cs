
using System;
using Microsoft.VisualBasic;

namespace LambdaCore 
{
    public abstract class Fragment
    {
        private FragmentType type;
        public string Name { get; set; }
        private int pressureAffection;

        public int PressureAffection
        {
            get { return pressureAffection; }
            private set
            {
                if(value < 0)
                {
                    throw new InvalidPressureAffectionOfFragmentException();
                }
                
                pressureAffection = CalculatePressureAffection(value);
            }
        }

        public abstract int CalculatePressureAffection(int value);

        public FragmentType Type
        {
            get { return type; }
            private set
            {
                if (value != FragmentType.CoolingFragment && value != FragmentType.NuclearFragment)
                {
                    throw new InvalidFragmentTypeException();
                }

                type = value;
            }
        }

        public Fragment(FragmentType type, string name, int pressureAffection)
        {
            try
            {
                Type = type;
                Name = name;
                PressureAffection = pressureAffection;
            }
            catch(InvalidFragmentTypeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(InvalidPressureAffectionOfFragmentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override string ToString()
        {
            return Type.ToString() + " " + Name.ToString() + " " + pressureAffection.ToString();
        }
    }
}
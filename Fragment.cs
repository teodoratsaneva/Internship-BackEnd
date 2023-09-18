
using System;
using Microsoft.VisualBasic;

namespace LambdaCore 
{
    public enum FragmentType
    {
        NuclearFragment,
        CoolingFragment
    }

    public class Fragment
    {
        public FragmentType type;
        public string Name { get; set; }
        private int pressureAffection;

        public int PressureAffection
        {
            get { return pressureAffection; }
            set
            {
                if(value < 0)
                {
                    throw new InvalidOperationException("Pressure affection cannot be negative");
                }

                if (Type == FragmentType.NuclearFragment)
                {
                    pressureAffection = value * 2;
                }
                else if (Type == FragmentType.CoolingFragment)
                {
                    pressureAffection = value * 3;
                }
                else
                {
                    throw new InvalidOperationException("Invalid operation");
                }
            }
        }

        public FragmentType Type
        {
            get { return type; }
            set
            {
                if (value != FragmentType.CoolingFragment && value != FragmentType.NuclearFragment)
                {
                    throw new InvalidOperationException("Incorrect type of fragment");
                }

                type = value;
            }
        }

        public Fragment()
        {
            Type = FragmentType.NuclearFragment;
        }

        public Fragment(FragmentType type, string name, int pressureAffection)
        {
            Type = type;
            Name = name;
            PressureAffection = pressureAffection;
        }

        public override string ToString()
        {
            return Type.ToString() + " " + Name.ToString() + " " + pressureAffection.ToString();
        }
    }
}
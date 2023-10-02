using System;

namespace LambdaCore
{
    public class ParaCore : Core
    {
        public ParaCore(TypeCore type, string coreName, int durability) : base(type, coreName, durability)
        {
        }
        public override int CalculateDurability(int initialValue)
        {
            return initialValue / 3;
        }
    }
}
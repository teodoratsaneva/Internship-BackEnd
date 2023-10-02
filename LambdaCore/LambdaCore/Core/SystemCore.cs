using System;

namespace LambdaCore
{
    public class SystemCore : Core
    {
        public SystemCore(TypeCore type, string coreName, int durability) : base(type, coreName, durability)
        {
        }
        public override int CalculateDurability(int value)
        {
            return value;
        }
    }
}
using System;

namespace LambdaCore
{
    public class InvalidCoreOperationException : Exception
    {
        public InvalidCoreOperationException() : base("Invalid core")
        {
        }
    }

    public class InvalidCoreTypeException : Exception
    {
        public InvalidCoreTypeException() : base("Incorrect type of core")
        {
        }
    }

    public class InvalidCoreNameException : Exception
    {
        public InvalidCoreNameException() : base("Incorrect name of core")
        {
        }
    }

    public class InvalidDurabilityOfCoreException : Exception
    {
        public InvalidDurabilityOfCoreException() : base("Incorrec durability of core")
        {

        }
    }

    public class FailedCreateCoreExeption : Exception
    {
        public FailedCreateCoreExeption() : base("Failed to create Core!")
        {
        }
    }

    public class FailedFindCoreException : Exception
    {
    }
}

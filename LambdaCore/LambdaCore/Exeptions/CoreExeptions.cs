using System;

namespace LambdaCore
{
    public class InvalidCoreOperationException : Exception
    {
        public InvalidCoreOperationException() : base()
        {
        }

        public InvalidCoreOperationException(string message) : base(message)
        {
        }

        public static InvalidCoreOperationException CreateInvalidCoreException()
        {
            return new InvalidCoreOperationException("Invalid core");
        }
    }

    public class InvalidCoreTypeException : Exception
    {
        public InvalidCoreTypeException() : base()
        {
        }

        public InvalidCoreTypeException(string message) : base(message)
        {
        }

        public static InvalidCoreTypeException CreateInvalidCoreTypeException()
        {
            return new InvalidCoreTypeException("Incorrect type of core");
        }
    }

    public class InvalidCoreNameException : Exception
    {
        public InvalidCoreNameException() : base()
        {
        }

        public InvalidCoreNameException(string message) : base(message)
        {
        }

        public static InvalidCoreNameException CreateInvalidCoreNameException()
        {
            return new InvalidCoreNameException("Incorrect name of core");
        }
    }

    public class InvalidDurabilityOfCoreException : Exception
    {
        public InvalidDurabilityOfCoreException() : base()
        {
        }

        public InvalidDurabilityOfCoreException(string message) : base(message)
        {
        }

        public static InvalidDurabilityOfCoreException CreateInvalidDurabilityException()
        {
            return new InvalidDurabilityOfCoreException("Incorrect durability of core");
        }
    }

    public class FailedCreateCoreException : Exception
    {
        public FailedCreateCoreException() : base()
        {
        }

        public FailedCreateCoreException(string message) : base(message)
        {
        }

        public static FailedCreateCoreException CreateFailedCreateCoreException()
        {
            return new FailedCreateCoreException("Failed to create Core!");
        }
    }

    public class FailedFindCoreException : Exception
    {
        public FailedFindCoreException() : base()
        {
        }

        public FailedFindCoreException(string message) : base(message)
        {
        }

        public static FailedFindCoreException CreateFailedFindCoreException()
        {
            return new FailedFindCoreException("Failed to find core!");
        }
    }
}

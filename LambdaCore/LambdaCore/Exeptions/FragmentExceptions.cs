using System;

namespace LambdaCore
{
    public class InvalidFragmentTypeException : Exception
    {
        public InvalidFragmentTypeException() : base()
        {
        }

        public InvalidFragmentTypeException(string message) : base(message)
        {
        }

        public static InvalidFragmentTypeException CreateInvalidFragmentTypeException()
        {
            return new InvalidFragmentTypeException("Incorrect type of fragment");
        }
    }

    public class InvalidPressureAffectionOfFragmentException : Exception
    {
        public InvalidPressureAffectionOfFragmentException() : base()
        {
        }

        public InvalidPressureAffectionOfFragmentException(string message) : base(message)
        {
        }

        public static InvalidPressureAffectionOfFragmentException CreateInvalidPressureAffectionException()
        {
            return new InvalidPressureAffectionOfFragmentException("Invalid pressure affection of fragment");
        }
    }

    public class FailedDetachException : Exception
    {
        public FailedDetachException() : base()
        {
        }

        public FailedDetachException(string message) : base(message)
        {
        }

        public static FailedDetachException CreateFailedDetachException()
        {
            return new FailedDetachException("Failed to detach Fragment!");
        }
    }

    public class FailedAttachException : Exception
    {
        public FailedAttachException() : base()
        {
        }

        public FailedAttachException(string message) : base(message)
        {
        }

        public static FailedAttachException CreateFailedAttachException()
        {
            return new FailedAttachException("Failed to attach Fragment!");
        }
    }
}

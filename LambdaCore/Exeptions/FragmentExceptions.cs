using System;

namespace LambdaCore
{
     public class InvalidFragmentTypeException : Exception
    {
        public InvalidFragmentTypeException() : base("Incorrect type of fragment")
        {
        }
    }

    public class InvalidPressureAffectionOfFragmentException : Exception
    {
        public InvalidPressureAffectionOfFragmentException() : base("Invalid pressure affection of fragment")
        {
        }
    }

    public class FailedDetachExeption : Exception
    {
        public FailedDetachExeption() : base("Failed to detach Fragment!")
        {
        }
    }

    public class FailedAttachExeption : Exception
    {
    }
}
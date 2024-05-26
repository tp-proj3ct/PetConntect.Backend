﻿namespace PetConnect.Backend.Packages.UseCases;

public class AppException : Exception
{
    ///<inheritdoc/>
    public AppException()
    {
    }

    ///<inheritdoc/>
    public AppException(string? message) : base(message)
    {
    }

    ///<inheritdoc/>
    public AppException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

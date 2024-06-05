namespace PetConnect.Backend.Core.Abstractions;

public enum Status
{
    PendingConfirmation,
    PendingPayment,
    PendingAssignment,
    InProgress,
    Completed,
    Cancelled
}
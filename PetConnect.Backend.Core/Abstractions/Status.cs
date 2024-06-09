namespace PetConnect.Backend.Core.Abstractions;

/// <summary>
/// Статус заказа
/// </summary>
public enum Status
{
    PendingConfirmation,
    PendingPayment,
    PendingAssignment,
    InProgress,
    Completed,
    Cancelled
}
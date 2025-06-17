using DevSource.Stack.Notifications.Abstractions;
using System.Collections.Generic;

namespace DevSource.Stack.Notifications.Interfaces;

/// <summary>
/// Defines the contract for an exception handler.
/// </summary>
public interface IExceptionHandler
{
    /// <summary>
    /// Gets the list of domain exceptions.
    /// </summary>
    IReadOnlyCollection<DomainException> DomainExceptions { get; }

    /// <summary>
    /// Publishes a single domain exception.
    /// </summary>
    /// <param name="exception">The domain exception to publish.</param>
    void PublishException(DomainException exception);

    /// <summary>
    /// Publishes a collection of domain exceptions.
    /// </summary>
    /// <param name="exceptions">The collection of domain exceptions to publish.</param>
    void PublishException(IEnumerable<DomainException> exceptions);

    /// <summary>
    /// Publishes domain exceptions from another IException instance.
    /// </summary>
    /// <param name="exceptionHandler">The IException instance from which to publish exceptions.</param>
    void PublishException(IException exceptionHandler);

    /// <summary>
    /// Gets a value indicating whether there are any exceptions present.
    /// </summary>
    bool HasExceptions { get; }

    /// <summary>
    /// Throws the collected exceptions.
    /// If only one exception is present, it's thrown directly.
    /// If multiple exceptions are present, they are thrown as an AggregateException.
    /// </summary>
    /// <param name="clearExceptionsAfterThrowing">Whether to clear the exception list after throwing.</param>
    void ThrowCollectedExceptions(bool clearExceptionsAfterThrowing = true);

    /// <summary>
    /// Clears all collected exceptions.
    /// </summary>
    void ClearExceptions();
}

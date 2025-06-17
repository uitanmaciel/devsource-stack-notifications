using System;

namespace DevSource.Stack.Notifications;

/// <summary>
/// Represents a contract for handling exceptions in the system.
/// </summary>
[Obsolete("Use IExceptionHandler instead.")]
public interface IException
{
    /// <summary>
    /// Gets a read-only collection of <see cref="DomainException"/> instances.
    /// </summary>
    IReadOnlyCollection<DomainException> DomainExceptions { get; }
    
    /// <summary>
    /// Publishes an exception with a specified message.
    /// </summary>
    /// <param name="message">The message that describes the exception.</param>
    void PublishException(string message);
    
    /// <summary>
    /// Publishes an exception with a specified key and message.
    /// </summary>
    /// <param name="key">The key associated with the exception.</param>
    /// <param name="message">The message that describes the exception.</param>
    void PublishException(string key, string message);
    
    /// <summary>
    /// Publishes an exception with a formatted message and optional arguments.
    /// </summary>
    /// <param name="message">The message that describes the exception. It can contain formatting placeholders.</param>
    /// <param name="args">An array of objects to format into the message.</param>
    void PublishException(string message, params object[] args);
    
    /// <summary>
    /// Publishes an exception with a formatted message and optional arguments.
    /// </summary>
    /// <param name="key">The key associated with the exception.</param>
    /// <param name="message">The message that describes the exception. It can contain formatting placeholders.</param>
    /// <param name="args">An array of objects to format into the message.</param>
    void PublishException(string key, string message, params object[] args);
    
    /// <summary>
    /// Publishes an exception using the provided arguments, formatted into a message.
    /// </summary>
    /// <param name="args">An array of objects to be formatted into the exception message.</param>
    void PublishException(params object[] args);
    
    /// <summary>
    /// Publishes the specified <see cref="DomainException"/>.
    /// </summary>
    /// <param name="exception">The <see cref="DomainException"/> to be published.</param>
    void PublishException(DomainException exception);
    
    /// <summary>
    /// Publishes all exceptions from the specified <see cref="Notifier"/>.
    /// </summary>
    /// <param name="notifier">The <see cref="Notifier"/> containing the exceptions to be published.</param>
    void PublishExceptions(Notifier notifier);

    /// <summary>
    /// Gets a value indicating whether there are any exceptions present.
    /// </summary>
    [Obsolete("Use IExceptionHandler instead.")]
    bool HasExceptions { get; }

    /// <summary>
    /// Throws the collected exceptions.
    /// If only one exception is present, it's thrown directly.
    /// If multiple exceptions are present, they are thrown as an AggregateException.
    /// </summary>
    /// <param name="clearExceptionsAfterThrowing">Whether to clear the exception list after throwing.</param>
    [Obsolete("Use IExceptionHandler instead.")]
    void ThrowCollectedExceptions(bool clearExceptionsAfterThrowing = true);

    /// <summary>
    /// Clears all collected exceptions.
    /// </summary>
    [Obsolete("Use IExceptionHandler instead.")]
    void ClearExceptions();
}
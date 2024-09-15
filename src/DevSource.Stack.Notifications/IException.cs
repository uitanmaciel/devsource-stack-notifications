namespace DevSource.Stack.Notifications;

/// <summary>
/// Represents a contract for handling exceptions in the system.
/// </summary>
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
}
namespace DevSource.Stack.Notifications;

/// <summary>
/// Represents errors that occur during domain operations. Inherits from the <see cref="Exception"/> class.
/// </summary>
public class DomainException : Exception
{
    /// <summary>
    /// Gets or sets the key associated with the exception.
    /// </summary>
    public string Key { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the message associated with the exception.
    /// </summary>
    public override string Message { get; } = null!;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified key and message.
    /// </summary>
    /// <param name="key">The key associated with the exception.</param>
    /// <param name="message">The message that describes the exception.</param>
    public DomainException(string key, string message) : base(message)
    {
        Key = key;
        Message = message;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a specified key, message, and format arguments.
    /// </summary>
    /// <param name="key">The key associated with the exception.</param>
    /// <param name="message">The message that describes the exception. It can contain formatting placeholders.</param>
    /// <param name="args">An array of objects to format into the message.</param>
    public DomainException(string key, string message, params object[] args) : base(message)
    {
        Key = key;
        Message = string.Format(message, args);
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a formatted message and arguments.
    /// </summary>
    /// <param name="message">The message that describes the exception. It can contain formatting placeholders.</param>
    /// <param name="args">An array of objects to format into the message.</param>
    public DomainException(string message, params object[] args) : base(message)
        => Message = string.Format(message, args);
    
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainException"/> class with a formatted message using the provided arguments.
    /// </summary>
    /// <param name="args">An array of objects to be formatted into the message.</param>
    public DomainException(params object[] args)
        => Message = string.Format("{0}", args);
}
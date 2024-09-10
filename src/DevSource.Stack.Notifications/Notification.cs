namespace DevSource.Stack.Notifications;

/// <summary>
/// Represents a notification that contains a key and a message.
/// </summary>
public class Notification
{
    /// <summary>
    /// Gets or sets the key associated with the notification.
    /// </summary>
    public string Key { get; set; } = null!;
    
    /// <summary>
    /// Gets or sets the message associated with the notification.
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Notification"/> class with a specified key and message.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message associated with the notification.</param>
    public Notification(string key, string message)
    {
        Key = key;
        Message = message;
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Notification"/> class with a specified key, message, and format arguments.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message associated with the notification.</param>
    /// <param name="args">An array of objects to format into the message.</param>
    public Notification(string key, string message, params object[] args)
    {
        Key = key;
        Message = string.Format(message, args);
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Notification"/> class with a formatted message.
    /// </summary>
    /// <param name="message">The message format string.</param>
    /// <param name="args">An array of objects to format into the message.</param>
    public Notification(string message, params object[] args)
        => Message = string.Format(message, args);
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Notification"/> class with a formatted message from the arguments.
    /// </summary>
    /// <param name="args">An array of objects to format into the message.</param>
    public Notification(params object[] args) 
        => Message = string.Format("{0}", args);
    
    /// <summary>
    /// Returns the message associated with the notification as a string.
    /// </summary>
    /// <returns>The message associated with the notification.</returns>
    public override string ToString() => $"{Message}";
}
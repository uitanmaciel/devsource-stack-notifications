namespace DevSource.Stack.Notifications;

/// <summary>
/// Abstract base class that provides notification management functionality.
/// Implements the <see cref="INotifications"/> interface.
/// </summary>
public abstract class Notifier : INotifications, IException
{
    /// <summary>
    /// A list to store the notifications.
    /// </summary>
    private readonly List<Notification> _notifications = [];
    
    /// <summary>
    /// Gets a read-only collection of notifications.
    /// </summary>
    public IReadOnlyCollection<Notification> Notifications => _notifications;
    
    /// <summary>
    /// Gets a value indicating whether there are any notifications present.
    /// </summary>
    public bool HasNotifications => _notifications.Any();

    /// <summary>
    /// Adds a notification to the system with a specific key and message.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message content of the notification.</param>
    public void AddNotification(string key, string message)
        => AddNotification(new Notification(key, message));
    
    /// <summary>
    /// Adds a notification to the system with just a message, no key.
    /// </summary>
    /// <param name="message">The message content of the notification.</param>
    public void AddNotification(string message)
        => AddNotification(new Notification(message));

    /// <summary>
    /// Adds a notification to the system with a specific key, message, and optional format arguments.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message content of the notification.</param>
    /// <param name="args">Optional format arguments to be included in the message.</param>
    public void AddNotification(string key, string message, params object[] args)
        => AddNotification(new Notification(key, message, args));

    /// <summary>
    /// Adds a notification to the system with a message and optional format arguments.
    /// </summary>
    /// <param name="message">The message content of the notification.</param>
    /// <param name="args">Optional format arguments to be included in the message.</param>
    public void AddNotification(string message, params object[] args)
        => AddNotification(new Notification(message, args));

    /// <summary>
    /// Adds a notification to the system with optional format arguments.
    /// </summary>
    /// <param name="args">Optional format arguments to be included in the message.</param>
    public void AddNotification(params object[] args)
        => AddNotification(new Notification(args));

    /// <summary>
    /// Adds a notification to the system.
    /// </summary>
    /// <param name="notification">The notification to be added.</param>
    public void AddNotification(Notification notification)
        => _notifications.Add(notification);

    /// <summary>
    /// Adds all notifications from another notifier to the system.
    /// </summary>
    /// <param name="notifier">The notifier containing the notifications to add.</param>
    public void AddNotifications(Notifier notifier)
        => AddNotifications(notifier.Notifications);

    /// <summary>
    /// Adds a collection of notifications to the system.
    /// </summary>
    /// <param name="notifications">The collection of notifications to add.</param>
    public void AddNotifications(IEnumerable<Notification> notifications)
        => _notifications.AddRange(notifications);

    /// <summary>
    /// Clears all the current notifications.
    /// This method is used to remove all notifications that have been processed or are no longer relevant.
    /// </summary>
    public void ClearNotifications()
        => _notifications.Clear();
    
    private readonly List<DomainException> _domainExceptions = [];
    
    /// <summary>
    /// Gets a read-only collection of <see cref="DomainException"/> instances.
    /// </summary>
    public IReadOnlyCollection<DomainException> DomainExceptions  => _domainExceptions;
    
    /// <summary>
    /// Publishes an exception with a specified message.
    /// </summary>
    /// <param name="message">The message that describes the exception.</param>
    public void PublishException(string message)
        => PublishException(new DomainException(message));
    
    /// <summary>
    /// Publishes an exception with a specified key and message.
    /// </summary>
    /// <param name="key">The key associated with the exception.</param>
    /// <param name="message">The message that describes the exception.</param>
    public void PublishException(string key, string message)
        => PublishException(new DomainException(key, message));
    
    /// <summary>
    /// Publishes an exception with a formatted message and optional arguments.
    /// </summary>
    /// <param name="message">The message that describes the exception. It can contain formatting placeholders.</param>
    /// <param name="args">An array of objects to format into the message.</param>
    public void PublishException(string message, params object[] args)
        => PublishException(new DomainException(message, args));
    
    /// <summary>
    /// Publishes an exception with a formatted message and optional arguments.
    /// </summary>
    /// <param name="key">The key associated with the exception.</param>
    /// <param name="message">The message that describes the exception. It can contain formatting placeholders.</param>
    /// <param name="args">An array of objects to format into the message.</param>
    public void PublishException(string key, string message, params object[] args)
        => PublishException(new DomainException(key, message, args));
    
    /// <summary>
    /// Publishes an exception using the provided arguments, formatted into a message.
    /// </summary>
    /// <param name="args">An array of objects to be formatted into the exception message.</param>
    public void PublishException(params object[] args)
        => PublishException(new DomainException(args));

    /// <summary>
    /// Publishes the specified <see cref="DomainException"/>.
    /// </summary>
    /// <param name="exception">The <see cref="DomainException"/> to be published.</param>
    public void PublishException(DomainException exception)
    {
        _domainExceptions.Add(exception);
        throw exception;
    }
    
    /// <summary>
    /// Publishes all domain exceptions from the specified <see cref="Notifier"/> by invoking the <c>PublishException</c> method on each exception.
    /// </summary>
    /// <param name="notifier">The <see cref="Notifier"/> containing the domain exceptions to be published.</param>
    public void PublishExceptions(Notifier notifier)
    {
        foreach (var exception in notifier.DomainExceptions)
            PublishException(exception);
    }
}
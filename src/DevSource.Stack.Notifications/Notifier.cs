namespace DevSource.Stack.Notifications;

public abstract class Notifier : INotifications
{
    private readonly List<Notification> _notifications = new();
    public IReadOnlyCollection<Notification> Notifications => _notifications;
    public bool HasNotifications => _notifications.Any();

    /// <summary>
    /// Adds a notification to the system with a specific key and message.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message content of the notification.</param>
    public void AddNotification(string key, string message)
        => AddNotification(new Notification(key, message));

    /// Adds a notification to the system with just a message, no key.
    /// </summary>
    /// <param name="message">The message content of the notification.</param>
    public void AddNotification(string message)
        => AddNotification(new Notification(message));

    /// <summary>
    /// Adds a notification to the system with a specific key and message.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message content of the notification.</param>
    public void AddNotification(string key, string message, params object[] args)
        => AddNotification(new Notification(key, message, args));

    /// <summary>
    /// Adds a notification to the system with a specific key and message.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message content of the notification.</param>
    public void AddNotification(string message, params object[] args)
        => AddNotification(new Notification(message, args));

    /// <summary>
    /// Adds a notification to the system with a specific key and message.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message content of the notification.</param>
    public void AddNotification(params object[] args)
        => AddNotification(new Notification(args));

    /// <summary>
    /// Adds a notification to the system with a specific key and message.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message content of the notification.</param>
    public void AddNotification(Notification notification)
        => _notifications.Add(notification);

    /// <summary>
    /// Adds a collection of notifications to the system.
    /// </summary>
    /// <param name="notifications">The collection of notifications to add.</param>
    public void AddNotifications(Notifier notifier)
        => AddNotifications(notifier.Notifications);

    /// <summary>
    /// Adds a notification to the system with a specific key and message.
    /// </summary>
    /// <param name="key">The key associated with the notification.</param>
    /// <param name="message">The message content of the notification.</param>
    public void AddNotifications(IEnumerable<Notification> notifications)
        => _notifications.AddRange(notifications);

    /// <summary>
    /// Clears all the current notifications.
    /// This method is used to remove all notifications that have been processed or are no longer relevant.
    /// </summary>
    public void ClearNotifications()
        => _notifications.Clear();
}
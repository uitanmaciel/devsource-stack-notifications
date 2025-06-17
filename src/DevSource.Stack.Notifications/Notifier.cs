using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DevSource.Stack.Notifications;

/// <summary>
/// Abstract base class that provides notification management functionality.
/// Implements the <see cref="INotifications"/> interface.
/// </summary>
public abstract class Notifier : INotifications
{
    /// <summary>
    /// A list to store the notifications.
    /// </summary>
    private readonly List<Notification> _notifications = [];
    
    /// <summary>
    /// Gets a read-only collection of notifications.
    /// </summary>
    [JsonIgnore]
    [NotMapped]
    public IReadOnlyCollection<Notification> Notifications => _notifications;
    
    /// <summary>
    /// Gets a value indicating whether there are any notifications present.
    /// </summary>
    [JsonIgnore]
    [NotMapped]
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
}
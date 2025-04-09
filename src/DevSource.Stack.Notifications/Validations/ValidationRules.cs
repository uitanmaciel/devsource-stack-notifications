﻿namespace DevSource.Stack.Notifications.Validations;

/// <summary>
/// A class that provides validation rules for objects of type <typeparamref name="T"/>. 
/// Inherits from <see cref="Notifier"/> to support notification management.
/// </summary>
/// <typeparam name="T">The type of object to validate.</typeparam>
public partial class ValidationRules<T> : Notifier
{
    /// <summary>
    /// Placeholder for a method that ensures a value is required.
    /// </summary>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/>.</returns>
    public ValidationRules<T> IsRequired(string key)
    {
        if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
            AddNotification(new Notification(key, Error.IsRequired(key)));
        return this;
    }

    /// <summary>
    /// Joins notifications from other notifiers to the current instance.
    /// </summary>
    /// <param name="notifiers">An array of notifiers whose notifications will be added to this instance.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after adding the notifications.</returns>
    public ValidationRules<T> Join(params Notifier[]? notifiers)
    {
        if (notifiers is null) return this;
        foreach (var notifier in notifiers)
            AddNotifications(notifier.Notifications);
        return this;
    }

    /// <summary>
    /// Retrieves the key name for a given key.
    /// </summary>
    /// <param name="key">The key for which the name is to be retrieved.</param>
    /// <returns>The name of the key.</returns>
    private string KeyName(string key)
        => nameof(key);
}
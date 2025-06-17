namespace DevSource.Stack.Notifications.Validations;

/// <summary>
/// A class that provides validation rules for objects of type <typeparamref name="T"/>. 
/// Inherits from <see cref="Notifier"/> to support notification management.
/// </summary>
/// <typeparam name="T">The type of object to validate.</typeparam>
public partial class ValidationRules<T> : Notifier
{
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
}
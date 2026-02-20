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
    public ValidationRules<T> Join(params INotifications[]? notifiers)
    {
        if (notifiers is null) return this;
        foreach (var notifier in notifiers)
            AddNotifications(notifier.Notifications);
        return this;
    }

    /// <summary>
    /// Executes validation only if the specified condition is true.
    /// </summary>
    /// <param name="condition">The condition that determines whether validations should be executed.</param>
    /// <param name="validations">The validation actions to be executed if the condition is true.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the conditional validation.</returns>
    public ValidationRules<T> When(bool condition, Action<ValidationRules<T>> validations)
    {
        if (condition)
            validations(this);
        
        return this;
    }

    /// <summary>
    /// Executes validation only if the specified condition function returns true.
    /// </summary>
    /// <param name="condition">A function that returns a boolean indicating whether validations should be executed.</param>
    /// <param name="validations">The validation actions to be executed if the condition is true.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the conditional validation.</returns>
    public ValidationRules<T> When(Func<bool> condition, Action<ValidationRules<T>> validations)
    {
        if (condition())
            validations(this);
        
        return this;
    }

    /// <summary>
    /// Validates that at least one of the provided values is not null.
    /// </summary>
    /// <param name="values">Array of values to check.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> RequireAtLeastOne(params object?[] values)
    {
        if (values == null || values.Length == 0 || values.All(v => v == null || (v is string str && string.IsNullOrEmpty(str))))
            AddNotification(new Notification(Error.RequireAtLeastOne()));
        
        return this;
    }

    /// <summary>
    /// Validates that all provided values are null or all are not null (no partial state).
    /// </summary>
    /// <param name="values">Array of values to check.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> AllOrNone(params object?[] values)
    {
        if (values == null || values.Length == 0)
            return this;
            
        var nullCount = values.Count(v => v == null || (v is string str && string.IsNullOrEmpty(str)));
        
        if (nullCount != 0 && nullCount != values.Length)
            AddNotification(new Notification(Error.AllOrNone()));
        
        return this;
    }    

    private ValidationRules<T> IfInvalid(bool condition, string key, string message)
    {
        if (condition)
            AddNotification(new Notification(key, message));

        return this;
    }

    private static bool IsMissing(string? value)
        => string.IsNullOrWhiteSpace(value);

    private ValidationRules<T> Notify(string key, string? message = null)
    {
        AddNotification(new Notification(key, message!));
        return this;
    }

    private static string OnlyDigits(string value)
        => new([.. value.Where(char.IsDigit).ToArray()]);
}
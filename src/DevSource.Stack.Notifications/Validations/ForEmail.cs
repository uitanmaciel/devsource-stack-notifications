using System.Text.RegularExpressions;

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates that the specified key corresponds to a valid email address.
    /// If the key is null or empty, or if it doesn't match the email pattern, a notification is added.
    /// </summary>
    /// <param name="key">The key representing the email field in the object being validated.</param>
    /// <param name="value">The value of the email field in the object being validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsEmail(string key, string value)
    {
        if (!EmailRegex().IsMatch(key))
            AddNotification(new Notification(Error.Email(value)));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key corresponds to a valid email address, with a custom error message.
    /// If the key is null or empty, or if it doesn't match the email pattern, a custom notification is added.
    /// </summary>
    /// <param name="key">The key representing the email field in the object being validated.</param>
    /// <param name="value">The value of the email field in the object being validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsEmail(string key, string value, string message)
    {
        if (!EmailRegex().IsMatch(value))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    [GeneratedRegex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
    private static partial Regex EmailRegex();
}
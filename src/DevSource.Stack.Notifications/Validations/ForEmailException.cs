using DevSource.Stack.Notifications.Abstractions; // Required for DomainException
using DevSource.Stack.Notifications.Validations.Internal; // Added this
using System; // For Func/Action
using System.Text.RegularExpressions;

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRulesException<T>
{
    /// <summary>
    /// Validates that the specified key corresponds to a valid email address.
    /// If the key is null or empty, or if it doesn't match the email pattern, a notification is added.
    /// </summary>
    /// <param name="key">The key representing the email field in the object being validated.</param>
    /// <param name="value">The value of the email field in the object being validated.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsEmail(string key, string value)
    {
        ValidationRuleRunners.IsEmail(
            value,
            key,
            Error.Email(value), // This is the pre-formatted error message
            EmailRegex().IsMatch,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified key corresponds to a valid email address, with a custom error message.
    /// If the key is null or empty, or if it doesn't match the email pattern, a custom notification is added.
    /// </summary>
    /// <param name="key">The key representing the email field in the object being validated.</param>
    /// <param name="value">The value of the email field in the object being validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsEmail(string key, string value, string message)
    {
        ValidationRuleRunners.IsEmail(
            value,
            key,
            message, // This is already a custom message
            EmailRegex().IsMatch,
            null,
            this.PublishException,
            isCustomMessage: true);
        return this;
    }

    [GeneratedRegex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
    private static partial Regex EmailRegex();
}
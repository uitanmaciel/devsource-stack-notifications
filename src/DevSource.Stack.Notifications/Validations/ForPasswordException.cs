using System.Text.RegularExpressions;

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRulesException<T>
{
    /// <summary>
    /// Validates that the specified key corresponds to a valid password.
    /// A valid password must meet a specified minimum length and a regex pattern for complexity.
    /// If the key is null or empty, too short, or doesn't match the pattern, a notification is added.
    /// </summary>
    /// <param name="key">The key representing the password field in the object being validated.</param>
    /// <param name="password">The password to be validated.</param>
    /// <param name="min">The minimum length the password must have.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsPassword(string key, string password, int min)
    {
        if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{" + min + ",}$"))
            PublishException(new DomainException(Error.Invalid(password)));
        
        return this;
    }

    /// <summary>
    /// Validates that the specified key corresponds to a valid password with a custom error message.
    /// A valid password must meet a specified minimum length and a regex pattern for complexity.
    /// If the key is null or empty, too short, or doesn't match the pattern, a custom notification is added.
    /// </summary>
    /// <param name="key">The key representing the password field in the object being validated.</param>
    /// <param name="password">The password to be validated.</param>
    /// <param name="min">The minimum length the password must have.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> after performing the validation.</returns>
    public ValidationRulesException<T> IsPassword(string key, string password, int min, string message)
    {
        if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{" + min + ",}$"))
            PublishException(new DomainException(message));
        
        return this;
    }
}
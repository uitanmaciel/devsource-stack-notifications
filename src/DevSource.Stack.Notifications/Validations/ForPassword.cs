using System.Text.RegularExpressions;

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates that the specified key corresponds to a valid password with a custom error message.
    /// A valid password must meet a specified minimum length and a regex pattern for complexity.
    /// If the key is null or empty, too short, or doesn't match the pattern, a custom notification is added.
    /// </summary>
    /// <param name="key">The key representing the password field in the object being validated.</param>
    /// <param name="password">The password to be validated.</param>
    /// <param name="min">The minimum length the password must have.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsPassword(string key, string? password, int min, string? message = null)
    {
        if (IsMissing(password)) return this;

        var isValid = 
            password!.Length >= min &&
            password.Any(char.IsLower) &&
            password.Any(char.IsUpper) &&
            password.Any(char.IsDigit) &&
            password.Any(IsSpecialCharacter);
        
        if (!isValid)
        {
            if (IsMissing(message))
                AddNotification(new Notification(key, message ?? Error.Invalid(password)));
        }
        
        return this;
    }

    private static bool IsSpecialCharacter(char c)
        => !char.IsLetterOrDigit(c);
}
using System.Text.RegularExpressions;

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates if the provided value is a valid Brazilian phone number.
    /// Accepts formats: (XX) XXXXX-XXXX, (XX) XXXX-XXXX, XX XXXXX-XXXX, XX XXXX-XXXX, or without formatting.
    /// </summary>
    /// <param name="key">The key representing the phone field in the object being validated.</param>
    /// <param name="value">The phone value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsBrazilianPhone(string key, string value)
    {
        if (!BrazilianPhoneRegex().IsMatch(value ?? ""))
            AddNotification(new Notification(Error.InvalidBrazilianPhone(key)));
        
        return this;
    }

    /// <summary>
    /// Validates if the provided value is a valid Brazilian phone number, with a custom error message.
    /// Accepts formats: (XX) XXXXX-XXXX, (XX) XXXX-XXXX, XX XXXXX-XXXX, XX XXXX-XXXX, or without formatting.
    /// </summary>
    /// <param name="key">The key representing the phone field in the object being validated.</param>
    /// <param name="value">The phone value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsBrazilianPhone(string key, string value, string message)
    {
        if (!BrazilianPhoneRegex().IsMatch(value ?? ""))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Regular expression to validate Brazilian phone numbers.
    /// </summary>
    [GeneratedRegex(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[0-9])[0-9]{3}\-?[0-9]{4}$")]
    private static partial Regex BrazilianPhoneRegex();

    /// <summary>
    /// Validates if the provided value is a valid international phone number in E.164 format.
    /// Format: +[country code][number] (e.g., +5511999999999)
    /// </summary>
    /// <param name="key">The key representing the phone field in the object being validated.</param>
    /// <param name="value">The phone value to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsInternationalPhone(string key, string value)
    {
        if (!InternationalPhoneRegex().IsMatch(value ?? ""))
            AddNotification(new Notification(Error.InvalidInternationalPhone(key)));
        
        return this;
    }

    /// <summary>
    /// Validates if the provided value is a valid international phone number in E.164 format, with a custom error message.
    /// Format: +[country code][number] (e.g., +5511999999999)
    /// </summary>
    /// <param name="key">The key representing the phone field in the object being validated.</param>
    /// <param name="value">The phone value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsInternationalPhone(string key, string value, string message)
    {
        if (!InternationalPhoneRegex().IsMatch(value ?? ""))
            AddNotification(new Notification(key, message));
        
        return this;
    }

    /// <summary>
    /// Regular expression to validate international phone numbers in E.164 format.
    /// </summary>
    [GeneratedRegex(@"^\+[1-9]\d{1,14}$")]
    private static partial Regex InternationalPhoneRegex();
}

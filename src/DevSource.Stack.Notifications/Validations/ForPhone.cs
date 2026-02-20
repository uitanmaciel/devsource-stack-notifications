using System.Text.RegularExpressions;

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates if the provided value is a valid Brazilian phone number, with a custom error message.
    /// Accepts formats: (XX) XXXXX-XXXX, (XX) XXXX-XXXX, XX XXXXX-XXXX, XX XXXX-XXXX, or without formatting.
    /// </summary>
    /// <param name="key">The key representing the phone field in the object being validated.</param>
    /// <param name="value">The phone value to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsBrazilianPhone(string key, string? value, string? message = null)
    {
        if (IsMissing(value)) return this;

        var digits = NormalizePhoneNumber(value!);
        var isValid =
            digits.Length == 10 || // fixed line
            digits.Length == 11; // mobile

        if(!isValid)
        {
            if(IsMissing(message))
                AddNotification(key, message ?? Error.InvalidBrazilianPhone(key));
        }    
        
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
    public ValidationRules<T> IsInternationalPhone(string key, string? value, string? message = null)
    {
        if (IsMissing(value)) return this;

        if (!InternationalPhoneRegex().IsMatch(value!))
        {
            if (IsMissing(message))
                AddNotification(key, message ?? Error.InvalidInternationalPhone(key));
        }
        
        return this;
    }

    /// <summary>
    /// Regular expression to validate international phone numbers in E.164 format.
    /// </summary>
    [GeneratedRegex(@"^\+[1-9]\d{1,14}$", RegexOptions.Compiled)]
    private static partial Regex InternationalPhoneRegex();

    private static string NormalizePhoneNumber(string value)
        => new([.. value.Where(char.IsDigit)]);
}

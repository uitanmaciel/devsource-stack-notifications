namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates if the provided value is a valid credit card number using Luhn algorithm, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the credit card field in the object being validated.</param>
    /// <param name="value">The credit card number to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCreditCard(string key, string? value, string? message = null)
    {
        if (IsMissing(value)) return this;

        var digits = OnlyDigits(value!);

        if (!IsValidLuhn(digits))
            AddNotification(key, message ?? Error.InvalidCreditCard(key));

        return this;
    }    

    /// <summary>
    /// Validates if the provided credit card expiration date (month and year) is not in the past.
    /// </summary>
    /// <param name="key">The key representing the credit card expiration field in the object being validated.</param>
    /// <param name="month">The expiration month (1-12).</param>
    /// <param name="year">The expiration year (e.g., 2025).</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <param name="referenceDate">The reference date to compare against (default is current UTC date).</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCreditCardNotExpired(string key, int month, int year, string? message = null, DateTime? referenceDate = null)
    {
        if (month < 1 || month > 12)
        {
            AddNotification(key, message ?? Error.InvalidCreditCard(key));
            return this;
        }

        var now = referenceDate ?? DateTime.UtcNow.Date;
        var expiration = new DateTime(year, month, DateTime.DaysInMonth(year, month));

        if (expiration < now)
            AddNotification(key, message ?? Error.CreditCardExpired());

        return this;
    }

    private static bool IsValidLuhn(string digits)
    {
        if (digits.Length < 12 || digits.Length > 19) return false;

        int sum = 0;
        bool alternate = false;

        for (int i = digits.Length - 1; i >= 0; i--)
        {
            int digit = digits[i] - '0';

            if (digit < 0 || digit > 9)
                return false;

            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                    digit -= 9;
            }

            sum += digit;
            alternate = !alternate;
        }

        return sum % 10 == 0;
    }
}

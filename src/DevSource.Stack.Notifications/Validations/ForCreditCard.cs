namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates if the provided value is a valid credit card number using Luhn algorithm.
    /// </summary>
    /// <param name="key">The key representing the credit card field in the object being validated.</param>
    /// <param name="value">The credit card number to be validated.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCreditCard(string key, string value)
    {
        var cardNumber = value?.Replace(" ", "").Replace("-", "");
        
        if (string.IsNullOrEmpty(cardNumber) || !cardNumber.All(char.IsDigit))
        {
            AddNotification(new Notification(Error.InvalidCreditCard(key)));
            return this;
        }
        
        int sum = 0;
        bool alternate = false;
        
        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(cardNumber[i].ToString());
            
            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                    digit -= 9;
            }
            
            sum += digit;
            alternate = !alternate;
        }

        if (sum % 10 != 0)
            AddNotification(new Notification(Error.InvalidCreditCard(key)));

        return this;
    }

    /// <summary>
    /// Validates if the provided value is a valid credit card number using Luhn algorithm, with a custom error message.
    /// </summary>
    /// <param name="key">The key representing the credit card field in the object being validated.</param>
    /// <param name="value">The credit card number to be validated.</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCreditCard(string key, string value, string message)
    {
        var cardNumber = value?.Replace(" ", "").Replace("-", "");
        
        if (string.IsNullOrEmpty(cardNumber) || !cardNumber.All(char.IsDigit))
        {
            AddNotification(new Notification(key, message));
            return this;
        }
        
        int sum = 0;
        bool alternate = false;
        
        for (int i = cardNumber.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(cardNumber[i].ToString());
            
            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                    digit -= 9;
            }
            
            sum += digit;
            alternate = !alternate;
        }

        if (sum % 10 != 0)
            AddNotification(new Notification(key, message));

        return this;
    }

    /// <summary>
    /// Validates if the credit card expiration date is valid and not expired.
    /// </summary>
    /// <param name="month">The expiration month (1-12).</param>
    /// <param name="year">The expiration year (e.g., 2025).</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCreditCardNotExpired(int month, int year)
    {
        var currentDate = DateTime.Now;
        var expirationDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
        
        if (expirationDate < currentDate)
            AddNotification(new Notification(Error.CreditCardExpired()));

        return this;
    }

    /// <summary>
    /// Validates if the credit card expiration date is valid and not expired, with a custom error message.
    /// </summary>
    /// <param name="month">The expiration month (1-12).</param>
    /// <param name="year">The expiration year (e.g., 2025).</param>
    /// <param name="message">The custom error message to be used in the notification if validation fails.</param>
    /// <returns>The current instance of <see cref="ValidationRules{T}"/> after performing the validation.</returns>
    public ValidationRules<T> IsCreditCardNotExpired(int month, int year, string message)
    {
        var currentDate = DateTime.Now;
        var expirationDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));
        
        if (expirationDate < currentDate)
            AddNotification(new Notification(message));

        return this;
    }
}

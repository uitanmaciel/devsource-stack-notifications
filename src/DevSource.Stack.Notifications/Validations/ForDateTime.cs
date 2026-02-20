namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Checks if the provided date string is a valid date and falls within the specified range.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date value to be validated.</param>
    /// <param name="from">The start date of the range.</param>
    /// <param name="to">The end date of the range.</param>
    /// <param name="message">The custom error message to be associated with the validation result.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class.</returns>
    public ValidationRules<T> IsDateBetween(string key, DateTime value, DateTime from, DateTime to, string? message = null)
    {
        if (value < from || value > to)
            AddNotification(new Notification(key, message ?? Error.IsDateBetween(key, from, to)));

        return this;
    }

    /// <summary>
    /// Checks if the provided date string is a valid date and falls within the specified range.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <param name="from">The start date of the range.</param>
    /// <param name="to">The end date of the range.</param>
    /// <param name="message">The custom error message to be associated with the validation result.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class.</returns>
    public ValidationRules<T> IsDateBetween(string key, string? value, DateTime from, DateTime to, string? message = null)
    {
        if (!TryParseDate(key, value, out var date))
            return this;

        return IsDateBetween(key, date, from, to, message);
    }
    
    /// <summary>
    /// Checks if the provided date string is a valid date and falls within the specified range.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <param name="expected">The expected day of the week.</param>
    /// <param name="message">The custom error message to be associated with the validation result.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class.</returns>
    public ValidationRules<T> IsDayOfWeek(string key, string value, DayOfWeek expected, string? message = null)
    {
         if (!TryParseDate(key, value, out var date))
            return this;

        return IsDayOfWeek(key, date, expected, message);
    }

    /// <summary>
    /// Checks if the provided date string is a valid date and falls within the specified range.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date value to be validated.</param>
    /// <param name="expected">The expected day of the week.</param>
    /// <param name="message">The custom error message to be associated with the validation result.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class.</returns>
    public ValidationRules<T> IsDayOfWeek(string key, DateTime value, DayOfWeek expected, string? message = null)
    {
        if (value.DayOfWeek != expected)
            AddNotification(new Notification(key, message ?? Error.IsDayOfWeek(value, expected)));

        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the future and adds a notification if it is not.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be checked.</param>
    /// <param name="message">The error message to be added to the notification if the validation fails.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class.</returns>
    public ValidationRules<T> IsInTheFuture(string key, string value, string? message = null)
    {
        if (!TryParseDate(key, value, out var date))
            return this;

        return IsInTheFuture(key, date, message);
    }

    /// <summary>
    /// Checks if the given date string is in the future and adds a notification if it is not.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <param name="message">The error message to be added to the notification if the validation fails.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRules{T}"/> class.
    /// </returns>
    public ValidationRules<T> IsInTheFuture(string key, DateTime value, string? message = null)
    {
        if (value <= DateTime.UtcNow)
            AddNotification(new Notification(key, message ?? Error.IsInTheFuture(key)));

        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the past.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <param name="message">The error message to be added to the notification if the validation fails.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRules{T}"/> class.
    /// </returns>
    public ValidationRules<T> IsInThePast(string key, string value, string? message = null)
    {
        if (!TryParseDate(key, value, out var date))
            return this;

        return IsInThePast(key, date, message);
    }

    /// <summary>
    /// Checks if the given date string is in the past.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <param name="message">The error message to be added to the notification if the validation fails.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRules{T}"/> class.
    /// </returns>
    public ValidationRules<T> IsInThePast(string key, DateTime value, string? message = null)
    {
        if (value >= DateTime.UtcNow)
            AddNotification(new Notification(key, message ?? Error.IsInThePast(key)));

        return this;
    }
    
    private bool TryParseDate(string key, string? value, out DateTime date)
    {
        if (IsMissing(value))
        {
            AddNotification(new Notification(key, Error.IsNotConvertDateTime(value!)));
            date = default;
            return false;
        }

        if (!DateTime.TryParse(value, out date))
        {
            AddNotification(new Notification(key, Error.IsNotConvertDateTime(value!)));
            return false;
        }

        return true;
    }

}
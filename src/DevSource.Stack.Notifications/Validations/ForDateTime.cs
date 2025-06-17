using DevSource.Stack.Notifications.Validations.Internal;

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Checks if the given date string is between the specified range of dates.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <param name="from">The start date of the range.</param>
    /// <param name="to">The end date of the range.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRules{T}"/> class.
    /// </returns>
    public ValidationRules<T> IsDateBetween(string key, string value, DateTime from, DateTime to)
    {
        var dt = ConvertDateTime(value);
        // If dt is default(DateTime) due to parsing error, ConvertDateTime already added notification.
        // Only proceed if dt is not default, or if ConvertDateTime behavior changes.
        // For now, assume ConvertDateTime handles its own notification and we can proceed.
        // A more robust approach might involve TryParse in ConvertDateTime and then conditional call here.
        if (dt != default(DateTime)) // Check if parsing was successful (basic check)
        {
            ValidationRuleRunners.IsDateBetween(
                dt, from, to, key, Error.IsDateBetween(key, from, to), this.AddNotification, null, isCustomMessage: true);
        }
        return this;
    }

    /// <summary>
    /// Checks if the given date string is between the specified range of dates.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <param name="from">The start date of the range.</param>
    /// <param name="to">The end date of the range.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRules{T}"/> class.
    /// </returns>
    public ValidationRules<T> IsDateBetween(string key, DateTime value, DateTime from, DateTime to)
    {
        ValidationRuleRunners.IsDateBetween(
            value, from, to, key, Error.IsDateBetween(key, from, to), this.AddNotification, null, isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Checks if the given value is the specified day of the week.
    /// </summary>
    /// <param name="key">The key identifier of the value.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="dayOfWeek">The expected day of the week.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRules{T}"/> class.
    /// </returns>
    public ValidationRules<T> IsDayOfWeek(string key, string value, DayOfWeek dayOfWeek)
    {
        var dt = ConvertDateTime(value);
        if (dt != default(DateTime))
        {
            // Error.IsDayOfWeek(value, dayOfWeek) uses the original string 'value' in its message.
            // The runner expects the error message to be a template or a fully custom message.
            // We should pass the pre-formatted message from Error.cs.
            ValidationRuleRunners.IsDayOfWeek(
                dt, dayOfWeek, key, Error.IsDayOfWeek(value, dayOfWeek), this.AddNotification, null, isCustomMessage: true);
        }
        return this;
    }

    /// <summary>
    /// Checks if the given date is a specified day of the week.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date value to be validated.</param>
    /// <param name="dayOfWeek">The specified day of the week.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class.</returns>
    public ValidationRules<T> IsDayOfWeek(string key, DateTime value, DayOfWeek dayOfWeek)
    {
        // Error.IsDayOfWeek(value, dayOfWeek) - 'value' here is DateTime, but Error.IsDayOfWeek expects string for the value part of message.
        // Let's use the overload Error.IsDayOfWeek(key, dayOfWeek) for more general message from Error.cs
        ValidationRuleRunners.IsDayOfWeek(
            value, dayOfWeek, key, Error.IsDayOfWeek(key, dayOfWeek), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the future and adds a notification if it is not.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be checked.</param>
    /// <returns>The current instance of the <see cref="ValidationRules{T}"/> class.</returns>
    public ValidationRules<T> IsInTheFuture(string key, string value)
    {
        var dt = ConvertDateTime(value);
        if (dt != default(DateTime))
        {
            ValidationRuleRunners.IsInTheFuture(
                dt, key, Error.IsInTheFuture(key), this.AddNotification, null, isCustomMessage: true);
        }
        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the future and adds a notification if it is not.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRules{T}"/> class.
    /// </returns>
    public ValidationRules<T> IsInTheFuture(string key, DateTime value)
    {
        ValidationRuleRunners.IsInTheFuture(
            value, key, Error.IsInTheFuture(key), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the past.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRules{T}"/> class.
    /// </returns>
    public ValidationRules<T> IsInThePast(string key, string value)
    {
        var dt = ConvertDateTime(value);
        if (dt != default(DateTime))
        {
            ValidationRuleRunners.IsInThePast(
                dt, key, Error.IsInThePast(key), this.AddNotification, null, isCustomMessage: true);
        }
        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the past.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRules{T}"/> class.
    /// </returns>
    public ValidationRules<T> IsInThePast(string key, DateTime value)
    {
        ValidationRuleRunners.IsInThePast(
            value, key, Error.IsInThePast(key), this.AddNotification, null, isCustomMessage: true);
        return this;
    }
    
    private DateTime ConvertDateTime(string value)
    {
        if(!DateTime.TryParse(value, out var dt))
            AddNotification(new Notification(nameof(value), Error.IsNotConvertDateTime(value)));

        return dt;
    }
}
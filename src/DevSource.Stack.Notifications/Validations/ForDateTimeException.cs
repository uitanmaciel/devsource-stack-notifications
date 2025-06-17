using DevSource.Stack.Notifications.Validations.Internal;

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRulesException<T>
{
    /// <summary>
    /// Checks if the given date string is between the specified range of dates.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <param name="from">The start date of the range.</param>
    /// <param name="to">The end date of the range.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRulesException{T}"/> class.
    /// </returns>
    public ValidationRulesException<T> IsDateBetween(string key, string value, DateTime from, DateTime to)
    {
        var dt = ConvertDateTime(value);
        if (dt != default(DateTime))
        {
            ValidationRuleRunners.IsDateBetween(
                dt, from, to, key, Error.IsDateBetween(key, from, to), null, this.PublishException, isCustomMessage: true);
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
    /// The current instance of the <see cref="ValidationRulesException{T}"/> class.
    /// </returns>
    public ValidationRulesException<T> IsDateBetween(string key, DateTime value, DateTime from, DateTime to)
    {
        ValidationRuleRunners.IsDateBetween(
            value, from, to, key, Error.IsDateBetween(key, from, to), null, this.PublishException, isCustomMessage: true);
        return this;
    }
    
    /// <summary>
    /// Checks if the given value is the specified day of the week.
    /// </summary>
    /// <param name="key">The key identifier of the value.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="dayOfWeek">The expected day of the week.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRulesException{T}"/> class.
    /// </returns>
    public ValidationRulesException<T> IsDayOfWeek(string key, string value, DayOfWeek dayOfWeek)
    {
        var dt = ConvertDateTime(value);
        if (dt != default(DateTime))
        {
            ValidationRuleRunners.IsDayOfWeek(
                dt, dayOfWeek, key, Error.IsDayOfWeek(value, dayOfWeek), null, this.PublishException, isCustomMessage: true);
        }
        return this;
    }

    /// <summary>
    /// Checks if the given date is a specified day of the week.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date value to be validated.</param>
    /// <param name="dayOfWeek">The specified day of the week.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class.</returns>
    public ValidationRulesException<T> IsDayOfWeek(string key, DateTime value, DayOfWeek dayOfWeek)
    {
        ValidationRuleRunners.IsDayOfWeek(
            value, dayOfWeek, key, Error.IsDayOfWeek(key, dayOfWeek), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the future and adds a notification if it is not.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be checked.</param>
    /// <returns>The current instance of the <see cref="ValidationRulesException{T}"/> class.</returns>
    public ValidationRulesException<T> IsInTheFuture(string key, string value)
    {
        var dt = ConvertDateTime(value);
        if (dt != default(DateTime))
        {
            ValidationRuleRunners.IsInTheFuture(
                dt, key, Error.IsInTheFuture(key), null, this.PublishException, isCustomMessage: true);
        }
        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the future and adds a notification if it is not.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRulesException{T}"/> class.
    /// </returns>
    public ValidationRulesException<T> IsInTheFuture(string key, DateTime value)
    {
        ValidationRuleRunners.IsInTheFuture(
            value, key, Error.IsInTheFuture(key), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the past.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRulesException{T}"/> class.
    /// </returns>
    public ValidationRulesException<T> IsInThePast(string key, string value)
    {
        var dt = ConvertDateTime(value);
        if (dt != default(DateTime))
        {
            ValidationRuleRunners.IsInThePast(
                dt, key, Error.IsInThePast(key), null, this.PublishException, isCustomMessage: true);
        }
        return this;
    }

    /// <summary>
    /// Checks if the given date string is in the past.
    /// </summary>
    /// <param name="key">The key identifier of the date value.</param>
    /// <param name="value">The date string to be validated.</param>
    /// <returns>
    /// The current instance of the <see cref="ValidationRulesException{T}"/> class.
    /// </returns>
    public ValidationRulesException<T> IsInThePast(string key, DateTime value)
    {
        ValidationRuleRunners.IsInThePast(
            value, key, Error.IsInThePast(key), null, this.PublishException, isCustomMessage: true);
        return this;
    }
    
    private DateTime ConvertDateTime(string value)
    {
        if(!DateTime.TryParse(value, out var dt))
            PublishException(new DomainException(nameof(value), Error.IsNotConvertDateTime(value)));

        return dt;
    }
}
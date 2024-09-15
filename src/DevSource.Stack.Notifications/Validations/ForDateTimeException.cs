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
        
        if(dt < from || dt > to)
            PublicException(new DomainException(key, Error.IsDateBetween(key, from, to)));

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
        if(value < from || value > to)
            PublicException(new DomainException(key, Error.IsDateBetween(key, from, to)));

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
        
        if(dt.DayOfWeek != dayOfWeek)
            PublicException(new DomainException(key, Error.IsDayOfWeek(value, dayOfWeek)));

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
        if(value.DayOfWeek != dayOfWeek)
            PublicException(new DomainException(key, Error.IsDayOfWeek(value, dayOfWeek)));

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
        
        if(dt < DateTime.Now)
            PublicException(new DomainException(key, Error.IsInTheFuture(key)));

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
        if(value < DateTime.Now)
            PublicException(new DomainException(key, Error.IsInTheFuture(key)));

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
        
        if(dt > DateTime.Now)
            PublicException(new DomainException(key, Error.IsInThePast(key)));

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
        if(value > DateTime.Now)
            PublicException(new DomainException(key, Error.IsInThePast(key)));

        return this;
    }
    
    private DateTime ConvertDateTime(string value)
    {
        if(!DateTime.TryParse(value, out var dt))
            PublicException(new DomainException(nameof(value), Error.IsNotConvertDateTime(value)));

        return dt;
    }
}
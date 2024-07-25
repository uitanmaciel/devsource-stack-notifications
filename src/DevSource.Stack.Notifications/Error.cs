namespace DevSource.Stack.Notifications;

public static class Error
{
    /// <summary>
    /// Creates a required field error notification.
    /// </summary>
    /// <param name="key">The key identifying the field that is required.</param>    
    /// <returns>A notification indicating that the field is required.</returns>
    public static string IsRequired(string key)
        => $"The field '{key}' is required";

    /// <summary>
    /// Creates a maximum length error notification.
    /// </summary>
    /// <param name="key">The key identifying the field with a maximum length constraint.</param>    
    /// <param name="maxLength">The maximum allowed length for the field.</param>
    /// <returns>A notification indicating that the field exceeds the maximum allowed length.</returns>
    public static string MaxLength(string key, int maxLength)
        => $"The field '{key}' must have a maximum of {maxLength} characters";

    /// <summary>
    /// Creates a minimum length error notification.
    /// </summary>
    /// <param name="key">The key identifying the field with a minimum length constraint.</param>
    /// <param name="minLength">The minimum required length for the field.</param>
    /// <returns>A notification indicating that the field does not meet the minimum required length.</returns>
    public static string MinLength(string key, int minLength)
        => $"The field '{key}' must have a minimum of {minLength} characters";

    /// <summary>
    /// Creates an email error notification.
    /// </summary>
    /// <param name="value">The value of the field.</param>
    /// <returns>A notification indicating that the field does not contain a valid email.</returns>
    public static string Email(string value)
        => $"The '{value}' is not a valid email";

    /// <summary>
    /// Creates a generic invalid field error notification.
    /// </summary>
    /// <param name="key">The key identifying the invalid field.</param>
    /// <returns>A notification indicating that the field is invalid.</returns>
    public static string Invalid(string key)
        => $"The value of field '{key}' is invalid";

    /// <summary>
    /// Creates a null field error notification.
    /// </summary>
    /// <param name="key">The key identifying the field that must be null.</param>
    /// <returns>A notification indicating that the field must be null.</returns>
    public static string IsNull(string key)
        => $"The field '{key}' must be null";

    /// <summary>
    /// Creates a not null field error notification.
    /// </summary>
    /// <param name="key">The key identifying the field that must not be null.</param>
    /// <returns>A notification indicating that the field must not be null.</returns>
    public static string IsNotNull(string key)
        => $"The field '{key}' must not be null";

    /// <summary>
    /// Creates a not null field error notification.
    /// </summary>
    /// <param name="key">The key identifying the field that must bigger than value param.</param>
    /// <param name="greaterThan">The value required for field.</param>
    /// <returns>A notification indicating that the field does not meet the bigger required length.</returns>
    public static string IsGreaterThan(string key, int greaterThan)
        => $"The field '{key}' must be bigger than {greaterThan}";

    /// <summary>
    /// Creates a not null field error notification.
    /// </summary>
    /// <param name="date">The date reported for comparison.</param>
    /// <param name="comparer">The reference date for comparison.</param>
    /// <param name="key">The identification key of the field to be compared.</param>
    /// <returns>A notification indicating that the field is not bigger than the reference date.</returns>
    public static string IsGreaterThan(DateTime date, DateTime comparer, string key)
        => $"The field '{key}' must be bigger than {comparer}";

    /// <summary>
    /// Creates a not null field error notification.
    /// </summary>
    /// <param name="key">The key identifying the field that must lower than value param.</param>
    /// <param name="lowerThan">The value required for field.</param>
    /// <returns>A notification indicating that the field does not meet the lower required length.</returns>
    public static string IsLowerThan(string key, int lowerThan)
        => $"The field '{key}' must be lower than {lowerThan}";

    /// <summary>
    /// Creates a notification indicating that a field must be null or empty.
    /// </summary>
    /// <param name="key">The key identifying the field to check.</param>
    /// <returns>A notification indicating that the field must be null or empty.</returns>
    public static string IsNullOrEmpty(string key)
        => $"The field '{key}' must be null or empty";

    /// <summary>
    /// Creates a notification indicating that a field must be null or contain only white space.
    /// </summary>
    /// <param name="key">The key identifying the field to check.</param>
    /// <returns>A notification indicating that the field must be null or contain only white space.</returns>
    public static string IsNullOrWhiteSpace(string key)
        => $"The field '{key}' must be null or contain white space";

    /// <summary>
    /// Checks if the given string value can be converted to a valid DateTime in ISO 8601 format (yyyy-mm-dd).
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <returns>The error message indicating that the value must be a valid date in ISO 8601 format.</returns>
    public static string IsNotConvertDateTime(string value)
        => string.Format($"The key '{value}' must be a valid date in ISO 8601 format (yyyy-mm-dd).");

    /// <summary>
    /// Checks if a given date falls between a specified range.
    /// </summary>
    /// <param name="key">The key identifying the field.</param>
    /// <param name="value">The date value to check.</param>
    /// <param name="from">The start of the date range.</param>
    /// <param name="to">The end of the date range.</param>
    /// <returns>A notification indicating if the date is not between the specified range.</returns>
    public static string IsDateBetween(string key, DateTime from, DateTime to)
        => $"The value of field '{key}' must be between {from} and {to}";

    /// <summary>
    /// Checks if the given value corresponds to the specified day of the week.
    /// </summary>
    /// <param name="key">The key identifying the field.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="dayOfWeek">The expected day of the week.</param>
    /// <returns>A notification indicating whether the value is the specified day of the week.</returns>
    public static string IsDayOfWeek(string key, DayOfWeek dayOfWeek)
        => $"The value of field '{key}' must be a {dayOfWeek} day of the week";

    /// <summary>
    /// Creates a notification indicating that the specified DateTime value must be a specific day of the week.
    /// </summary>
    /// <param name="key">The key identifying the field being validated.</param>
    /// <param name="value">The DateTime value being validated.</param>
    /// <param name="dayOfWeek">The expected day of the week.</param>
    /// <returns>A notification indicating that the specified DateTime value must be a specific day of the week.</returns>
    public static string IsDayOfWeek(DateTime key, DayOfWeek dayOfWeek)
        => $"The value of field '{key}' must be a {dayOfWeek} day of the week";

    /// <summary>
    /// Returns a notification indicating that the value of the field identified by the given key must be in the future.
    /// </summary>
    /// <param name="key">The key identifying the field.</param>
    /// <returns>A notification indicating that the value of the field must be in the future.</returns>
    public static string IsInTheFuture(string key)
        => $"The value of field '{key}' must be in the future";

    /// <summary>
    /// Creates a notification indicating that the specified date must be in the future.
    /// </summary>
    /// <param name="key">The key identifying the field.</param>
    /// <returns>A notification indicating that the specified date must be in the future.</returns>
    public static string IsInTheFuture(DateTime key)
        => $"The value of field '{key}' must be in the future";

    /// <summary>
    /// Determines whether the specified value is in the past.
    /// </summary>
    /// <param name="key">The key identifying the value being validated.</param>
    /// <returns>A notification indicating that the value must be in the past.</returns>
    public static string IsInThePast(string key)
        => $"The value of field '{key}' must be in the past";

    /// <summary>
    /// Creates a notification indicating that the given field should be in the past.
    /// </summary>
    /// <param name="key">The key identifying the field.</param>
    /// <returns>A notification indicating that the field should be in the past.</returns>
    public static string IsInThePast(DateTime key)
        => $"The value of field '{key}' must be in the past";
}
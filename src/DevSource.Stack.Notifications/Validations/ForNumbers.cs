namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates if a specified numeric value is greater than the defined comparison value.     
    /// </summary>
    /// <typeparam name="TValue">The type of the numeric value to be validated.</typeparam>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value used for comparison against the provided value.</param>
    /// <param name="message">The custom error message to be associated with the validation result.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsGreaterThan<TValue>(string key, TValue value, TValue comparer, string? message = null) where TValue : IComparable<TValue>
        => IfInvalid(value.CompareTo(comparer) < 0,
                     key,
                     message ?? Error.IsGreaterThan(key, comparer));

    /// <summary>
    /// Validates if a specified numeric value is greater than or equal to the defined comparison value.
    /// </summary>
    /// <typeparam name="TValue">The type of the numeric value to be validated.</typeparam>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value used for comparison against the provided value.</param>
    /// <param name="message">The custom error message to be associated with the validation result.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsLowerThan<TValue>(string key, TValue value, TValue comparer, string? message = null) where TValue : IComparable<TValue>
        => IfInvalid(value.CompareTo(comparer) > 0,
                     key,
                     message ?? Error.IsLowerThan(key, comparer));

    /// <summary>
    /// Validates whether a specified numeric value falls within a defined range, inclusive of the minimum and maximum values, with a custom error message.
    /// </summary>
    /// <typeparam name="TValue">The type of the numeric value to be validated.</typeparam>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="min">The inclusive minimum value of the range.</param>
    /// <param name="max">The inclusive maximum value of the range.</param>    
    /// <param name="message">The custom error message to be associated with the validation result.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsBetween<TValue>(string key, TValue value, TValue min, TValue max, string? message = null) where TValue : IComparable<TValue>
         => IfInvalid(value.CompareTo(min) < 0 || value.CompareTo(max) > 0,
                     key,
                     message ?? Error.IsBetween(key, min, max));

    /// <summary>
    /// Compares a specified value with a comparison value and adds a notification if they are not equal.
    /// </summary>
    /// <typeparam name="TValue">The type of the value to be compared.</typeparam>
    /// <param name="key">The identifier for the value being compared, used for notification purposes.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="comparer">The value to compare against the provided value.</param>
    /// <param name="message">The custom error message to be associated with the validation result if the values are not equal.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> Compare<TValue>(string key, TValue value, TValue comparer, string? message = null) where TValue : IComparable<TValue>
        => IfInvalid(value.CompareTo(comparer) != 0,
                     key,
                     message ?? Error.Compare(key, comparer));
}
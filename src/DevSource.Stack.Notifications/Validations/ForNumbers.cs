using DevSource.Stack.Notifications.Validations.Internal; 

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    /// <summary>
    /// Validates if a specified numeric value is greater than the defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value used for comparison against the provided value.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsGreaterThan(string key, double value, double comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if the specified numeric value is greater than the defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value to compare against the provided value.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsGreaterThan(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified numeric value is greater than a defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used to construct notification messages.</param>
    /// <param name="value">The numeric value being validated.</param>
    /// <param name="comparer">The numeric value to compare against the provided value.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsGreaterThan(string key, int value, int comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified value is greater than the defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The value to validate against the comparison value.</param>
    /// <param name="comparer">The value used for comparison against the specified value.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsGreaterThan(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if the specified value is greater than the provided comparison value.
    /// </summary>
    /// <param name="key">The unique identifier of the value being validated, used for notification purposes.</param>
    /// <param name="value">The value that needs to be evaluated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to enable method chaining for additional validations.</returns>
    public ValidationRules<T> IsGreaterThan(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates whether the specified numeric value is greater than the given comparison value.
    /// </summary>
    /// <param name="key">A unique identifier for the item being validated, used for notification tracking.</param>
    /// <param name="value">The numeric value to be evaluated.</param>
    /// <param name="comparer">The numeric value to compare against.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> enabling method chaining.</returns>
    public ValidationRules<T> IsGreaterThan(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified numeric value is lower than the defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value used for comparison against the provided value.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsLowerThan(string key, double value, double comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified numeric value is lower than the defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value used as the threshold for comparison.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsLowerThan(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified numeric value is less than the defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value used for comparison against the provided value.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsLowerThan(string key, int value, int comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified numeric value is lower than the defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value used for comparison against the provided value.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsLowerThan(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified numeric value is lower than the defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value used for comparison against the provided value.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsLowerThan(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified numeric value is less than the defined comparison value.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="comparer">The numeric value used for comparison against the provided value.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsLowerThan(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates whether a numeric value falls between a specified minimum and maximum range, inclusive.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value to be checked against the specified range.</param>
    /// <param name="min">The inclusive minimum value of the range.</param>
    /// <param name="max">The inclusive maximum value of the range.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to enable method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, double value, double min, double max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates whether a specified numeric value falls within a defined range, inclusive of the minimum and maximum values.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value to be validated.</param>
    /// <param name="min">The inclusive minimum value of the range.</param>
    /// <param name="max">The inclusive maximum value of the range.</param>
    /// <param name="message">The custom message to include if the validation fails.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, double value, double min, double max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates whether a specified numeric value falls within a defined range, inclusive of the minimum and maximum values.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="min">The minimum allowable value in the range.</param>
    /// <param name="max">The maximum allowable value in the range.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, decimal value, decimal min, decimal max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates whether a specified numeric value falls within a defined range, inclusive of the minimum and maximum values.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="min">The minimum allowable value of the range.</param>
    /// <param name="max">The maximum allowable value of the range.</param>
    /// <param name="message">The custom message to use in case the validation fails.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, decimal value, decimal min, decimal max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified numeric value falls within a defined range.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value to be validated.</param>
    /// <param name="min">The minimum value of the range.</param>
    /// <param name="max">The maximum value of the range.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, int value, int min, int max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates if a specified numeric value falls within the inclusive range defined by the provided minimum and maximum values.
    /// </summary>
    /// <param name="key">The identifier for the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value that needs to be validated.</param>
    /// <param name="min">The minimum value of the inclusive range.</param>
    /// <param name="max">The maximum value of the inclusive range.</param>
    /// <param name="message">A custom error message provided when the validation fails.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> IsBetween(string key, int value, int min, int max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares a given numeric value with a specified comparer value to determine equality.
    /// </summary>
    /// <param name="key">The identifier for the value being compared, used for notification purposes.</param>
    /// <param name="value">The numeric value to be compared.</param>
    /// <param name="comparer">The numeric value to compare against the provided value.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> Compare(string key, double value, double comparer)
    {
        ValidationRuleRunners.Compare(value, comparer, key, Error.Compare(key, comparer), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares a specified numeric value with a comparison value and adds a notification if the values are not equal.
    /// </summary>
    /// <param name="key">The identifier associated with the value being validated, used for notification purposes.</param>
    /// <param name="value">The numeric value to be compared.</param>
    /// <param name="comparer">The numeric value to compare against.</param>
    /// <param name="message">The message to include in the notification if the comparison fails.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> Compare(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.Compare(value, comparer, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares a value against a specified comparison value and adds a notification if they are not equal.
    /// </summary>
    /// <param name="key">The identifier for the value being compared, used for notification purposes.</param>
    /// <param name="value">The numeric value to be compared.</param>
    /// <param name="comparer">The numeric value to compare against.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> Compare(string key, int value, int comparer)
    {
        ValidationRuleRunners.Compare(value, comparer, key, Error.Compare(key, comparer), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares a specified numeric value with a comparison value and adds a notification if they are not equal.
    /// </summary>
    /// <param name="key">The identifier for the value being compared, used for notification purposes.</param>
    /// <param name="value">The numeric value to be compared.</param>
    /// <param name="comparer">The comparison value to check against the specified value.</param>
    /// <param name="message">The message to include in the notification if the values are not equal.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> Compare(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.Compare(value, comparer, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares the specified decimal value to a comparison value and triggers a notification or custom message if they do not match.
    /// </summary>
    /// <param name="key">The identifier for the value being compared, used for notification purposes.</param>
    /// <param name="value">The decimal value to be compared.</param>
    /// <param name="comparer">The decimal value to compare against the provided value.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> Compare(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.Compare(value, comparer, key, Error.Compare(key, comparer), AddNotification, null, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares a specified numeric value against another value and generates a notification if the comparison fails.
    /// </summary>
    /// <param name="key">The identifier used for associating the value being validated with a specific comparison operation.</param>
    /// <param name="value">The numeric value to be compared.</param>
    /// <param name="comparer">The numeric value that acts as the comparison baseline.</param>
    /// <param name="message">The custom notification message to be used if the comparison validation fails.</param>
    /// <returns>An instance of <see cref="ValidationRules{T}"/> to allow method chaining.</returns>
    public ValidationRules<T> Compare(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.Compare(value, comparer, key, message, AddNotification, null, isCustomMessage: true);
        return this;
    }
}
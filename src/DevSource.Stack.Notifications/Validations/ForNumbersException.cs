using DevSource.Stack.Notifications.Validations.Internal;

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRulesException<T>
{
    /// <summary>
    /// Validates that a given value is greater than the specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsGreaterThan(string key, double value, double comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value is greater than the specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsGreaterThan(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a provided value is greater than a specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field related to the validation.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsGreaterThan(string key, int value, int comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the provided value is greater than the specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsGreaterThan(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified value is greater than the comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsGreaterThan(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified value is greater than the comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsGreaterThan(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value is lower than the specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsLowerThan(string key, double value, double comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value is less than the specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsLowerThan(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the given value is lower than the specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsLowerThan(string key, int value, int comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value is less than the specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsLowerThan(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value is lower than the specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsLowerThan(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value is lower than the specified comparer value and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="message">A custom message to be associated with the validation result.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsLowerThan(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates whether a given value is within a specified range (inclusive) defined by the provided minimum and maximum values.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="min">The minimum permissible value of the range.</param>
    /// <param name="max">The maximum permissible value of the range.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsBetween(string key, double value, double min, double max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value falls between the specified minimum and maximum boundaries and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="min">The minimum allowed value.</param>
    /// <param name="max">The maximum allowed value.</param>
    /// <param name="message">A custom validation message to be used in case of failure.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsBetween(string key, double value, double min, double max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value is within the specified range and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="min">The minimum allowable value for the field.</param>
    /// <param name="max">The maximum allowable value for the field.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsBetween(string key, decimal value, decimal min, decimal max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that the specified value is between the given minimum and maximum range, inclusive,
    /// and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="min">The lower bound of the range.</param>
    /// <param name="max">The upper bound of the range.</param>
    /// <param name="message">The custom message to include if validation fails.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsBetween(string key, decimal value, decimal min, decimal max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value is within the specified range, inclusive, and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be validated.</param>
    /// <param name="min">The minimum allowable value for the range.</param>
    /// <param name="max">The maximum allowable value for the range.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsBetween(string key, int value, int min, int max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Validates that a given value is between the specified minimum and maximum range and returns the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to validate.</param>
    /// <param name="min">The minimum allowed value for validation.</param>
    /// <param name="max">The maximum allowed value for validation.</param>
    /// <param name="message">The custom message to use if the validation fails.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> IsBetween(string key, int value, int min, int max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares a given value with a specified comparer value and ensures they are equal.
    /// If the values do not match, an exception is published and returned.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> after performing the comparison.</returns>
    public ValidationRulesException<T> Compare(string key, double value, double comparer)
    {
        ValidationRuleRunners.Compare(value, comparer, key, Error.Compare(key, comparer), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares the specified value with a given comparer value and validates if the condition is met, returning the current exception instance.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="message">The custom message to use if the validation fails.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> after processing the validation.</returns>
    public ValidationRulesException<T> Compare(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.Compare(value, comparer, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares a given integer value against a specified comparer value and processes the validation result.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The integer value to be validated.</param>
    /// <param name="comparer">The integer value to compare against.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result processed.</returns>
    public ValidationRulesException<T> Compare(string key, int value, int comparer)
    {
        ValidationRuleRunners.Compare(value, comparer, key, Error.Compare(key, comparer), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares a given integer value with a specified comparer value and validates based on a custom message.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The integer value to be validated.</param>
    /// <param name="comparer">The comparer value to validate against.</param>
    /// <param name="message">The custom message to use for the validation exception.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the validation result.</returns>
    public ValidationRulesException<T> Compare(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.Compare(value, comparer, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares a given value to the specified comparer value and applies a validation rule.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="comparer">The reference value to compare against.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> after applying the validation rule.</returns>
    public ValidationRulesException<T> Compare(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.Compare(value, comparer, key, Error.Compare(key, comparer), null, PublishException, isCustomMessage: true);
        return this;
    }

    /// <summary>
    /// Compares the given value to the specified comparer value, and applies a custom message for the validation.
    /// </summary>
    /// <param name="key">The name of the field being validated.</param>
    /// <param name="value">The value to be compared.</param>
    /// <param name="comparer">The value against which the comparison is made.</param>
    /// <param name="message">The custom message to be associated with the validation result.</param>
    /// <returns>Returns the current instance of <see cref="ValidationRulesException{T}"/> with the updated validation state.</returns>
    public ValidationRulesException<T> Compare(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.Compare(value, comparer, key, message, null, PublishException, isCustomMessage: true);
        return this;
    }
}
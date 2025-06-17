using System.Text.RegularExpressions;

namespace DevSource.Stack.Notifications.Validations.Internal;

/// <summary>
/// Provides a collection of static validation methods to evaluate input strings against various
/// conditions such as length, nullability, and emptiness.
/// Offers overloads to customize error messages and handle notification or exception scenarios.
/// </summary>
public static class ValidationRuleRunners
{
    /// <summary>
    /// Validates if the provided string value meets or exceeds the specified minimum length.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="minLength">The minimum required length of the string.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and minimum length.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string value meets or exceeds the specified minimum length; otherwise, false.</returns>
    public static bool MinLength(
        string? value, int minLength, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value is not null && value.Length >= minLength) return true;

        var message = string.Format(errorMessageTemplate, key, minLength);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the provided string value meets or exceeds the specified minimum length.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction, depending on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="minLength">The minimum required length of the string.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message to be used in case of validation failure. If not provided, a predefined error message is used.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object if validation fails.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object if validation fails.</param>
    /// <param name="isCustomMessage">Indicates whether the custom message should be used. Defaults to true.</param>
    /// <returns>True if the string value meets or exceeds the specified minimum length; otherwise, false.</returns>
    public static bool MinLength(
        string? value, int minLength, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value is not null && value.Length >= minLength) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }


    /// <summary>
    /// Validates if the provided string value does not exceed the specified maximum length.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Cannot be null.</param>
    /// <param name="maxLength">The maximum allowed length of the string.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and maximum length.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string value does not exceed the specified maximum length; otherwise, false.</returns>
    public static bool MaxLength(
        string? value, int maxLength, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value is null || value.Length <= maxLength) return true;
        var message = string.Format(errorMessageTemplate, key, maxLength);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the provided string value is within the specified maximum length.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Cannot be null.</param>
    /// <param name="maxLength">The maximum allowable length of the string.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to return or use when validation fails.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether the customMessage is explicitly specified or should be generated dynamically.</param>
    /// <returns>True if the string value adheres to the specified maximum length; otherwise, false.</returns>
    public static bool MaxLength(
        string? value, int maxLength, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value is null || value.Length <= maxLength) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }


    /// <summary>
    /// Validates whether the provided value is not null. If the validation fails, it triggers either the notificationAction or exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of validation failure.</param>
    /// <returns>True if the value is not null; otherwise, false.</returns>
    public static bool IsNotNull(
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value is not null) return true;
        var message = string.Format(errorMessageTemplate, key);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the provided value is not null. If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The value to validate. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// /// <param name="customMessage">The custom message to be displayed in case of validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether a custom message should be used for validation errors.</param>
    /// <returns>True if the provided value is not null; otherwise, false.</returns>
    public static bool IsNotNull(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value is null) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }


    /// <summary>
    /// Validates whether the provided string value is not null or empty.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string value is neither null nor empty; otherwise, false.</returns>
    public static bool IsNotNullOrEmpty(
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (!string.IsNullOrEmpty(value)) return true;
        var message = string.Format(errorMessageTemplate, key);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the provided string value is not null or empty. If the validation fails, it executes the provided notificationAction or exceptionAction.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null or empty.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to use if validation fails.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether a custom message should be used for validation errors.</param>
    /// <returns>True if the string value is not null or empty; otherwise, false.</returns>
    public static bool IsNotNullOrEmpty(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (!string.IsNullOrEmpty(value)) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }


    /// <summary>
    /// Validates if the provided string value is null.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string value is null; otherwise, false.</returns>
    public static bool IsNull( // Specifically for string
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value is null) return true;
        var message = string.Format(errorMessageTemplate, key);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Determines whether the provided string value is null. If the validation fails, it triggers
    /// either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message to be displayed in case of validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether a custom message should be used for validation errors.</param>
    /// <returns>True if the provided string value is null; otherwise, false.</returns>
    public static bool IsNull(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value is null) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided string value is null or empty.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string value is null or empty; otherwise, false.</returns>
    public static bool IsNullOrEmpty(
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (string.IsNullOrEmpty(value)) return true;
        var message = string.Format(errorMessageTemplate, key);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates whether the provided string value is null or an empty string.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">A custom error message to use in case of a validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether the provided custom message should be used as is without formatting.</param>
    /// <returns>True if the value is null or an empty string; otherwise, false.</returns>
    public static bool IsNullOrEmpty(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (string.IsNullOrEmpty(value)) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided string value is null, empty, or consists only of white-space characters.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string value is null, empty, or consists only of white-space characters; otherwise, false.</returns>
    public static bool IsNullOrWhiteSpace(
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (string.IsNullOrWhiteSpace(value)) return true;
        var message = string.Format(errorMessageTemplate, key);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates whether the provided string value is null, empty, or consists only of white-space characters.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message to include in the notification or exception when validation fails.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether the customMessage is explicitly passed as a custom message. Defaults to true.</param>
    /// <returns>True if the string value is null, empty, or consists only of white-space characters; otherwise, false.</returns>
    public static bool IsNullOrWhiteSpace(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (string.IsNullOrWhiteSpace(value)) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the length of the provided string value is greater than the specified target length.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="targetLength">The target length that the string should exceed.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and target length.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string value's length exceeds the specified target length; otherwise, false.</returns>
    public static bool IsLengthGreaterThan(
        string? value, int targetLength, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value is not null && value.Length > targetLength) return true;
        var message = string.Format(errorMessageTemplate, key, targetLength);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the length of the given string is greater than the specified target length.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="targetLength">The length that the string should exceed.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message to be used in case of a validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">A flag indicating whether the provided customMessage is used as-is without further formatting.</param>
    /// <returns>True if the length of the string is greater than the specified target length; otherwise, false.</returns>
    public static bool IsLengthGreaterThan(
        string? value, int targetLength, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value is not null && value.Length > targetLength) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided string value has a length strictly less than the specified target length.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Cannot be null.</param>
    /// <param name="targetLength">The maximum allowable length for the string value.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and target length.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string value has a length strictly less than the specified target length; otherwise, false.</returns>
    public static bool IsLengthLowerThan(
        string? value, int targetLength, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value is not null && value.Length < targetLength) return true;
        var message = string.Format(errorMessageTemplate, key, targetLength);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the length of the provided string is less than the specified target length.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate. Can be null.</param>
    /// <param name="targetLength">The target length that the string should be less than.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message used for notifications or exceptions. Supports formatting with the key and target length.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether the custom message should be used as-is.</param>
    /// <returns>True if the string length is less than the target length; otherwise, false.</returns>
    public static bool IsLengthLowerThan(
        string? value, int targetLength, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value is not null && value.Length < targetLength) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided Guid value is not empty (Guid.Empty).
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The Guid value to validate.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the Guid value is not empty; otherwise, false.</returns>
    public static bool IsGuidNotEmpty(
        Guid value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value != Guid.Empty) return true;
        var message = string.Format(errorMessageTemplate, key);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates whether the provided GUID value is not empty (i.e., not equal to Guid.Empty).
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The GUID value to validate.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message for the error, which is used in case of a validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Specifies whether the customMessage should be used as-is or formatted further. Defaults to true.</param>
    /// <returns>True if the GUID value is not empty; otherwise, false.</returns>
    public static bool IsGuidNotEmpty(
        Guid value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value != Guid.Empty) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates whether the provided string value matches a specified comparison value.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The string value to validate.</param>
    /// <param name="compareValue">The string value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and comparison value.</param>
    /// <param name="comparisonType">The type of string comparison to use (e.g., case-sensitive or case-insensitive).</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the provided value matches the comparison value based on the specified comparison type; otherwise, false.</returns>
    public static bool Compare(
        string value, string compareValue, string key, string errorMessageTemplate, StringComparison comparisonType,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (string.Equals(value, compareValue, comparisonType)) return true;
        var message = string.Format(errorMessageTemplate, key, compareValue);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Compares two string values based on the specified comparison type and triggers an appropriate action if the values are not equal.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The first string value to compare. Can be null.</param>
    /// <param name="compareValue">The second string value to compare against. Can be null.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message to use in case of validation failure. Supports formatting with the key.</param>
    /// <param name="comparisonType">The type of string comparison to be used (e.g., Ordinal, OrdinalIgnoreCase).</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object if the validation fails.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object if the validation fails.</param>
    /// <param name="isCustomMessage">Determines whether the custom message should be used for the notification or exception. Default is true.</param>
    /// <returns>True if the two string values are equal based on the specified comparison type; otherwise, false.</returns>
    public static bool Compare(
        string value, string compareValue, string key, string customMessage, StringComparison comparisonType,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (string.Equals(value, compareValue, comparisonType)) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Compares the provided GUID value with the specified compareValue.
    /// If the values are not equal, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The GUID value to validate.</param>
    /// <param name="compareValue">The GUID value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and compareValue.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the GUID values are equal; otherwise, false.</returns>
    public static bool Compare(
        Guid value, Guid compareValue, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value == compareValue) return true;
        var message = string.Format(errorMessageTemplate, key, compareValue);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Compares two Guid values for equality and triggers an action in case of a mismatch.
    /// If the values are not equal, it either invokes the notificationAction with a Notification object
    /// or the exceptionAction with a DomainException object, depending on which action is provided.
    /// </summary>
    /// <param name="value">The first Guid value to compare.</param>
    /// <param name="compareValue">The second Guid value to compare against.</param>
    /// <param name="key">The key or identifier associated with the comparison validation.</param>
    /// <param name="customMessage">The custom message to use in the notification or exception when the comparison fails.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a comparison failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a comparison failure.</param>
    /// <param name="isCustomMessage">Indicates whether to use the provided custom message. Defaults to true.</param>
    /// <returns>True if the two Guid values are equal; otherwise, false.</returns>
    public static bool Compare(
        Guid value, Guid compareValue, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value == compareValue) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Compares the provided value with a given comparison value. If the values are not equal,
    /// it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The value to be compared.</param>
    /// <param name="compareValue">The value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and comparison value.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case the values do not match.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case the values do not match.</param>
    /// <returns>True if the value matches the comparison value; otherwise, false.</returns>
    public static bool Compare(double value, double compareValue, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value == compareValue) return true;
        var message = string.Format(errorMessageTemplate, key, compareValue);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Compares two double values and validates whether they are equal.
    /// If the values are not equal, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The first double value to compare.</param>
    /// <param name="compareValue">The second double value to compare against.</param>
    /// <param name="key">The key or identifier associated with this validation.</param>
    /// <param name="customMessage">The custom error message to use when validation fails.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">A flag indicating if the provided customMessage should be used as-is. Default is true.</param>
    /// <returns>True if the two double values are equal; otherwise, false.</returns>
    public static bool Compare(
        double value, double compareValue, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value == compareValue) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Compares the provided decimal value with a specified comparison value.
    /// If the values are not equal, it triggers either the notificationAction or exceptionAction
    /// based on their availability, using the provided error message template for feedback.
    /// </summary>
    /// <param name="value">The decimal value to validate.</param>
    /// <param name="compareValue">The decimal value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, supporting formatting with the key and comparison value.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of validation failure.</param>
    /// <returns>True if the value is equal to the comparison value; otherwise, false.</returns>
    public static bool Compare(
        decimal value, decimal compareValue, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value == compareValue) return true;
        var message = string.Format(errorMessageTemplate, key, compareValue);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Compares a decimal value to a specified comparison value. If the values are not equal,
    /// it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The decimal value to be compared.</param>
    /// <param name="compareValue">The decimal value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to use in case of a validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case the validation fails.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case the validation fails.</param>
    /// <param name="isCustomMessage">Indicates whether the customMessage should be used as the error message. Defaults to true.</param>
    /// <returns>True if the value equals the comparison value; otherwise, false.</returns>
    public static bool Compare(
        decimal value, decimal compareValue, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value == compareValue) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Compares two integer values to check if they are equal. If the values are not equal, it triggers the notificationAction or exceptionAction with an appropriate error message.
    /// </summary>
    /// <param name="value">The integer value to be compared.</param>
    /// <param name="compareValue">The reference integer value to compare against.</param>
    /// <param name="key">A key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, supporting formatting with the key and compareValue.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object if the values are not equal.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object if the values are not equal.</param>
    /// <returns>True if the values are equal; otherwise, false.</returns>
    public static bool Compare(int value, int compareValue, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value == compareValue) return true;
        var message = string.Format(errorMessageTemplate, key, compareValue);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Compares two integer values to determine if they are equal. If not equal, it triggers either
    /// the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The integer value to be compared.</param>
    /// <param name="compareValue">The integer value to compare against.</param>
    /// <param name="key">The key or identifier associated with the comparison validation.</param>
    /// <param name="customMessage">The custom message for the notification or exception, describing the validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object when the values do not match.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object when the values do not match.</param>
    /// <param name="isCustomMessage">Indicates whether the provided message is custom. Defaults to true.</param>
    /// <returns>True if the integer values are equal; otherwise, false.</returns>
    public static bool Compare(
        int value, int compareValue, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value == compareValue) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided string is a valid email using a custom email validation function.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The email address to validate. Cannot be null or empty.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the invalid email value.</param>
    /// <param name="emailValidationFunc">A function that performs email validation on the provided string.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string is a valid email according to the provided email validation function; otherwise, false.</returns>
    public static bool IsEmail(
        string value, string key, string errorMessageTemplate, Func<string, bool> emailValidationFunc,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (!string.IsNullOrEmpty(value) && emailValidationFunc(value)) return true; // Also check if null/empty before validation func
        var message = string.Format(errorMessageTemplate, value);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the provided string value complies with email formatting rules using the supplied validation function.
    /// If validation fails, it triggers either the notificationAction or the exceptionAction depending on their availability.
    /// </summary>
    /// <param name="value">The string value to validate as an email address. Can be null or empty.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to use in case of validation failure.</param>
    /// <param name="emailValidationFunc">A function that determines if the given string value matches email address rules.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object for a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object for a validation failure.</param>
    /// <param name="isCustomMessage">Indicates if the customMessage parameter is a user-defined message.</param>
    /// <returns>True if the string value is a valid email according to the emailValidationFunc; otherwise, false.</returns>
    public static bool IsEmail(
        string value, string key, string customMessage, Func<string, bool> emailValidationFunc,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (!string.IsNullOrEmpty(value) && emailValidationFunc(value)) return true; // Also check if null/empty
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided date value falls between the specified start and end dates (inclusive).
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The date value to validate.</param>
    /// <param name="from">The start date of the permissible date range.</param>
    /// <param name="to">The end date of the permissible date range.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key, start date, and end date.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the date value falls within the specified range (inclusive); otherwise, false.</returns>
    public static bool IsDateBetween(
        DateTime value, DateTime from, DateTime to, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value >= from && value <= to) return true;
        var message = string.Format(errorMessageTemplate, key, from, to);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if a given date falls within the specified range, inclusive of the boundary values.
    /// If the validation fails, a notification or an exception is triggered based on the provided actions.
    /// </summary>
    /// <param name="value">The date value to validate.</param>
    /// <param name="from">The beginning of the date range.</param>
    /// <param name="to">The end of the date range.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message to use in case of validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether the custom message should be used directly or formatted. Default is true.</param>
    /// <returns>True if the date value falls within the specified range; otherwise, false.</returns>
    public static bool IsDateBetween(
        DateTime value, DateTime from, DateTime to, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value >= from && value <= to) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates whether the provided DateTime value falls on the specified day of the week.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction depending on their availability.
    /// </summary>
    /// <param name="value">The DateTime value to validate.</param>
    /// <param name="dayOfWeek">The expected day of the week.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and expected day of the week.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the DateTime value falls on the specified day of the week; otherwise, false.</returns>
    public static bool IsDayOfWeek(
        DateTime value, DayOfWeek dayOfWeek, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value.DayOfWeek == dayOfWeek) return true;
        var message = string.Format(errorMessageTemplate, key, dayOfWeek);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the provided DateTime value matches the specified day of the week.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The DateTime value to validate.</param>
    /// <param name="dayOfWeek">The expected day of the week to validate against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to use in case of validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Specifies whether the customMessage should be treated as a fully custom message or used as a template.</param>
    /// <returns>True if the DateTime value matches the specified day of the week; otherwise, false.</returns>
    public static bool IsDayOfWeek(
        DateTime value, DayOfWeek dayOfWeek, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value.DayOfWeek == dayOfWeek) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided DateTime value is in the future.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The DateTime value to validate.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the DateTime value is in the future; otherwise, false.</returns>
    public static bool IsInTheFuture(
        DateTime value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value > DateTime.Now) return true;
        var message = string.Format(errorMessageTemplate, key);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates whether the provided DateTime value is in the future.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The DateTime value to validate.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to be used in case of validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether a custom message is used. Defaults to true.</param>
    /// <returns>True if the DateTime value is in the future; otherwise, false.</returns>
    public static bool IsInTheFuture(
        DateTime value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value > DateTime.Now) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided DateTime value represents a point in the past relative to the current system time.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The DateTime value to validate.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the DateTime value represents a point in the past; otherwise, false.</returns>
    public static bool IsInThePast(
        DateTime value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value < DateTime.Now) return true;
        var message = string.Format(errorMessageTemplate, key);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the provided DateTime value is in the past relative to the current system time.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The DateTime value to validate.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message to use for the error notification or exception.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether a custom message is being used. Defaults to true.</param>
    /// <returns>True if the DateTime value is in the past; otherwise, false.</returns>
    public static bool IsInThePast(
        DateTime value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value < DateTime.Now) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided numerical value is within the specified range, inclusive of the bounds.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numerical value to validate.</param>
    /// <param name="from">The lower boundary of the range.</param>
    /// <param name="to">The upper boundary of the range.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key, from, and to values.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the numerical value is within the specified range; otherwise, false.</returns>
    public static bool IsBetween(
        decimal value, decimal from, decimal to, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value >= from && value <= to) return true;
        var message = string.Format(errorMessageTemplate, key, from, to);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the provided value lies within the specified range, including the boundaries.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    /// <param name="from">The lower bound of the acceptable range.</param>
    /// <param name="to">The upper bound of the acceptable range.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to use in case of a validation failure.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether the customMessage should be used instead of a default error message.</param>
    /// <returns>True if the value lies within the specified range, including the boundaries; otherwise, false.</returns>
    public static bool IsBetween(
        decimal value, decimal from, decimal to, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value >= from && value <= to) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates whether the provided numeric value is within the specified range (inclusive).
    /// If validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="from">The lower bound of the range (inclusive).</param>
    /// <param name="to">The upper bound of the range (inclusive).</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key, from, and to.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the numeric value is within the specified range; otherwise, false.</returns>
    public static bool IsBetween(
        int value, int from, int to, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
        => IsBetween((decimal)value, (decimal)from, (decimal)to, key, errorMessageTemplate, notificationAction, exceptionAction);

    /// <summary>
    /// Validates if a given numeric value falls within a specified range (inclusive).
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="from">The lower boundary of the range.</param>
    /// <param name="to">The upper boundary of the range.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to display, which supports using the key and range values for formatting.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object if the validation fails.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object if the validation fails.</param>
    /// <param name="isCustomMessage">Indicates whether the provided message is custom or automatically generated. Defaults to true.</param>
    /// <returns>True if the numeric value is within the specified range; otherwise, false.</returns>
    public static bool IsBetween(
        int value, int from, int to, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
        => IsBetween((decimal)value, (decimal)from, (decimal)to, key, customMessage, notificationAction, exceptionAction, isCustomMessage);

    /// <summary>
    /// Validates whether a given numeric value falls within the specified range (inclusive).
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="from">The lower bound of the range (inclusive).</param>
    /// <param name="to">The upper bound of the range (inclusive).</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key, from, and to values.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the numeric value falls within the specified range; otherwise, false.</returns>
    public static bool IsBetween(
        double value, double from, double to, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
        => IsBetween((decimal)value, (decimal)from, (decimal)to, key, errorMessageTemplate, notificationAction, exceptionAction);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="key"></param>
    /// <param name="customMessage"></param>
    /// <param name="notificationAction"></param>
    /// <param name="exceptionAction"></param>
    /// <param name="isCustomMessage"></param>
    /// <returns></returns>
    public static bool IsBetween(
        double value, double from, double to, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
        => IsBetween((decimal)value, (decimal)from, (decimal)to, key, customMessage, notificationAction, exceptionAction, isCustomMessage);

    /// <summary>
    /// Validates whether the provided value is greater than the specified comparer.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and comparer.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the value is greater than the comparer; otherwise, false.</returns>
    public static bool IsGreaterThan(
        decimal value, decimal comparer, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value > comparer) return true;
        var message = string.Format(errorMessageTemplate, key, comparer);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the provided numeric value is greater than the specified comparer value.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The value to compare against, ensuring that the provided numeric value is greater.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message used when the validation fails.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether the provided message is a custom message for the validation failure.</param>
    /// <returns>True if the numeric value is greater than the specified comparer value; otherwise, false.</returns>
    public static bool IsGreaterThan(
        decimal value, decimal comparer, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value > comparer) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided numeric value is greater than the specified comparer value.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and the comparer value.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the numeric value is greater than the comparer value; otherwise, false.</returns>
    public static bool IsGreaterThan(int value, int comparer, string key, string errorMessageTemplate, Action<Notification>? notificationAction, Action<DomainException>? exceptionAction) =>
        IsGreaterThan((decimal)value, comparer, key, errorMessageTemplate, notificationAction, exceptionAction);

    /// <summary>
    /// Validates whether the specified numeric value is greater than the given comparer value.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The numeric value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message to use as the error message if validation fails.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">A flag indicating whether the customMessage parameter should be used as-is. Defaults to true.</param>
    /// <returns>True if the value is greater than the comparer; otherwise, false.</returns>
    public static bool IsGreaterThan(int value, int comparer, string key, string customMessage, Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true) =>
        IsGreaterThan((decimal)value, comparer, key, customMessage, notificationAction, exceptionAction, isCustomMessage);

    /// <summary>
    /// Validates whether the provided numeric value is greater than the specified comparer value.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and comparison values.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the numeric value is greater than the specified comparer value; otherwise, false.</returns>
    public static bool IsGreaterThan(double value, double comparer, string key, string errorMessageTemplate, Action<Notification>? notificationAction, Action<DomainException>? exceptionAction) =>
        IsGreaterThan((decimal)value, (decimal)comparer, key, errorMessageTemplate, notificationAction, exceptionAction);

    /// <summary>
    /// Validates if the provided numeric value is greater than the specified comparer value.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The numeric value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to use in case of validation failure, if isCustomMessage is true.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Specifies whether to use the provided custom message for error reporting.</param>
    /// <returns>True if the value is greater than the comparer; otherwise, false.</returns>
    public static bool IsGreaterThan(double value, double comparer, string key, string customMessage, Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true) =>
        IsGreaterThan((decimal)value, (decimal)comparer, key, customMessage, notificationAction, exceptionAction, isCustomMessage);

    /// <summary>
    /// Validates if the provided value is less than the specified comparer value.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The decimal value to validate.</param>
    /// <param name="comparer">The decimal value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and comparer value.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the value is less than the specified comparer value; otherwise, false.</returns>
    public static bool IsLowerThan(
        decimal value, decimal comparer, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value < comparer) return true;
        var message = string.Format(errorMessageTemplate, key, comparer);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates if the specified value is strictly less than the comparer.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The numeric value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to use when validation fails. This message supports formatting.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">A flag indicating whether the provided customMessage should be treated as a custom error message.</param>
    /// <returns>True if the value is strictly less than the comparer; otherwise, false.</returns>
    public static bool IsLowerThan(
        decimal value, decimal comparer, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value < comparer) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }

    /// <summary>
    /// Validates if the provided numeric value is less than the specified comparer.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The numeric value against which the provided value is compared.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and comparer value.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the numeric value is less than the comparer; otherwise, false.</returns>
    public static bool IsLowerThan(int value, int comparer, string key, string errorMessageTemplate, Action<Notification>? notificationAction, Action<DomainException>? exceptionAction) =>
        IsLowerThan((decimal)value, comparer, key, errorMessageTemplate, notificationAction, exceptionAction);

    /// <summary>
    /// Validates whether a numeric value is lower than a specified comparison value.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom error message to return in case of validation failure. If isCustomMessage is set to true, this message will be used.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether to use the customMessage parameter instead of a default error message template.</param>
    /// <returns>True if the numeric value is lower than the specified comparison value; otherwise, false.</returns>
    public static bool IsLowerThan(int value, int comparer, string key, string customMessage, Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true) =>
        IsLowerThan((decimal)value, comparer, key, customMessage, notificationAction, exceptionAction, isCustomMessage);

    /// <summary>
    /// Validates if the provided numeric value is less than the specified comparer value.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The value to compare against, representing the upper bound (exclusive).</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key and comparer value.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the provided value is less than the comparer value; otherwise, false.</returns>
    public static bool IsLowerThan(double value, double comparer, string key, string errorMessageTemplate, Action<Notification>? notificationAction, Action<DomainException>? exceptionAction) =>
        IsLowerThan((decimal)value, (decimal)comparer, key, errorMessageTemplate, notificationAction, exceptionAction);

    /// <summary>
    /// Validates if the provided numeric value is less than the specified comparer.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The numeric value to validate.</param>
    /// <param name="comparer">The value to compare against.</param>
    /// <param name="key">The key or identifier associated with the validation.</param>
    /// <param name="customMessage">The custom message to be used if validation fails.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <param name="isCustomMessage">Indicates whether a custom message is being used.</param>
    /// <returns>True if the numeric value is less than the comparer; otherwise, false.</returns>
    public static bool IsLowerThan(double value, double comparer, string key, string customMessage, Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true) =>
        IsLowerThan((decimal)value, (decimal)comparer, key, customMessage, notificationAction, exceptionAction, isCustomMessage);


    /// <summary>
    /// Validates whether the provided string value meets the requirements of a specified password pattern.
    /// If the validation fails, it triggers either the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The password string to validate. Cannot be null or empty.</param>
    /// <param name="key">The key or identifier associated with the validation error.</param>
    /// <param name="regexPattern">The regular expression pattern used to validate the password format.</param>
    /// <param name="errorMessageTemplate">The template for the error message, which supports formatting with the key.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object in case of a validation failure.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object in case of a validation failure.</param>
    /// <returns>True if the string value matches the specified password pattern; otherwise, false.</returns>
    public static bool IsPassword(
        string value, string key, string regexPattern, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (!string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, regexPattern)) return true;
        var message = string.Format(errorMessageTemplate, key);
        if (notificationAction != null) notificationAction(new Notification(key, message));
        else exceptionAction?.Invoke(new DomainException(key, message));
        return false;
    }

    /// <summary>
    /// Validates whether the provided password meets the specified requirements as defined by the regex pattern.
    /// If the validation fails, it either triggers the notificationAction or the exceptionAction based on their availability.
    /// </summary>
    /// <param name="value">The password string to validate. Cannot be null or whitespace.</param>
    /// <param name="key">The identifier or key associated with the validation.</param>
    /// <param name="regexPattern">The regular expression pattern that defines the password's required format.</param>
    /// <param name="customMessage">The custom error message to display when validation fails.</param>
    /// <param name="notificationAction">An optional action that gets triggered with a Notification object if validation fails.</param>
    /// <param name="exceptionAction">An optional action that gets triggered with a DomainException object if validation fails.</param>
    /// <param name="isCustomMessage">Indicates whether the provided error message is custom. Default is true.</param>
    /// <returns>True if the provided password meets the requirements; otherwise, false.</returns>
    public static bool IsPassword(
        string value, string key, string regexPattern, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (!string.IsNullOrWhiteSpace(value) && Regex.IsMatch(value, regexPattern)) return true;
        if (notificationAction != null) notificationAction(new Notification(key, customMessage));
        else exceptionAction?.Invoke(new DomainException(key, customMessage));
        return false;
    }
}

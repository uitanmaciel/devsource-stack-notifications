using DevSource.Stack.Notifications.Abstractions;
using System;
using System.Text.RegularExpressions;

namespace DevSource.Stack.Notifications.Validations.Internal;

public static class ValidationRuleRunners
{
    // --- MinLength ---
    public static bool MinLength(
        string value, int minLength, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value == null || value.Length < minLength)
        {
            var message = string.Format(errorMessageTemplate, key, minLength);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool MinLength(
        string value, int minLength, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value == null || value.Length < minLength)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- MaxLength ---
    public static bool MaxLength(
        string value, int maxLength, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value != null && value.Length > maxLength)
        {
            var message = string.Format(errorMessageTemplate, key, maxLength);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool MaxLength(
        string value, int maxLength, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value != null && value.Length > maxLength)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- IsNotNull (for string) ---
    public static bool IsNotNull( // Specifically for string to avoid ambiguity with a generic object version if added later
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value == null)
        {
            var message = string.Format(errorMessageTemplate, key);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsNotNull(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value == null)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- IsNotNullOrEmpty ---
    public static bool IsNotNullOrEmpty(
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (string.IsNullOrEmpty(value))
        {
            var message = string.Format(errorMessageTemplate, key);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsNotNullOrEmpty(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (string.IsNullOrEmpty(value))
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- IsNull (for string) ---
    public static bool IsNull( // Specifically for string
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value != null)
        {
            var message = string.Format(errorMessageTemplate, key);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsNull(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value != null)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- IsNullOrEmpty ---
    public static bool IsNullOrEmpty(
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (!string.IsNullOrEmpty(value))
        {
            var message = string.Format(errorMessageTemplate, key);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsNullOrEmpty(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (!string.IsNullOrEmpty(value))
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- IsNullOrWhiteSpace ---
    public static bool IsNullOrWhiteSpace(
        string? value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            var message = string.Format(errorMessageTemplate, key);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsNullOrWhiteSpace(
        string? value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- IsLengthGreaterThan ---
    public static bool IsLengthGreaterThan(
        string value, int targetLength, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value == null || value.Length <= targetLength)
        {
            var message = string.Format(errorMessageTemplate, key, targetLength);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsLengthGreaterThan(
        string value, int targetLength, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value == null || value.Length <= targetLength)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- IsLengthLowerThan ---
    public static bool IsLengthLowerThan(
        string value, int targetLength, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value == null || value.Length >= targetLength)
        {
            var message = string.Format(errorMessageTemplate, key, targetLength);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsLengthLowerThan(
        string value, int targetLength, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value == null || value.Length >= targetLength)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- IsGuidNotEmpty ---
    public static bool IsGuidNotEmpty(
        Guid value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value == Guid.Empty)
        {
            var message = string.Format(errorMessageTemplate, key);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsGuidNotEmpty(
        Guid value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value == Guid.Empty)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- Compare (string) ---
    public static bool Compare(
        string value, string compareValue, string key, string errorMessageTemplate, StringComparison comparisonType,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (!string.Equals(value, compareValue, comparisonType))
        {
            var message = string.Format(errorMessageTemplate, key, compareValue);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool Compare(
        string value, string compareValue, string key, string customMessage, StringComparison comparisonType,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (!string.Equals(value, compareValue, comparisonType))
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- Compare (Guid) ---
    public static bool Compare(
        Guid value, Guid compareValue, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value != compareValue)
        {
            var message = string.Format(errorMessageTemplate, key, compareValue);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool Compare(
        Guid value, Guid compareValue, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value != compareValue)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- IsEmail ---
    public static bool IsEmail(
        string value, string key, string errorMessageTemplate, Func<string, bool> emailValidationFunc,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (string.IsNullOrEmpty(value) || !emailValidationFunc(value)) // Also check if null/empty before validation func
        {
            var message = string.Format(errorMessageTemplate, value);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsEmail(
        string value, string key, string customMessage, Func<string, bool> emailValidationFunc,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (string.IsNullOrEmpty(value) || !emailValidationFunc(value)) // Also check if null/empty
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- DateTime Validations ---
    public static bool IsDateBetween(
        DateTime value, DateTime from, DateTime to, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value < from || value > to)
        {
            var message = string.Format(errorMessageTemplate, key, from, to);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsDateBetween(
        DateTime value, DateTime from, DateTime to, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value < from || value > to)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    public static bool IsDayOfWeek(
        DateTime value, DayOfWeek dayOfWeek, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value.DayOfWeek != dayOfWeek)
        {
            var message = string.Format(errorMessageTemplate, key, dayOfWeek);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsDayOfWeek(
        DateTime value, DayOfWeek dayOfWeek, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value.DayOfWeek != dayOfWeek)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    public static bool IsInTheFuture(
        DateTime value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value <= DateTime.Now)
        {
            var message = string.Format(errorMessageTemplate, key);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsInTheFuture(
        DateTime value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value <= DateTime.Now)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    public static bool IsInThePast(
        DateTime value, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value >= DateTime.Now)
        {
            var message = string.Format(errorMessageTemplate, key);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsInThePast(
        DateTime value, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value >= DateTime.Now)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // --- Number Validations (using decimal for precision, can add overloads for int, double) ---
    public static bool IsBetween(
        decimal value, decimal from, decimal to, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value < from || value > to)
        {
            var message = string.Format(errorMessageTemplate, key, from, to);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsBetween(
        decimal value, decimal from, decimal to, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value < from || value > to)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // Overloads for int
    public static bool IsBetween(
        int value, int from, int to, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
        => IsBetween((decimal)value, (decimal)from, (decimal)to, key, errorMessageTemplate, notificationAction, exceptionAction);

    public static bool IsBetween(
        int value, int from, int to, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
        => IsBetween((decimal)value, (decimal)from, (decimal)to, key, customMessage, notificationAction, exceptionAction, isCustomMessage);

    // Overloads for double
    public static bool IsBetween(
        double value, double from, double to, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
        => IsBetween((decimal)value, (decimal)from, (decimal)to, key, errorMessageTemplate, notificationAction, exceptionAction);

    public static bool IsBetween(
        double value, double from, double to, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
        => IsBetween((decimal)value, (decimal)from, (decimal)to, key, customMessage, notificationAction, exceptionAction, isCustomMessage);


    public static bool IsGreaterThan(
        decimal value, decimal comparer, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value <= comparer)
        {
            var message = string.Format(errorMessageTemplate, key, comparer);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsGreaterThan(
        decimal value, decimal comparer, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value <= comparer)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // Overloads for int, double for IsGreaterThan (delegating to decimal version)
    public static bool IsGreaterThan(int value, int comparer, string key, string errorMessageTemplate, Action<Notification>? n, Action<DomainException>? e) => IsGreaterThan((decimal)value, comparer, key, errorMessageTemplate, n, e);
    public static bool IsGreaterThan(int value, int comparer, string key, string customMessage, Action<Notification>? n, Action<DomainException>? e, bool i = true) => IsGreaterThan((decimal)value, comparer, key, customMessage, n, e, i);
    public static bool IsGreaterThan(double value, double comparer, string key, string errorMessageTemplate, Action<Notification>? n, Action<DomainException>? e) => IsGreaterThan((decimal)value, (decimal)comparer, key, errorMessageTemplate, n, e);
    public static bool IsGreaterThan(double value, double comparer, string key, string customMessage, Action<Notification>? n, Action<DomainException>? e, bool i = true) => IsGreaterThan((decimal)value, (decimal)comparer, key, customMessage, n, e, i);


    public static bool IsLowerThan(
        decimal value, decimal comparer, string key, string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        if (value >= comparer)
        {
            var message = string.Format(errorMessageTemplate, key, comparer);
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsLowerThan(
        decimal value, decimal comparer, string key, string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (value >= comparer)
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }

    // Overloads for int, double for IsLowerThan (delegating to decimal version)
    public static bool IsLowerThan(int value, int comparer, string key, string errorMessageTemplate, Action<Notification>? n, Action<DomainException>? e) => IsLowerThan((decimal)value, comparer, key, errorMessageTemplate, n, e);
    public static bool IsLowerThan(int value, int comparer, string key, string customMessage, Action<Notification>? n, Action<DomainException>? e, bool i = true) => IsLowerThan((decimal)value, comparer, key, customMessage, n, e, i);
    public static bool IsLowerThan(double value, double comparer, string key, string errorMessageTemplate, Action<Notification>? n, Action<DomainException>? e) => IsLowerThan((decimal)value, (decimal)comparer, key, errorMessageTemplate, n, e);
    public static bool IsLowerThan(double value, double comparer, string key, string customMessage, Action<Notification>? n, Action<DomainException>? e, bool i = true) => IsLowerThan((decimal)value, (decimal)comparer, key, customMessage, n, e, i);


    // --- Password Validation ---
    // The regex pattern should be the one that already includes length {minLength,}
    public static bool IsPassword(
        string value, string key, string regexPattern, /* int minLength, */ string errorMessageTemplate,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction)
    {
        // Assuming regexPattern already incorporates minLength, e.g., by string interpolation before calling
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, regexPattern))
        {
            var message = string.Format(errorMessageTemplate, key); // Error.Invalid(key)
            if (notificationAction != null) notificationAction(new Notification(key, message));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, message));
            return false;
        }
        return true;
    }

    public static bool IsPassword(
        string value, string key, string regexPattern, /* int minLength, */ string customMessage,
        Action<Notification>? notificationAction, Action<DomainException>? exceptionAction, bool isCustomMessage = true)
    {
        if (string.IsNullOrWhiteSpace(value) || !Regex.IsMatch(value, regexPattern))
        {
            if (notificationAction != null) notificationAction(new Notification(key, customMessage));
            else if (exceptionAction != null) exceptionAction(new DomainException(key, customMessage));
            return false;
        }
        return true;
    }
}

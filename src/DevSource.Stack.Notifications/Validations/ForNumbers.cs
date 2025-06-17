using DevSource.Stack.Notifications.Validations.Internal; // Added this
using System; // For Action

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRules<T>
{
    // --- IsGreaterThan ---
    public ValidationRules<T> IsGreaterThan(string key, double value, double comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsGreaterThan(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsGreaterThan(string key, int value, int comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsGreaterThan(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsGreaterThan(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsGreaterThan(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    // --- IsLowerThan ---
    public ValidationRules<T> IsLowerThan(string key, double value, double comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsLowerThan(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsLowerThan(string key, int value, int comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsLowerThan(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsLowerThan(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsLowerThan(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    // --- IsBetween ---
    public ValidationRules<T> IsBetween(string key, double value, double min, double max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsBetween(string key, double value, double min, double max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsBetween(string key, decimal value, decimal min, decimal max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsBetween(string key, decimal value, decimal min, decimal max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsBetween(string key, int value, int min, int max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    public ValidationRules<T> IsBetween(string key, int value, int min, int max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, this.AddNotification, null, isCustomMessage: true);
        return this;
    }

    // --- Compare ---
    // Note: ValidationRuleRunners.Compare for numbers doesn't exist yet.
    // For now, these will remain as they are. If Compare runners for numbers are added, these can be updated.
    // This also means Error.Compare(key, comparer) for numbers is used directly.
    public ValidationRules<T> Compare(string key, double value, double comparer)
    {
        if(value != comparer)
            AddNotification(new Notification(Error.Compare(key, comparer)));
        return this;
    }
    
    public ValidationRules<T> Compare(string key, double value, double comparer, string message)
    {
        if(value != comparer)
            AddNotification(new Notification(key, message));
        return this;
    }
    
    public ValidationRules<T> Compare(string key, int value, int comparer)
    {
        if(value != comparer)
            AddNotification(new Notification(Error.Compare(key, comparer)));
        return this;
    }
    
    public ValidationRules<T> Compare(string key, int value, int comparer, string message)
    {
        if(value != comparer)
            AddNotification(new Notification(key, message));
        return this;
    }
    
    public ValidationRules<T> Compare(string key, decimal value, decimal comparer)
    {
        if(value != comparer)
            AddNotification(new Notification(Error.Compare(key, comparer)));
        return this;
    }
    
    public ValidationRules<T> Compare(string key, decimal value, decimal comparer, string message)
    {
        if(value != comparer)
            AddNotification(new Notification(key, message));
        return this;
    }
}
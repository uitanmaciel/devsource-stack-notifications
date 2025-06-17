using DevSource.Stack.Notifications.Abstractions; // Required for DomainException
using DevSource.Stack.Notifications.Validations.Internal; // Added this
using System; // For Action

namespace DevSource.Stack.Notifications.Validations;

public partial class ValidationRulesException<T>
{
    // --- IsGreaterThan ---
    public ValidationRulesException<T> IsGreaterThan(string key, double value, double comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsGreaterThan(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsGreaterThan(string key, int value, int comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsGreaterThan(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsGreaterThan(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, Error.IsGreaterThan(key, comparer), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsGreaterThan(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.IsGreaterThan(value, comparer, key, message, null, this.PublishException, isCustomMessage: true);
        return this;
    }

    // --- IsLowerThan ---
    public ValidationRulesException<T> IsLowerThan(string key, double value, double comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsLowerThan(string key, double value, double comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsLowerThan(string key, int value, int comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsLowerThan(string key, int value, int comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsLowerThan(string key, decimal value, decimal comparer)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, Error.IsLowerThan(key, comparer), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsLowerThan(string key, decimal value, decimal comparer, string message)
    {
        ValidationRuleRunners.IsLowerThan(value, comparer, key, message, null, this.PublishException, isCustomMessage: true);
        return this;
    }

    // --- IsBetween ---
    public ValidationRulesException<T> IsBetween(string key, double value, double min, double max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsBetween(string key, double value, double min, double max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsBetween(string key, decimal value, decimal min, decimal max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsBetween(string key, decimal value, decimal min, decimal max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsBetween(string key, int value, int min, int max)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, Error.IsBetween(key, min, max), null, this.PublishException, isCustomMessage: true);
        return this;
    }

    public ValidationRulesException<T> IsBetween(string key, int value, int min, int max, string message)
    {
        ValidationRuleRunners.IsBetween(value, min, max, key, message, null, this.PublishException, isCustomMessage: true);
        return this;
    }

    // --- Compare ---
    // Note: ValidationRuleRunners.Compare for numbers doesn't exist yet.
    // These will remain as they are.
    public ValidationRulesException<T> Compare(string key, double value, double comparer)
    {
        if(value != comparer)
            PublishException(new DomainException(Error.Compare(key, comparer)));
        return this;
    }
    
    public ValidationRulesException<T> Compare(string key, double value, double comparer, string message)
    {
        if(value != comparer)
            PublishException(new DomainException(key, message));
        return this;
    }
    
    public ValidationRulesException<T> Compare(string key, int value, int comparer)
    {
        if(value != comparer)
            PublishException(new DomainException(Error.Compare(key, comparer)));
        return this;
    }
    
    public ValidationRulesException<T> Compare(string key, int value, int comparer, string message)
    {
        if(value != comparer)
            PublishException(new DomainException(key, message));
        return this;
    }
    
    public ValidationRulesException<T> Compare(string key, decimal value, decimal comparer)
    {
        if(value != comparer)
            PublishException(new DomainException(Error.Compare(key, comparer)));
        return this;
    }
    
    public ValidationRulesException<T> Compare(string key, decimal value, decimal comparer, string message)
    {
        if(value != comparer)
            PublishException(new DomainException(key, message));
        return this;
    }
}
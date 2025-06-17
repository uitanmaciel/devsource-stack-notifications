namespace DevSource.Stack.Notifications.Validations;

/// <summary>
/// A class that provides validation rules for objects of type <typeparamref name="T"/>. 
/// Inherits from <see cref="ExceptionHandler"/> to support exception management.
/// </summary>
/// <typeparam name="T">The type of object to validate.</typeparam>
public partial class ValidationRulesException<T> : ExceptionHandler
{
    /// <summary>
    /// Publishes (collects) exceptions from another exception handler instance.
    /// </summary>
    /// <param name="handler">The IExceptionHandler instance from which to collect exceptions.</param>
    /// <returns>The current instance of <see cref="ValidationRulesException{T}"/>.</returns>
    public ValidationRulesException<T> PublishExceptions(IExceptionHandler handler)
    {
        if (handler?.DomainExceptions == null)
            return this;

        foreach (var exception in handler.DomainExceptions)
        {
            PublishException(exception);
        }
        return this;
    }

    // The Join method has been removed as ValidationRulesException should not be joining Notifier instances.
}
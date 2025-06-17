using DevSource.Stack.Notifications.Interfaces;

namespace DevSource.Stack.Notifications;

/// <summary>
/// Handles the collection and publication of domain exceptions.
/// </summary>
public class ExceptionHandler : IExceptionHandler
{
    private readonly List<DomainException> _domainExceptions = new();

    /// <summary>
    /// Gets the list of domain exceptions.
    /// </summary>
    public IReadOnlyCollection<DomainException> DomainExceptions => _domainExceptions.AsReadOnly();

    /// <summary>
    /// Publishes a single domain exception.
    /// </summary>
    /// <param name="exception">The domain exception to publish.</param>
    public void PublishException(DomainException exception)
    {
        _domainExceptions.Add(exception);
    }

    /// <summary>
    /// Publishes a collection of domain exceptions.
    /// </summary>
    /// <param name="exceptions">The collection of domain exceptions to publish.</param>
    public void PublishException(IEnumerable<DomainException> exceptions)
    {
        if (exceptions is null || !exceptions.Any())
            return;

        _domainExceptions.AddRange(exceptions);
    }

    /// <summary>
    /// Publishes domain exceptions from another IException instance.
    /// </summary>
    /// <param name="exceptionHandler">The IException instance from which to publish exceptions.</param>
    public void PublishException(IException exceptionHandler)
    {
        if (exceptionHandler?.DomainExceptions == null || !exceptionHandler.DomainExceptions.Any())
            return;

        PublishException(exceptionHandler.DomainExceptions);
    }

    /// <summary>
    /// Gets a value indicating whether there are any exceptions present.
    /// </summary>
    public bool HasExceptions => _domainExceptions.Any();

    /// <summary>
    /// Throws the collected exceptions.
    /// If only one exception is present, it's thrown directly.
    /// If multiple exceptions are present, they are thrown as an AggregateException.
    /// </summary>
    /// <param name="clearExceptionsAfterThrowing">Whether to clear the exception list after throwing.</param>
    public void ThrowCollectedExceptions(bool clearExceptionsAfterThrowing = true)
    {
        if (!_domainExceptions.Any())
            return;

        if (_domainExceptions.Count == 1)
        {
            var singleException = _domainExceptions.First();
            if (clearExceptionsAfterThrowing)
            {
                _domainExceptions.Clear();
            }
            throw singleException;
        }
        else
        {
            var aggregateException = new AggregateException(_domainExceptions);
            if (clearExceptionsAfterThrowing)
            {
                _domainExceptions.Clear();
            }
            throw aggregateException;
        }
    }

    /// <summary>
    /// Clears all collected exceptions.
    /// </summary>
    public void ClearExceptions()
    {
        _domainExceptions.Clear();
    }
}

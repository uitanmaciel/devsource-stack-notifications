<div align="center">
    <img src="https://github.com/uitanmaciel/devsource-stack-notifications/blob/main/src/DevSource.Stack.Notifications/devsource-icon.jpeg" 
         width="130"
    />  
</div>

# DevSource.Stack.Notifications

[![NuGet](https://img.shields.io/nuget/v/DevSource.Stack.Notifications.svg)](https://www.nuget.org/packages/DevSource.Stack.Notifications/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/DevSource.Stack.Notifications.svg)](https://www.nuget.org/packages/DevSource.Stack.Notifications/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)](https://dotnet.microsoft.com/)

This library is an implementation for application-level Notifications, designed to facilitate error handling and validation in a systematic and flexible way, allowing the developer to avoid throwing exceptions throughout the system. It allows errors and messages to be accumulated throughout the process flow, enabling a cohesive response mechanism.

DevSource.Stack.Notifications is an integral part of the DevSource ecosystem.

## Features

- **Validation Rules:** Comprehensive validation rules for strings, numbers, dates, emails, passwords, documents, phones, collections, credit cards, and files
- **Notification Pattern:** Implement the Notification Pattern to avoid throwing exceptions throughout your application
- **Fluent API:** Chainable validation methods for clean and readable code
- **Custom Messages:** Support for custom error messages on all validations
- **Brazilian Document Validation:** Built-in support for CPF and CNPJ validation
- **Phone Validation:** Support for Brazilian and international phone formats
- **Collection Validation:** Validate collections and enumerables with ease
- **Credit Card Validation:** Luhn algorithm implementation for credit card validation
- **File Validation:** Validate file sizes, extensions, and MIME types
- **Conditional Validation:** Execute validations conditionally with When, RequireAtLeastOne, and AllOrNone
- **Type-Safe:** Generic implementation with strong typing support
- **Lightweight:** Zero external dependencies, pure .NET implementation
- **Well-Tested:** Comprehensive test suite with 130+ tests ensuring reliability

## Requirements

- **.NET 8.0** or higher
- No external dependencies required

## Getting Started

### Installation

Install the package from NuGet:

```bash
dotnet add package DevSource.Stack.Notifications
```

### Basic Setup

Inherit from `Notifier` class in your domain entities or services:

```csharp
using DevSource.Stack.Notifications;

public class User : Notifier
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
```

## Usage Examples

### Basic Validation

```csharp
using DevSource.Stack.Notifications;
using DevSource.Stack.Notifications.Validations;

public class User : Notifier
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public Task<bool> Create()
    {
        ValidateFields();

        if (HasNotifications) // Check for validation errors
            return Task.FromResult(false);

        // Business logic to create user
        return Task.FromResult(true);
    }

    private void ValidateFields()
    {
        AddNotifications(new ValidationRules<User>()
            .IsNotNull(nameof(Name), Name)
            .MinLength(nameof(Name), Name, 3)
            .IsNotNullOrEmpty(nameof(Email), Email) // Required field
            .IsEmail(nameof(Email), Email)
            .IsNotNullOrEmpty(nameof(Password), Password) // Required field
            .IsPassword(nameof(Password), Password, 8)
        );
    }
}
```

### Handling Notifications

Check the `Notifications` property to capture validation errors:

```csharp
var user = new User("John Doe", "invalid-email", "short");
var result = await user.Create();

if (result)
{
    Console.WriteLine("User created successfully!");
}
else
{
    foreach (var notification in user.Notifications)
    {
        Console.WriteLine($"{notification.Key}: {notification.Message}");
    }
}
```

**Output:**
```
Email: The 'Email' is not a valid email
Password: The value of field 'Password' is invalid
```

### Custom Error Messages

You can provide custom error messages for any validation:

```csharp
AddNotifications(new ValidationRules<User>()
    .IsNotNull(nameof(Name), Name, "Name is required")
    .MinLength(nameof(Name), Name, 3, "Name must have at least 3 characters")
    .IsEmail(nameof(Email), Email, "Please provide a valid email address")
);
```

### String Validations

```csharp
AddNotifications(new ValidationRules<Product>()
    .IsNotNull(nameof(Name), Name)
    .MinLength(nameof(Name), Name, 3)
    .MaxLength(nameof(Name), Name, 100)
    .MinLength(nameof(Description), Description, 10)
);
```

### Number Validations

```csharp
AddNotifications(new ValidationRules<Product>()
    .IsGreaterThan(nameof(Price), Price, 0)
    .IsLowerThan(nameof(Discount), Discount, 100)
    .IsBetween(nameof(Stock), Stock, 0, 1000)
);
```

### DateTime Validations

```csharp
AddNotifications(new ValidationRules<Event>()
    .IsInTheFuture(nameof(StartDate), StartDate)
    .IsDateBetween(nameof(EndDate), EndDate, DateTime.Now, DateTime.Now.AddYears(1))
    .IsDayOfWeek(nameof(StartDate), StartDate, DayOfWeek.Monday)
);
```

### Brazilian Document Validations

```csharp
AddNotifications(new ValidationRules<Customer>()
    .IsNotNullOrEmpty(nameof(Cpf), Cpf) // Required
    .IsCpf(nameof(Cpf), Cpf) // Validates CPF format and check digits
    .IsCnpj(nameof(Cnpj), Cnpj) // Optional: Validates CNPJ internally checks for empty
);
```

### Phone Validations

```csharp
AddNotifications(new ValidationRules<Contact>()
    .IsBrazilianPhone(nameof(Phone), Phone) // (XX) XXXXX-XXXX
    .IsInternationalPhone(nameof(InternationalPhone), InternationalPhone) // +55XXXXXXXXXXX
);
```

### Collection Validations

```csharp
AddNotifications(new ValidationRules<Order>()
    .IsNotEmpty(nameof(Items), Items)
    .HasMinItems(nameof(Items), Items, 1)
    .HasMaxItems(nameof(Items), Items, 10)
    .HasExactItems(nameof(Items), Items, 5)
    .HasUniqueItems(nameof(Tags), Tags)
    .ContainsItem(nameof(Categories), Categories, "Electronics")
);
```

### Credit Card Validations

```csharp
AddNotifications(new ValidationRules<Payment>()
    .IsCreditCard(nameof(CardNumber), CardNumber) // Luhn algorithm
    .IsCreditCardNotExpired(nameof(ExpiryDate), ExpiryMonth, ExpiryYear)
);
```

#### File Validations

| Method | Description | Example |
|--------|-------------|---------|
| `HasMaxFileSize(key, size, maxSize)` | Validates file size limit | `.HasMaxFileSize("File", size, 5_000_000)` |
| `HasValidExtension(key, fileName, extensions)` | Validates file extension | `.HasValidExtension("File", name, ".jpg", ".png")` |
| `HasValidMimeType(key, mimeType, allowedTypes)` | Validates MIME type | `.HasValidMimeType("File", type, "image/jpeg")` |

#### Conditional Validations

| Method | Description | Example |
|--------|-------------|---------|
| `When(condition, action)` | Executes validations when condition is true | `.When(isActive, r => r.IsNotNull("Name", name))` |
| `When(conditionFunc, action)` | Executes validations when function returns true | `.When(() => age < 18, r => r.IsNotNull(...))` |
| `RequireAtLeastOne(params values)` | Validates at least one value is not null/empty | `.RequireAtLeastOne(email, phone, address)` |
| `AllOrNone(params values)` | Validates all values are filled or all are empty | `.AllOrNone(state, city, zipCode)` |

### Conditional Validations

```csharp
AddNotifications(new ValidationRules<User>()
    .When(user.IsCompany, rules => rules
        .IsNotNull(nameof(CompanyName), CompanyName)
        .IsCnpj(nameof(Cnpj), Cnpj))
    .When(() => user.Age < 18, rules => rules
        .IsNotNull(nameof(ParentName), ParentName))
    .RequireAtLeastOne(Email, Phone) // At least one must be filled
    .AllOrNone(State, City, ZipCode) // All or none must be filled
);
```

### Combining Multiple Validators

You can combine validations from different notifiers:

```csharp
var addressValidator = new ValidationRules<Address>()
    .IsNotNull(nameof(Street), address.Street)
    .IsNotNull(nameof(City), address.City);

var userValidator = new ValidationRules<User>()
    .IsNotNull(nameof(Name), Name)
    .IsEmail(nameof(Email), Email)
    .Join(addressValidator); // Combine validations

AddNotifications(userValidator);
```

## API Reference

### Available Validations

#### String Validations

| Method | Description | Example |
|--------|-------------|---------|
| `IsNotNull(key, value)` | Validates that string is not null or empty | `.IsNotNull("Name", name)` |
| `MinLength(key, value, minLength)` | Validates minimum string length | `.MinLength("Name", name, 3)` |
| `MaxLength(key, value, maxLength)` | Validates maximum string length | `.MaxLength("Name", name, 100)` |

#### Number Validations

| Method | Description | Example |
|--------|-------------|---------|
| `IsGreaterThan(key, value, comparer)` | Validates number is greater than specified value | `.IsGreaterThan("Price", price, 0)` |
| `IsLowerThan(key, value, comparer)` | Validates number is lower than specified value | `.IsLowerThan("Discount", discount, 100)` |
| `IsBetween(key, value, from, to)` | Validates number is within range | `.IsBetween("Age", age, 18, 65)` |

*Supports: `int`, `double`, `decimal`*

#### DateTime Validations

| Method | Description | Example |
|--------|-------------|---------|
| `IsInTheFuture(key, value)` | Validates date is in the future | `.IsInTheFuture("EventDate", date)` |
| `IsInThePast(key, value)` | Validates date is in the past | `.IsInThePast("BirthDate", date)` |
| `IsDateBetween(key, value, from, to)` | Validates date is within range | `.IsDateBetween("Date", date, start, end)` |
| `IsDayOfWeek(key, value, dayOfWeek)` | Validates specific day of week | `.IsDayOfWeek("Date", date, DayOfWeek.Monday)` |

#### Email & Password Validations

| Method | Description | Example |
|--------|-------------|---------|
| `IsEmail(key, value)` | Validates email format | `.IsEmail("Email", email)` |
| `IsPassword(key, value, minLength)` | Validates password strength | `.IsPassword("Password", pass, 8)` |

### Core Classes

#### Notifier

Base class that provides notification management capabilities:

```csharp
public class Notifier
{
    public IReadOnlyCollection<Notification> Notifications { get; }
    public bool HasNotifications { get; }
    
    protected void AddNotification(Notification notification)
    protected void AddNotifications(IEnumerable<Notification> notifications)
    protected void AddNotifications(params Notifier[] notifiers)
    protected void ClearNotifications()
}
```

#### ValidationRules&lt;T&gt;

Fluent validation builder:

```csharp
public class ValidationRules<T> : Notifier
{
    public ValidationRules<T> Join(params Notifier[] notifiers)
    // All validation methods return ValidationRules<T> for chaining
}
```

#### Notification

Represents a single notification:

```csharp
public class Notification
{
    public string Key { get; }
    public string Message { get; }
}
```

## Integration with ASP.NET Core

### Minimal API Example

```csharp
app.MapPost("/users", async (CreateUserRequest request) =>
{
    var user = new User(request.Name, request.Email, request.Password);
    var result = await user.Create();
    
    if (!result)
        return Results.BadRequest(new { errors = user.Notifications });
    
    return Results.Created($"/users/{user.Id}", user);
});
```

### Controller Example

```csharp
[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        var user = new User(request.Name, request.Email, request.Password);
        var result = await user.Create();
        
        if (!result)
            return BadRequest(new { errors = user.Notifications });
        
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }
}
```

### Custom Validation Middleware

```csharp
public class NotificationMiddleware
{
    private readonly RequestDelegate _next;

    public NotificationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new 
            { 
                errors = ex.Notifications 
            });
        }
    }
}
```

## Running the tests

To run the tests, use the following command:

```bash
dotnet test
```

To run with coverage:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Author

**Uitan Maciel** - [GitHub Profile](https://github.com/uitanmaciel)

---

<div align="center">
Made with ❤️ by the DevSource community
</div>
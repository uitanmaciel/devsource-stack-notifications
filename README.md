<div align="center">
    <img src="https://github.com/uitanmaciel/devsource-stack-notifications/blob/main/src/DevSource.Stack.Notifications/devsource-icon.jpeg" 
         width="130"
    />  
</div>

# DevSource.Stack.Notifications

This library is an implementation for application-level Notifications, designed to facilitate error handling and validation in a systematic and flexible way, allowing the developer to avoid throwing exceptions throughout the system. It allows errors and messages to be accumulated throughout the process flow, enabling a cohesive response mechanism.

DevSource.Stack.Notifications is an integral part of the DevSource ecosystem.

## Features

- **Validation Rules:** Customizable rules for validating strings, emails, passwords, and more, ensuring data integrity and consistency across your application.
- **Notification Handling:** Centralized management of notifications, providing a seamless way to collect and respond to errors and messages.
- **Test Suites:** Included test suites for email validation, ensuring the robustness and reliability of your email-related operations.

## Getting Started

To integrate this library into your project:

**1- Setup:** Include the library files in your project directory by installing directly from the NuGet repository.
```bash
    dotnet add package DevSource.Stack.Notifications
```

**2- Initialization:** Instantiate the Notifier and integrate it with your project's flow. Example:
```bash
    using DevSource.Stack.Notifications;

    public class User : Notifier
    {...}
```

**3- Usage:** Utilize the provided utilities and validations to manage errors and notifications throughout your application.
```bash
using DevSource.Stack.Notifications;
using DevSource.Stack.Notifications.Validations;

public class User() : Notifier
{
    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;

    public User(string name, string email, string password) : this()
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public Task<bool> Create()
    {
        ValidationFields();

        if(HasNotifications) //Checking for notifications
            return Task.FromResult(false);

        //Here comes the logic to create user
            
        return Task.FromResult(true);
    }

    private void ValidationFields()
    {
        AddNotifications(new ValidationRules<User>()
            .IsEmail(nameof(Email), Email)
            .IsPassword(nameof(Password), Password, 8)
        );
                
    }
}
```

**4- Capturing the notifications:** To capture the notifications, you can check the Notifications property. Example:
```bash
using DevSourceNotifications;

var user = new User("John Doe", "email", "yourpassword");

var result = await user.Create();

if(result)
    Console.WriteLine("User created");
else
{
    foreach(var notification in user.Notifications)
    {
        Console.WriteLine(notification.Message);
    }
}
```

## Running the tests

To run the tests, run the following command

```bash
  dotnet test
```
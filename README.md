# clean-code-dotnet

## Table of Contents
  1. [Introduction](#introduction)
  2. [Variables](#variables)
  3. [Functions](#functions)
  4. [Objects and Data Structures](#objects-and-data-structures)
  5. [Classes](#classes)
  6. [SOLID](#solid)
  7. [Testing](#testing)
  8. [Concurrency](#concurrency)
  9. [Error Handling](#error-handling)
  10. [Formatting](#formatting)
  11. [Comments](#comments)

## Introduction
![Humorous image of software quality estimation as a count of how many expletives you shout when reading code](http://www.osnews.com/images/comics/wtfm.jpg)

Software engineering principles, from Robert C. Martin's book [*Clean Code*](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882), adapted for .NET and .NET Core. This is not a style guide. It's a guide to producing readable, reusable, and refactorable software in .NET and .NET Core.

Not every principle herein has to be strictly followed, and even fewer will be universally agreed upon. These are guidelines and nothing more, but they are ones codified over many years of collective experience by the authors of *Clean Code*.

Inspired from [clean-code-javascript](https://github.com/ryanmcdermott/clean-code-javascript) and [clean-code-php](https://github.com/jupeter/clean-code-php)

## **Variables**

### Use meaningful and pronounceable variable names

**Bad:**

```csharp
var ymdstr = moment.Format('y-m-d');
```

**Good:**

```csharp
var currentDate = moment.Format('y-m-d');
```

**[⬆ back to top](#table-of-contents)**

### Use the same vocabulary for the same type of variable

**Bad:**

```csharp
GetUserInfo();
GetUserData();
GetUserRecord();
GetUserProfile();
```

**Good:**

```csharp
GetUser();
```

**[⬆ back to top](#table-of-contents)**

### Use searchable names (part 1)

We will read more code than we will ever write. It's important that the code we do write is 
readable and searchable. By *not* naming variables that end up being meaningful for 
understanding our program, we hurt our readers.
Make your names searchable.

**Bad:**

```csharp
// What the heck is 448 for?
var result = serializer.Serialize(data, 448);
```

**Good:**

```csharp
var json = serializer.Serialize(data, JSON_UNESCAPED_SLASHES | JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE);
```

### Use searchable names (part 2)

**Bad:**

```csharp
// What the heck is 4 for?
if (user.Access & 4) {
    // ...
}
```

**Good:**

```csharp
public enum UserEnum
{
    const int ACCESS_READ = 1;
    const int ACCESS_CREATE = 2;
    const int ACCESS_UPDATE = 4;
    const int ACCESS_DELETE = 8;
}

if (user.Access & UserEnum.ACCESS_UPDATE) {
    // do edit ...
}
```

**[⬆ back to top](#table-of-contents)**

### Use explanatory variables

**Bad:**

```csharp
var address = 'One Infinite Loop, Cupertino 95014';
var cityZipCodeRegex = '/^[^,\\]+[,\\\s]+(.+?)\s*(\d{5})?$/';
preg_match(cityZipCodeRegex, address, matches);

SaveCityZipCode(matches[1], matches[2]);
```

**Not bad:**

It's better, but we are still heavily dependent on regex.

```csharp
var address = 'One Infinite Loop, Cupertino 95014';
var cityZipCodeRegex = '/^[^,\\]+[,\\\s]+(.+?)\s*(\d{5})?$/';
preg_match(cityZipCodeRegex, address, matches);

list(, city, zipCode) = matches;
SaveCityZipCode(city, zipCode);
```

**Good:**

Decrease dependence on regex by naming subpatterns.

```csharp
var address = 'One Infinite Loop, Cupertino 95014';
var cityZipCodeRegex = '/^[^,\\]+[,\\\s]+(?<city>.+?)\s*(?<zipCode>\d{5})?$/';
preg_match(cityZipCodeRegex, address, matches);

SaveCityZipCode(matches['city'], matches['zipCode']);
```

**[⬆ back to top](#table-of-contents)**

### Avoid nesting too deeply and return early

Too many if else statemetns can make your code hard to follow. Explicit is better
than implicit.

**Bad:**

```csharp
function IsShopOpen(day)
{
    if (day) {
        if (string.IsNullOrEmpty(day)) {
            day = strtolower(day);
            if (day == 'friday') {
                return true;
            } elseif (day == 'saturday') {
                return true;
            } elseif (day == 'sunday') {
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    } else {
        return false;
    }
}
```

**Good:**

```csharp
function IsShopOpen(day)
{
    if (empty(day) && ! is_string(day)) {
        return false;
    }

    var openingDays = [
        'friday', 'saturday', 'sunday'
    ];

    return in_array(strtolower(day), openingDays);
}
```

**Bad:**

```csharp
function Fibonacci(n)
{
    if (n < 50) {
        if (n !== 0) {
            if (n !== 1) {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            } else {
                return 1;
            }
        } else {
            return 0;
        }
    } else {
        return 'Not supported';
    }
}
```

**Good:**

```csharp
function Fibonacci(n)
{
    if (n === 0) {
        return 0;
    }

    if (n === 1) {
        return 1;
    }

    if (n > 50) {
        return 'Not supported';
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```

**[⬆ back to top](#table-of-contents)**

### Avoid Mental Mapping

Don’t force the reader of your code to translate what the variable means.
Explicit is better than implicit.

**Bad:**

```csharp
var l = ['Austin', 'New York', 'San Francisco'];

for (var i = 0; i < l.Count(); i++) {
    li = l[i];
    DoStuff();
    DoSomeOtherStuff();

    // ...
    // ...
    // ...
    // Wait, what is `li` for again?
    Dispatch(li);
}
```

**Good:**

```csharp
var locations = ['Austin', 'New York', 'San Francisco'];

foreach (location in locations) {
    DoStuff();
    DoSomeOtherStuff();

    // ...
    // ...
    // ...
    Dispatch(location);
}
```

**[⬆ back to top](#table-of-contents)**

### Don't add unneeded context

If your class/object name tells you something, don't repeat that in your
variable name.

**Bad:**

```csharp
public class Car
{
    public string carMake;
    public string carModel;
    public string carColor;

    //...
}
```

**Good:**

```csharp
public class Car
{
    public string make;
    public string model;
    public string color;

    //...
}
```

**[⬆ back to top](#table-of-contents)**

### Use default arguments instead of short circuiting or conditionals

**Not good:**

This is not good because `breweryName` can be `NULL`.

This opinion is more understandable than the previous version, but it better controls the value of the variable.

```csharp
function CreateMicrobrewery(string name = null)
{
    var breweryName = name ?: "Hipster Brew Co.";
    // ...
}
```

**Good:**

```csharp
function CreateMicrobrewery(string breweryName = "Hipster Brew Co.")
{
    // ...
}
```

**[⬆ back to top](#table-of-contents)**

## **Functions**

## **Objects and Data Structures**

## **Classes**

## **SOLID**

## **Testing**

## **Concurrency**

## **Error Handling**

## **Formatting**

## **Comments**

**[⬆ back to top](#table-of-contents)**

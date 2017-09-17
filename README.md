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
var ymdstr = moment->format('y-m-d');
```

**Good:**

```csharp
var currentDate = moment->format('y-m-d');
```

**[⬆ back to top](#table-of-contents)**

### Use the same vocabulary for the same type of variable

**Bad:**

```csharp
getUserInfo();
getUserData();
getUserRecord();
getUserProfile();
```

**Good:**

```csharp
getUser();
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
$result = $serializer->serialize($data, 448);
```

**Good:**

```csharp
$json = $serializer->serialize($data, JSON_UNESCAPED_SLASHES | JSON_PRETTY_PRINT | JSON_UNESCAPED_UNICODE);
```

### Use searchable names (part 2)

**Bad:**

```csharp
// What the heck is 4 for?
if ($user->access & 4) {
    // ...
}
```

**Good:**

```csharp
class User
{
    const ACCESS_READ = 1;
    const ACCESS_CREATE = 2;
    const ACCESS_UPDATE = 4;
    const ACCESS_DELETE = 8;
}

if ($user->access & User::ACCESS_UPDATE) {
    // do edit ...
}
```

**[⬆ back to top](#table-of-contents)**

### Use explanatory variables

**Bad:**

```csharp
$address = 'One Infinite Loop, Cupertino 95014';
$cityZipCodeRegex = '/^[^,\\]+[,\\\s]+(.+?)\s*(\d{5})?$/';
preg_match($cityZipCodeRegex, $address, $matches);

saveCityZipCode($matches[1], $matches[2]);
```

**Not bad:**

It's better, but we are still heavily dependent on regex.

```csharp
$address = 'One Infinite Loop, Cupertino 95014';
$cityZipCodeRegex = '/^[^,\\]+[,\\\s]+(.+?)\s*(\d{5})?$/';
preg_match($cityZipCodeRegex, $address, $matches);

list(, $city, $zipCode) = $matches;
saveCityZipCode($city, $zipCode);
```

**Good:**

Decrease dependence on regex by naming subpatterns.

```csharp
$address = 'One Infinite Loop, Cupertino 95014';
$cityZipCodeRegex = '/^[^,\\]+[,\\\s]+(?<city>.+?)\s*(?<zipCode>\d{5})?$/';
preg_match($cityZipCodeRegex, $address, $matches);

saveCityZipCode($matches['city'], $matches['zipCode']);
```

**[⬆ back to top](#table-of-contents)**

### Avoid nesting too deeply and return early

Too many if else statemetns can make your code hard to follow. Explicit is better
than implicit.

**Bad:**

```csharp
function isShopOpen($day)
{
    if ($day) {
        if (is_string($day)) {
            $day = strtolower($day);
            if ($day === 'friday') {
                return true;
            } elseif ($day === 'saturday') {
                return true;
            } elseif ($day === 'sunday') {
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
function isShopOpen($day)
{
    if (empty($day) && ! is_string($day)) {
        return false;
    }

    $openingDays = [
        'friday', 'saturday', 'sunday'
    ];

    return in_array(strtolower($day), $openingDays);
}
```

**Bad:**

```csharp
function fibonacci($n)
{
    if ($n < 50) {
        if ($n !== 0) {
            if ($n !== 1) {
                return fibonacci($n - 1) + fibonacci($n - 2);
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
function fibonacci($n)
{
    if ($n === 0) {
        return 0;
    }

    if ($n === 1) {
        return 1;
    }

    if ($n > 50) {
        return 'Not supported';
    }

    return fibonacci($n - 1) + fibonacci($n - 2);
}
```

**[⬆ back to top](#table-of-contents)**

### Avoid Mental Mapping

Don’t force the reader of your code to translate what the variable means.
Explicit is better than implicit.

**Bad:**

```csharp
$l = ['Austin', 'New York', 'San Francisco'];

for ($i = 0; $i < count($l); $i++) {
    $li = $l[$i];
    doStuff();
    doSomeOtherStuff();
    // ...
    // ...
    // ...
    // Wait, what is `$li` for again?
    dispatch($li);
}
```

**Good:**

```csharp
$locations = ['Austin', 'New York', 'San Francisco'];

foreach ($locations as $location) {
    doStuff();
    doSomeOtherStuff();
    // ...
    // ...
    // ...
    dispatch($location);
}
```

**[⬆ back to top](#table-of-contents)**

### Don't add unneeded context

If your class/object name tells you something, don't repeat that in your
variable name.

**Bad:**

```csharp
class Car
{
    public $carMake;
    public $carModel;
    public $carColor;

    //...
}
```

**Good:**

```csharp
class Car
{
    public $make;
    public $model;
    public $color;

    //...
}
```

**[⬆ back to top](#table-of-contents)**

### Use default arguments instead of short circuiting or conditionals

**Not good:**

This is not good because `$breweryName` can be `NULL`.

```csharp
function createMicrobrewery($breweryName = 'Hipster Brew Co.')
{
    // ...
}
```

**Not bad:**

This opinion is more understandable than the previous version, but it better controls the value of the variable.

```csharp
function createMicrobrewery($name = null)
{
    $breweryName = $name ?: 'Hipster Brew Co.';
    // ...
}
```

**Good:**

```csharp
function createMicrobrewery(string $breweryName = 'Hipster Brew Co.')
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

# 适用于 .NET/.NET Core 的代码整洁之道

如果您喜欢 `clean-code-dotnet` 项目，或者它对于您所帮助，请给这个仓库一个小星星 :star: 。这不仅会激励我们的 .NET 社区，也会帮助全世界的 .NET 开发者提升编写优质代码的技能。非常感谢您 :+1:

请查看我的[博客](https://medium.com/@thangchung)，或者在 [Twitter](https://twitter.com/thangchung) 上联系我！

# 目录

- [适用于 .NET/.NET Core 的代码整洁之道](#%e9%80%82%e7%94%a8%e4%ba%8e-netnet-core-%e7%9a%84%e4%bb%a3%e7%a0%81%e6%95%b4%e6%b4%81%e4%b9%8b%e9%81%93)
- [目录](#%e7%9b%ae%e5%bd%95)
- [介绍](#%e4%bb%8b%e7%bb%8d)
- [.NET 中的整洁代码](#net-%e4%b8%ad%e7%9a%84%e6%95%b4%e6%b4%81%e4%bb%a3%e7%a0%81)
  - [命名](#%e5%91%bd%e5%90%8d)
  - [变量](#%e5%8f%98%e9%87%8f)
  - [函数](#%e5%87%bd%e6%95%b0)

# 介绍

![Humorous image of software quality estimation as a count of how many expletives you shout when reading code](http://www.osnews.com/images/comics/wtfm.jpg)

软件工程原则，是来自于 Robert C. Martin 的一本书 [_Clean Code_](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882), 就 .NET/.NET Core 而言，它并不是编码风格指南，而是为了指导开发者能够编写出具有可读性、可重用性和可重构的 .NET/.NET Core 程序。

这里面描述的每一项原则并不是被严格遵守的，并且支持者也相对更少。这些仅仅是指导指南，但这些指南是 _Clean Code_. 作者们多年经验的智慧结晶。

灵感来源于 [clean-code-javascript](https://github.com/ryanmcdermott/clean-code-javascript) 和 [clean-code-php](https://github.com/jupeter/clean-code-php)。

# .NET 中的整洁代码

## 命名

<details>
  <summary><b>避免使用随意的命名</b></summary>

代码中采用优雅而不随意的命名方式会易于被更多的开发者采用，命名名称应反映出它的作用及对应的上下文关系

**Bad:**

```csharp
int d;
```

**Good:**

```csharp
int daySinceModification;
```

**[⬆ Back to top](#目录)**

</details>

<details>
  <summary><b>避免使用误导性名称</b></summary>

给变量定义的名称需要反映出该变量的用途

**Bad:**

```csharp
var dataFromDb = db.GetFromService().ToList();
```

**Good:**

```csharp
var listOfEmployee = _employeeService.GetEmployees().ToList();
```

**[⬆ Back to top](#目录)**

</details>

<details>
  <summary><b>避免使用匈牙利命名法</b></summary>

匈牙利命名法会在已定义的变量加上类型前缀，这是毫无意义的，因为现代化的继承开发环境会自动标识变量类型。

**Bad:**

```csharp
int iCounter;
string strFullName;
DateTime dModifiedDate;
```

**Good:**

```csharp
int counter;
string fullName;
DateTime modifiedDate;
```
匈牙利命名发也不应该用于参数命令。

**Bad:**

```csharp
public bool IsShopOpen(string pDay, int pAmount)
{
    // some logic
}
```

**Good:**

```csharp
public bool IsShopOpen(string day, int amount)
{
    // some logic
}
```

**[⬆ Back to top](#目录)**

</details>


<details>
  <summary><b>使用一致的大写方式</b></summary>

大写式命名可以向你暴露一些变量、功能等信息。这个规则具有主观性，所以你们团队可以选择你们喜欢的方式，但只要保持一致即可。

**Bad:**

```csharp
const int DAYS_IN_WEEK = 7;
const int daysInMonth = 30;

var songs = new List<string> { 'Back In Black', 'Stairway to Heaven', 'Hey Jude' };
var Artists = new List<string> { 'ACDC', 'Led Zeppelin', 'The Beatles' };

bool EraseDatabase() {}
bool Restore_database() {}

class animal {}
class Alpaca {}
```

**Good:**

```csharp
const int DaysInWeek = 7;
const int DaysInMonth = 30;

var songs = new List<string> { 'Back In Black', 'Stairway to Heaven', 'Hey Jude' };
var artists = new List<string> { 'ACDC', 'Led Zeppelin', 'The Beatles' };

bool EraseDatabase() {}
bool RestoreDatabase() {}

class Animal {}
class Alpaca {}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>使用可读的命名方式</b></summary>

当变量和函数的命名不可读时，研究它们的函数是需要花费一些时间的。

**Bad:**

```csharp
public class Employee
{
    public Datetime sWorkDate { get; set; } // what the heck is this
    public Datetime modTime { get; set; } // same here
}
```

**Good:**

```csharp
public class Employee
{
    public Datetime StartWorkingDate { get; set; }
    public Datetime ModificationTime { get; set; }
}
```

**[⬆ Back to top](#目录)**

</details>


<details>
  <summary><b>使用驼峰命名法</b></summary>

针对变量和函数应采用 [驼峰命名法](https://en.wikipedia.org/wiki/Camel_case) 

**Bad:**

```csharp
var employeephone;

public double CalculateSalary(int workingdays, int workinghours)
{
    // some logic
}
```

**Good:**

```csharp
var employeePhone;

public double CalculateSalary(int workingDays, int workingHours)
{
    // some logic
}
```

**[⬆ Back to top](#目录)**

</details>


<details>
  <summary><b>使用概括性命名</b></summary>

那些阅读你代码的人通常也是开发者，合理组织每个页面内容的的命名，让每个人都能轻易理解你想表达式的意思，这样我们就不用花费时间去想每个人解释里面变量、函数的功能。

**Good**

```csharp
public class SingleObject
{
    // create an object of SingleObject
    private static SingleObject _instance = new SingleObject();

    // make the constructor private so that this class cannot be instantiated
    private SingleObject() {}

    // get the only object available
    public static SingleObject GetInstance()
    {
        return _instance;
    }

    public string ShowMessage()
    {
        return "Hello World!";
    }
}

public static void main(String[] args)
{
    // illegal construct
    // var object = new SingleObject();

    // Get the only object available
    var singletonObject = SingleObject.GetInstance();

    // show the message
    singletonObject.ShowMessage();
}
```

**[⬆ Back to top](#目录)**

</details>

## 变量

<details>
  <summary><b>避免嵌套太深，及时返回</b></summary>

过多的 `if else` 段会让代码变得晦涩难懂，**简洁明了优于暗藏玄机**。

**Bad:**

```csharp
public bool IsShopOpen(string day)
{
    if (!string.IsNullOrEmpty(day))
    {
        day = day.ToLower();
        if (day == "friday")
        {
            return true;
        }
        else if (day == "saturday")
        {
            return true;
        }
        else if (day == "sunday")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }

}
```

**Good:**

```csharp
public bool IsShopOpen(string day)
{
    if (string.IsNullOrEmpty(day))
    {
        return false;
    }

    var openingDays = new[] { "friday", "saturday", "sunday" };
    return openingDays.Any(d => d == day.ToLower());
}
```

**Bad:**

```csharp
public long Fibonacci(int n)
{
    if (n < 50)
    {
        if (n != 0)
        {
            if (n != 1)
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 0;
        }
    }
    else
    {
        throw new System.Exception("Not supported");
    }
}
```

**Good:**

```csharp
public long Fibonacci(int n)
{
    if (n == 0)
    {
        return 0;
    }

    if (n == 1)
    {
        return 1;
    }

    if (n > 50)
    {
        throw new System.Exception("Not supported");
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>避免主管映射</b></summary>

不要迫使编译器强行翻译你的代码含义 **显式优于隐式**.

**Bad:**

```csharp
var l = new[] { "Austin", "New York", "San Francisco" };

for (var i = 0; i < l.Count(); i++)
{
    var li = l[i];
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
var locations = new[] { "Austin", "New York", "San Francisco" };

foreach (var location in locations)
{
    DoStuff();
    DoSomeOtherStuff();

    // ...
    // ...
    // ...
    Dispatch(location);
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>避免使用魔法字符串</b></summary>

魔法字符串是指直接在应用程序代码中指定的字符串值，这些字符串对会应用程序的行为有所影响。通常，此类字符串最终会在系统中重复使用，并且由于它们无法使用重构工具自动更新，因此当对某些字符串进行更改时，它们将成为常见的 Bug 来源，而不是其他字符串。

**Bad**

```csharp
if (userRole == "Admin")
{
    // logic in here
}
```

**Good**

```csharp
const string ADMIN_ROLE = "Admin"
if (userRole == ADMIN_ROLE)
{
    // logic in here
}
```

使用这种方式的话，我们只需要改变关键的地方，其它地方也就会跟着改变。

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>不要引入不必要的上下文</b></summary>

如果你的类/对象名称已经告诉了你一些信息，不要在其内部定义重复定义该变量名称。

**Bad:**

```csharp
public class Car
{
    public string CarMake { get; set; }
    public string CarModel { get; set; }
    public string CarColor { get; set; }

    //...
}
```

**Good:**

```csharp
public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }

    //...
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>使用有意义和可读的变量名称</b></summary>

**Bad:**

```csharp
var ymdstr = DateTime.UtcNow.ToString("MMMM dd, yyyy");
```

**Good:**

```csharp
var currentDate = DateTime.UtcNow.ToString("MMMM dd, yyyy");
```

**[⬆ Back to top](#目录)**

</details>

<details>
  <summary><b>对相同类型的变量使用相同的名称</b></summary>

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

**[⬆ Back to top](#目录)**

</details>


<details>
  <summary><b>使用可搜索的名称（第 1 部分）</b></summary>

我们阅读的代码比我们的写的代码要多。我们写的代码应该具有可读性和可搜索性，这个很重要。使用不合适的命令方式会影响我们对程序的理解，这会伤害到阅读者，让你的命名可搜索。

**Bad:**

```csharp
// What the heck is data for?
var data = new { Name = "John", Age = 42 };

var stream1 = new MemoryStream();
var ser1 = new DataContractJsonSerializer(typeof(object));
ser1.WriteObject(stream1, data);

stream1.Position = 0;
var sr1 = new StreamReader(stream1);
Console.Write("JSON form of Data object: ");
Console.WriteLine(sr1.ReadToEnd());
```

**Good:**

```csharp
var person = new Person
{
    Name = "John",
    Age = 42
};

var stream2 = new MemoryStream();
var ser2 = new DataContractJsonSerializer(typeof(Person));
ser2.WriteObject(stream2, data);

stream2.Position = 0;
var sr2 = new StreamReader(stream2);
Console.Write("JSON form of Data object: ");
Console.WriteLine(sr2.ReadToEnd());
```

**[⬆ Back to top](#目录)**

</details>


<details>
  <summary><b>使用可搜索的名称（第 2 部分）</b></summary>

**Bad:**

```csharp
var data = new { Name = "John", Age = 42, PersonAccess = 4};

// What the heck is 4 for?
if (data.PersonAccess == 4)
{
    // do edit ...
}
```

**Good:**

```csharp
public enum PersonAccess : int
{
    ACCESS_READ = 1,
    ACCESS_CREATE = 2,
    ACCESS_UPDATE = 4,
    ACCESS_DELETE = 8
}

var person = new Person
{
    Name = "John",
    Age = 42,
    PersonAccess= PersonAccess.ACCESS_CREATE
};

if (person.PersonAccess == PersonAccess.ACCESS_UPDATE)
{
    // do edit ...
}
```

**[⬆ Back to top](#目录)**

</details>


<details>
  <summary><b>使用解释型变量</b></summary>

**Bad:**

```csharp
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeRegex = @"/^[^,\]+[,\\s]+(.+?)\s*(\d{5})?$/";
var matches = Regex.Matches(Address, cityZipCodeRegex);
if (matches[0].Success == true && matches[1].Success == true)
{
    SaveCityZipCode(matches[0].Value, matches[1].Value);
}
```

**Good:**

Decrease dependence on regex by naming subpatterns.

```csharp
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeWithGroupRegex = @"/^[^,\]+[,\\s]+(?<city>.+?)\s*(?<zipCode>\d{5})?$/";
var matchesWithGroup = Regex.Match(Address, cityZipCodeWithGroupRegex);
var cityGroup = matchesWithGroup.Groups["city"];
var zipCodeGroup = matchesWithGroup.Groups["zipCode"];
if(cityGroup.Success == true && zipCodeGroup.Success == true)
{
    SaveCityZipCode(cityGroup.Value, zipCodeGroup.Value);
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>使用默认参数而不是条件判断</b></summary>

**Not good:**

这样并不好，因为 `breweryName` 可能为 `NULL`。

这种方式在之前的版本更容易理解，它能很好地控制变量的值。

```csharp
public void CreateMicrobrewery(string name = null)
{
    var breweryName = !string.IsNullOrEmpty(name) ? name : "Hipster Brew Co.";
    // ...
}
```

**Good:**

```csharp
public void CreateMicrobrewery(string breweryName = "Hipster Brew Co.")
{
    // ...
}
```

**[⬆ back to top](#目录)**

</details>

## 函数


<details>
  <summary><b>避免副作用</b></summary>

如果函数除了获取一个值并且返回另一个值之外执行了一些操作，则会产生副作用。副作用可能是文件写入，修改一些全局变量，或者意外地向外部暴露了数据。

在某些情况下，你的程序确实需要一些副作用，像上述示例一样，你可能需要文件写入，当集中执行这些操作时，并没有多个函数或类来支持写入特定文件，这时可以通过一个服务来执行这个副作用，这是唯一的一种方法。

关键点是要避免一些常见的陷阱。比如没有任何结构关联的对象间的状态共享。使用任何可写入的可变数据类型，以及不确定的副作用发生的位置。如果你能意识到这一点的话，会比周围其他程序员更高兴一些。

**Bad:**

```csharp
// Global variable referenced by following function.
// If we had another function that used this name, now it'd be an array and it could break it.
var name = 'Ryan McDermott';

public string SplitIntoFirstAndLastName()
{
   return name.Split(" ");
}

SplitIntoFirstAndLastName();

Console.PrintLine(name); // ['Ryan', 'McDermott'];
```

**Good:**

```csharp
public string SplitIntoFirstAndLastName(string name)
{
    return name.Split(" ");
}

var name = 'Ryan McDermott';
var newName = SplitIntoFirstAndLastName(name);

Console.PrintLine(name); // 'Ryan McDermott';
Console.PrintLine(newName); // ['Ryan', 'McDermott'];
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>避免非条件</b></summary>

**Bad:**

```csharp
public bool IsDOMNodeNotPresent(string node)
{
    // ...
}

if (!IsDOMNodeNotPresent(node))
{
    // ...
}
```

**Good:**

```csharp
public bool IsDOMNodePresent(string node)
{
    // ...
}

if (IsDOMNodePresent(node))
{
    // ...
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>避免多条件</b></summary>

This seems like an impossible task. Upon first hearing this, most people say, "how am I supposed to do anything without an `if` statement?" The answer is that you can use polymorphism to achieve the same task in many cases. The second question is usually, "well that's great but why would I want to do that?" The answer is a previous clean code concept we learned: a function should only do
one thing. When you have classes and functions that have `if` statements, you are telling your user that your function does more than one thing. Remember, just do one thing.

这似乎是一个不现实的要求，第一次听到这个，大多数人说，“如果没有 `if` 语句 我怎么能实现一些功能呢？” 第二个问题通常是，"那很好，但我为什么要这么做呢？" 答案是我们之前学到的整洁代码概念：函数应该只做有一件事，当你的类和函数具有 "if" 语句时，您会告诉用户您的函数执行多个事情。记住，只做一件事。

**Bad:**

```csharp
class Airplane
{
    // ...

    public double GetCruisingAltitude()
    {
        switch (_type)
        {
            case '777':
                return GetMaxAltitude() - GetPassengerCount();
            case 'Air Force One':
                return GetMaxAltitude();
            case 'Cessna':
                return GetMaxAltitude() - GetFuelExpenditure();
        }
    }
}
```

**Good:**

```csharp
interface IAirplane
{
    // ...

    double GetCruisingAltitude();
}

class Boeing777 : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetPassengerCount();
    }
}

class AirForceOne : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude();
    }
}

class Cessna : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetFuelExpenditure();
    }
}
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>避免类型检查（第 1 部分）</b></summary>

**Bad:**

```csharp
public Path TravelToTexas(object vehicle)
{
    if (vehicle.GetType() == typeof(Bicycle))
    {
        (vehicle as Bicycle).PeddleTo(new Location("texas"));
    }
    else if (vehicle.GetType() == typeof(Car))
    {
        (vehicle as Car).DriveTo(new Location("texas"));
    }
}
```

**Good:**

```csharp
public Path TravelToTexas(Traveler vehicle)
{
    vehicle.TravelTo(new Location("texas"));
}
```

or

```csharp
// pattern matching
public Path TravelToTexas(object vehicle)
{
    if (vehicle is Bicycle bicycle)
    {
        bicycle.PeddleTo(new Location("texas"));
    }
    else if (vehicle is Car car)
    {
        car.DriveTo(new Location("texas"));
    }
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>避免类型检测（第 2 部分）</b></summary>

**Bad:**

```csharp
public int Combine(dynamic val1, dynamic val2)
{
    int value;
    if (!int.TryParse(val1, out value) || !int.TryParse(val2, out value))
    {
        throw new Exception('Must be of type Number');
    }

    return val1 + val2;
}
```

**Good:**

```csharp
public int Combine(int val1, int val2)
{
    return val1 + val2;
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>避免在方法参数中设置标志</b></summary>

标志指示着这个方法有更多的职责。最好的办法是单一职责原则，如果布尔参数会往函数中会添加多个职责，那么就将这个函数拆分为两个。

**Bad:**

```csharp
public void CreateFile(string name, bool temp = false)
{
    if (temp)
    {
        Touch("./temp/" + name);
    }
    else
    {
        Touch(name);
    }
}
```

**Good:**

```csharp
public void CreateFile(string name)
{
    Touch(name);
}

public void CreateTempFile(string name)
{
    Touch("./temp/"  + name);
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>不要编写全局函数</b></summary>

> 还没完

在很多语言中，污染全局是一种差的实践方式，因为你可能会与其它库发送冲突，并且你的 API 用户在生产环境下获取一个异常将毫不明智。让我们一起思考一个示例：如果想要配置数组该如何处理。你可以编写一个像 `Config()` 的全局函数，但它可能会与另一个尝试执行相同操作的库发生冲突。

**Bad:**

```csharp
public string[] Config()
{
    return  [
        "foo" => "bar",
    ]
}
```

**Good:**

```csharp
class Configuration
{
    private string[] _configuration = [];

    public Configuration(string[] configuration)
    {
        _configuration = configuration;
    }

    public string[] Get(string key)
    {
        return (_configuration[key]!= null) ? _configuration[key] : null;
    }
}
```

加载配置并创建配置实例 `Configuration`

```csharp
var configuration = new Configuration(new string[] {
    "foo" => "bar",
});
```

你现在在应用程序中必须使用 `Configuration` 的实例

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>不要使用单例模式</b></summary>

单例模式是一种 [反模式](https://en.wikipedia.org/wiki/Singleton_pattern). 根据 from Brian Button 的描述:

1. 它们通常作为一个 **全局实例** 存在，为什么这样不好？因为你在你的程序代码中 **隐藏依赖项**，而不是通过接口来暴露它们，为了避免对象传递而将其设置为全局的方式是一种 [code smell](https://en.wikipedia.org/wiki/Code_smell)。
3. 它们违反了[单一职责原则](#single-responsibility-principle-srp)：**它们控制了自己的对象创建和生命周期**
4. 它们本质上会导致代码紧密地 [耦合](https://en.wikipedia.org/wiki/Coupling_%28computer_programming%29)，这使得在许多情况下，在测试环境下模拟它们异常困难。
5. 它们在应用程序的生存期内会携带状态。另一点需要测试，因为[你最终可能会得到一种情况，即测试需要排序]，这违背了单元测试的原则。为什么？因为每个单元测试相互独立。

这儿也有一些 [Misko Hevery](http://misko.hevery.com/about/)  关于 [root of problem](http://misko.hevery.com/2008/08/25/root-cause-of-singletons/) 很不错的想法。

**Bad:**

```csharp
class DBConnection
{
    private static DBConnection _instance;

    private DBConnection()
    {
        // ...
    }

    public static GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DBConnection();
        }

        return _instance;
    }

    // ...
}

var singleton = DBConnection.GetInstance();
```

**Good:**

```csharp
class DBConnection
{
    public DBConnection(IOptions<DbConnectionOption> options)
    {
        // ...
    }

    // ...
}
```

创建一个 `DBConnection` 实例，并通过 [Option pattern](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-2.1) 来进行配置

```csharp
var options = <resolve from IOC>;
var connection = new DBConnection(options);
```

现在，你在你的应用程序中必须使用 `DBConnection` 的类型实例

**[⬆ back to top](#目录)**

</details>




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
  - [对象和数据结构](#%e5%af%b9%e8%b1%a1%e5%92%8c%e6%95%b0%e6%8d%ae%e7%bb%93%e6%9e%84)
  - [类](#%e7%b1%bb)
  - [SOLID](#solid)
  - [测试](#%e6%b5%8b%e8%af%95)
  - [并发](#%e5%b9%b6%e5%8f%91)
  - [异常处理](#%e5%bc%82%e5%b8%b8%e5%a4%84%e7%90%86)
  - [格式化](#%e6%a0%bc%e5%bc%8f%e5%8c%96)
  - [注释](#%e6%b3%a8%e9%87%8a)
- [其它关于代码整洁之道的资源](#%e5%85%b6%e5%ae%83%e5%85%b3%e4%ba%8e%e4%bb%a3%e7%a0%81%e6%95%b4%e6%b4%81%e4%b9%8b%e9%81%93%e7%9a%84%e8%b5%84%e6%ba%90)
  - [其它代码整洁之道列表](#%e5%85%b6%e5%ae%83%e4%bb%a3%e7%a0%81%e6%95%b4%e6%b4%81%e4%b9%8b%e9%81%93%e5%88%97%e8%a1%a8)
  - [工具](#%e5%b7%a5%e5%85%b7)
  - [表格](#%e8%a1%a8%e6%a0%bc)
- [贡献者](#%e8%b4%a1%e7%8c%ae%e8%80%85)
- [支持者](#%e6%94%af%e6%8c%81%e8%80%85)
- [赞助商](#%e8%b5%9e%e5%8a%a9%e5%95%86)
- [许可证](#%e8%ae%b8%e5%8f%af%e8%af%81)

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
  <summary><b>避免主观映射</b></summary>

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

这似乎是一个不现实的要求，第一次听到这个的时候，大多数人说，“如果没有 `if` 语句 我怎么能实现一些功能呢？” 第二个问题通常是，"那很好，但我为什么要这么做呢？" 答案是我们之前学到的整洁代码概念：函数应该只做有一件事，当你的类和函数具有 "if" 语句时，您会告诉用户您的函数执行多个事情。记住，只做一件事。

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
  <summary><b>避免类型检查（第 2 部分）</b></summary>

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
2. 它们违反了[单一职责原则](#single-responsibility-principle-srp)：**它们控制了自己的对象创建和生命周期**
3. 它们本质上会导致代码紧密地 [耦合](https://en.wikipedia.org/wiki/Coupling_%28computer_programming%29)，这使得在许多情况下，在测试环境下模拟它们异常困难。
4. 它们在应用程序的生存期内会携带状态。另一点需要测试，因为[你最终可能会得到一种情况，即测试需要排序]，这违背了单元测试的原则。为什么？因为每个单元测试相互独立。

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


<details>
  <summary><b>函数参数（2个或者更少最佳）</b></summary>

限制函数参数的数量非常重要，因为它使测试函数变得更加容易。拥有三个以上会导致组合爆炸，您必须使用每个单独的参数测试大量不同用例。

无参是理想的情况。一个或两个参数是可以的，三个应该避免，超过的话应该合并。通常，如果您有两个以上参数，则函数尝试执行的操作太多。大多数时候，一个更高级别的对象将足以作为一个参数。

**Bad:**

```csharp
public void CreateMenu(string title, string body, string buttonText, bool cancellable)
{
    // ...
}
```

**Good:**

```csharp
public class MenuConfig
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string ButtonText { get; set; }
    public bool Cancellable { get; set; }
}

var config = new MenuConfig
{
    Title = "Foo",
    Body = "Bar",
    ButtonText = "Baz",
    Cancellable = true
};

public void CreateMenu(MenuConfig config)
{
    // ...
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>一个函数只应该做一件事情</b></summary>

在软件开发过程中，这是一个很重要的原则。当函数要做的事情超过一件的时候就很难组合到一起进行测试，这是因为，当你可以将一个函数隔离为一个操作时，可以轻松的进行重构，并且能够过得更多清晰明确的信息。如果你在这份指南中只学会到了这一点，那么你将比其他开发者更领先一些。

**Bad:**

```csharp
public void SendEmailToListOfClients(string[] clients)
{
    foreach (var client in clients)
    {
        var clientRecord = db.Find(client);
        if (clientRecord.IsActive())
        {
            Email(client);
        }
    }
}
```

**Good:**

```csharp
public void SendEmailToListOfClients(string[] clients)
{
    var activeClients = GetActiveClients(clients);
    // Do some logic
}

public List<Client> GetActiveClients(string[] clients)
{
    return db.Find(clients).Where(s => s.Status == "Active");
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>函数命名要见名知义</b></summary>

**Bad:**

```csharp
public class Email
{
    //...

    public void Handle()
    {
        SendMail(this._to, this._subject, this._body);
    }
}

var message = new Email(...);
// What is this? A handle for the message? Are we writing to a file now?
message.Handle();
```

**Good:**

```csharp
public class Email
{
    //...

    public void Send()
    {
        SendMail(this._to, this._subject, this._body);
    }
}

var message = new Email(...);
// Clear and obvious
message.Send();
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>函数应该只包含一层抽象</b></summary>

> 还没完

通常情况下，当你的函数中包含超过一层的抽象表明这个函数做的事情太多了，拆分为多个函数可以提高重用性和更易于测试。

**Bad:**

```csharp
public string ParseBetterJSAlternative(string code)
{
    var regexes = [
        // ...
    ];

    var statements = explode(" ", code);
    var tokens = new string[] {};
    foreach (var regex in regexes)
    {
        foreach (var statement in statements)
        {
            // ...
        }
    }

    var ast = new string[] {};
    foreach (var token in tokens)
    {
        // lex...
    }

    foreach (var node in ast)
    {
        // parse...
    }
}
```

**Bad too:**

我们已经执行了一些操作，但是 `ParseBetterJSAlternative()` 函数依旧很复杂，且不易于测试。

```csharp
public string Tokenize(string code)
{
    var regexes = new string[]
    {
        // ...
    };

    var statements = explode(" ", code);
    var tokens = new string[] {};
    foreach (var regex in regexes)
    {
        foreach (var statement in statements)
        {
            tokens[] = /* ... */;
        }
    }

    return tokens;
}

public string Lexer(string[] tokens)
{
    var ast = new string[] {};
    foreach (var token in tokens)
    {
        ast[] = /* ... */;
    }

    return ast;
}

public string ParseBetterJSAlternative(string code)
{
    var tokens = Tokenize(code);
    var ast = Lexer(tokens);
    foreach (var node in ast)
    {
        // parse...
    }
}
```

**Good:**

最好的解决方案是分解 `ParseBetterJSAlternative()` 函数内部的所有依赖性。

```csharp
class Tokenizer
{
    public string Tokenize(string code)
    {
        var regexes = new string[] {
            // ...
        };

        var statements = explode(" ", code);
        var tokens = new string[] {};
        foreach (var regex in regexes)
        {
            foreach (var statement in statements)
            {
                tokens[] = /* ... */;
            }
        }

        return tokens;
    }
}

class Lexer
{
    public string Lexify(string[] tokens)
    {
        var ast = new[] {};
        foreach (var token in tokens)
        {
            ast[] = /* ... */;
        }

        return ast;
    }
}

class BetterJSAlternative
{
    private string _tokenizer;
    private string _lexer;

    public BetterJSAlternative(Tokenizer tokenizer, Lexer lexer)
    {
        _tokenizer = tokenizer;
        _lexer = lexer;
    }

    public string Parse(string code)
    {
        var tokens = _tokenizer.Tokenize(code);
        var ast = _lexer.Lexify(tokens);
        foreach (var node in ast)
        {
            // parse...
        }
    }
}
```

**[⬆ back to top](#目录)**

</details>



<details>
  <summary><b>函数调用方和被调用方应该位置相近</b></summary>

如果一个函数调用了其它函数，请保持这些函数顺序位于同一个源代码文件中。理想情况下，让被调用者位于调用者上方。我们倾向于像读报纸一样从上到下来阅读代码。因此，请以这种阅读方式来布局代码。

**Bad:**

```csharp
class PerformanceReview
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee)
    {
        _employee = employee;
    }

    private IEnumerable<PeersData> LookupPeers()
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData LookupManager()
    {
        return db.lookup(_employee, 'manager');
    }

    private IEnumerable<PeerReviews> GetPeerReviews()
    {
        var peers = LookupPeers();
        // ...
    }

    public PerfReviewData PerfReview()
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    public ManagerData GetManagerReview()
    {
        var manager = LookupManager();
    }

    public EmployeeData GetSelfReview()
    {
        // ...
    }
}

var  review = new PerformanceReview(employee);
review.PerfReview();
```

**Good:**

```csharp
class PerformanceReview
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee)
    {
        _employee = employee;
    }

    public PerfReviewData PerfReview()
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    private IEnumerable<PeerReviews> GetPeerReviews()
    {
        var peers = LookupPeers();
        // ...
    }

    private IEnumerable<PeersData> LookupPeers()
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData GetManagerReview()
    {
        var manager = LookupManager();
        return manager;
    }

    private ManagerData LookupManager()
    {
        return db.lookup(_employee, 'manager');
    }

    private EmployeeData GetSelfReview()
    {
        // ...
    }
}

var review = new PerformanceReview(employee);
review.PerfReview();
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>封装条件</b></summary>

**Bad:**

```csharp
if (article.state == "published")
{
    // ...
}
```

**Good:**

```csharp
if (article.IsPublished())
{
    // ...
}
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>移除废弃代码</b></summary>

废弃代码和重复代码一样糟糕，毫无疑问不应该让其存在于你的代码库中。如果它不会被调用，那就删除它！如果你仍然需要它的话，它可以安全的存在于你的版本控制中。

**Bad:**

```csharp
public void OldRequestModule(string url)
{
    // ...
}

public void NewRequestModule(string url)
{
    // ...
}

var request = NewRequestModule(requestUrl);
InventoryTracker("apples", request, "www.inventory-awesome.io");
```

**Good:**

```csharp
public void RequestModule(string url)
{
    // ...
}

var request = RequestModule(requestUrl);
InventoryTracker("apples", request, "www.inventory-awesome.io");
```

**[⬆ back to top](#目录)**

</details>

## 对象和数据结构


<details>
  <summary><b>使用 getters 和 setters</b></summary>

在 C# / VB.NET 中，你可以为方法添加 `public`, `protected` 和 `private` 关键字。通过使用这些关键字，你可以控制对象的一些成员的访问权限。

- 当你尝试通过一个对象属性来进行更多的操作，你不得不在你的代码中查找和修改它们的访问权限。
- 通过使用 `set` 关键字可以让属性验证变得更简单。
- 封装内部的展现形式。
- 当进行 getting 和 setting 操作时可以更容易的添加日志和异常处理。
- 基础基类后，你可以重写默认方法。
- 如果是从服务器获取一个对象，你可以使用懒加载来处理对象的属性。

此外，在面向对象设计原则中，这也是开闭原则的一部分。

**Bad:**

```csharp
class BankAccount
{
    public double Balance = 1000;
}

var bankAccount = new BankAccount();

// Fake buy shoes...
bankAccount.Balance -= 100;
```

**Good:**

```csharp
class BankAccount
{
    private double _balance = 0.0D;

    pubic double Balance {
        get {
            return _balance;
        }
    }

    public BankAccount(balance = 1000)
    {
       _balance = balance;
    }

    public void WithdrawBalance(int amount)
    {
        if (amount > _balance)
        {
            throw new Exception('Amount greater than available balance.');
        }

        _balance -= amount;
    }

    public void DepositBalance(int amount)
    {
        _balance += amount;
    }
}

var bankAccount = new BankAccount();

// Buy shoes...
bankAccount.WithdrawBalance(price);

// Get balance
balance = bankAccount.Balance;
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>让对象具有私有/受保护的成员</b></summary>

**Bad:**

```csharp
class Employee
{
    public string Name { get; set; }

    public Employee(name)
    {
        Name = name;
    }
}

var employee = new Employee('John Doe');
Console.WriteLine(employee.Name) // Employee name: John Doe
```

**Good:**

```csharp
class Employee
{
    public string Name { get; }

    public Employee(string name)
    {
        Name = name;
    }
}

var employee = new Employee('John Doe');
Console.WriteLine(employee.GetName());// Employee name: John Doe
```

**[⬆ back to top](#目录)**

</details>


## 类

<details>
  <summary><b>使用链式方法</b></summary>

在一些类库中，这种模式是很有用且很常见的操作。它可以让你的代码以一种表达式的方式来呈现，更加简洁。因此，使用链式方法可以让你的代码看上去更加简洁。

**Good:**

```csharp
public static class ListExtensions
{
    public static List<T> FluentAdd<T>(this List<T> list, T item)
    {
        list.Add(item);
        return list;
    }

    public static List<T> FluentClear<T>(this List<T> list)
    {
        list.Clear();
        return list;
    }

    public static List<T> FluentForEach<T>(this List<T> list, Action<T> action)
    {
        list.ForEach(action);
        return list;
    }

    public static List<T> FluentInsert<T>(this List<T> list, int index, T item)
    {
        list.Insert(index, item);
        return list;
    }

    public static List<T> FluentRemoveAt<T>(this List<T> list, int index)
    {
        list.RemoveAt(index);
        return list;
    }

    public static List<T> FluentReverse<T>(this List<T> list)
    {
        list.Reverse();
        return list;
    }
}

internal static void ListFluentExtensions()
{
    var list = new List<int>() { 1, 2, 3, 4, 5 }
        .FluentAdd(1)
        .FluentInsert(0, 0)
        .FluentRemoveAt(1)
        .FluentReverse()
        .FluentForEach(value => value.WriteLine())
        .FluentClear();
}
```

**[⬆ back to top](#table-of-contents)**

</details>

<details>
  <summary><b>组合优于继承</b></summary>

正如由 Gang of Four 编写的著作 [_Design Patterns_](https://en.wikipedia.org/wiki/Design_Patterns) 里面所述。如果可以选择的话，你应该倾向于使用组合而不是继承。这里面有很多不错的原因来论述使用继承和组合。

关于这一论点的主要观点是如果你本能地尝试使用继承，那么考虑一下组合是否能更好的解决你的问题，在某些情况下，它确实可以。

你可能接着会疑惑，"我应该什么时候使用继承？" 这取决你你怎么解决问题，这里有一个不错的列表来指导你在什么情况下使用继承更有意义，而不是组合。

1. 你的继承是为了表达一种 "是 A" 的关系而不是 "有 A" 的关系 (人类->动物 vs. 用户->用户详情).
2. 你可以从基类重用代码 (人类像所有动物一样可以移动)。
3. 您希望通过更改基类对派生类进行全局更改 (改变所有动物移动时的热量消耗。)

**Bad:**

```csharp
class Employee
{
    private string Name { get; set; }
    private string Email { get; set; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    // ...
}

// Bad because Employees "have" tax data.
// EmployeeTaxData is not a type of Employee

class EmployeeTaxData : Employee
{
    private string Name { get; }
    private string Email { get; }

    public EmployeeTaxData(string name, string email, string ssn, string salary)
    {
         // ...
    }

    // ...
}
```

**Good:**

```csharp
class EmployeeTaxData
{
    public string Ssn { get; }
    public string Salary { get; }

    public EmployeeTaxData(string ssn, string salary)
    {
        Ssn = ssn;
        Salary = salary;
    }

    // ...
}

class Employee
{
    public string Name { get; }
    public string Email { get; }
    public EmployeeTaxData TaxData { get; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void SetTax(string ssn, double salary)
    {
        TaxData = new EmployeeTaxData(ssn, salary);
    }

    // ...
}
```

**[⬆ back to top](#目录)**

</details>

## SOLID


<details>
  <summary><b>什么是 SOLID?</b></summary>

**SOLID** 是 Michael Feathers 为  Robert Martin 命名的前五个原则引入的首字母简称。它指导者面向对象编程和设计的五个基本原则。

- [S: 单一职责原则 (SRP)](#single-responsibility-principle-srp)
- [O: 开/闭原则 (OCP)](#openclosed-principle-ocp)
- [L: 里氏替换原则 (LSP)](#liskov-substitution-principle-lsp)
- [I: 接口隔离原则 (ISP)](#interface-segregation-principle-isp)
- [D: 依赖倒置原则 (DIP)](#dependency-inversion-principle-dip)

</details>


<details>
  <summary><b>单一职责原则 (SRP)</b></summary>

如代码整洁之道中所述的那样，"类更改的原因永远不应该超过一个"。一个功能繁多的类似乎很有诱惑力，像你登机时只能携带一个手提箱，但问题在于你的类不会具有凝聚力，它会被赋予许多可以改变的理由。尽量减少更改类所需要的时间很重要。

这很重要，因为如果一个类中包含太多功能，并且更改了部分，这会导致很难理解这些更改会怎样影响到代码库中其它的依赖项。

**Bad:**

```csharp
class UserSettings
{
    private User User;

    public UserSettings(User user)
    {
        User = user;
    }

    public void ChangeSettings(Settings settings)
    {
        if (verifyCredentials())
        {
            // ...
        }
    }

    private bool VerifyCredentials()
    {
        // ...
    }
}
```

**Good:**

```csharp
class UserAuth
{
    private User User;

    public UserAuth(User user)
    {
        User = user;
    }

    public bool VerifyCredentials()
    {
        // ...
    }
}

class UserSettings
{
    private User User;
    private UserAuth Auth;

    public UserSettings(User user)
    {
        User = user;
        Auth = new UserAuth(user);
    }

    public void ChangeSettings(Settings settings)
    {
        if (Auth.VerifyCredentials())
        {
            // ...
        }
    }
}
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>开/闭原则 (OCP)</b></summary>

正如 Bertrand Meyer 所述的那样，"软件实体 (类，模块，函数等) 应该对扩展开放，对修改关闭。" 这想表达什么呢？这个原则最基本的要求是你应该允许用户在不更改现有代码的前提下可以添加新功能。

**Bad:**

```csharp
abstract class AdapterBase
{
    protected string Name;

    public string GetName()
    {
        return Name;
    }
}

class AjaxAdapter : AdapterBase
{
    public AjaxAdapter()
    {
        Name = "ajaxAdapter";
    }
}

class NodeAdapter : AdapterBase
{
    public NodeAdapter()
    {
        Name = "nodeAdapter";
    }
}

class HttpRequester : AdapterBase
{
    private readonly AdapterBase Adapter;

    public HttpRequester(AdapterBase adapter)
    {
        Adapter = adapter;
    }

    public bool Fetch(string url)
    {
        var adapterName = Adapter.GetName();

        if (adapterName == "ajaxAdapter")
        {
            return MakeAjaxCall(url);
        }
        else if (adapterName == "httpNodeAdapter")
        {
            return MakeHttpCall(url);
        }
    }

    private bool MakeAjaxCall(string url)
    {
        // request and return promise
    }

    private bool MakeHttpCall(string url)
    {
        // request and return promise
    }
}
```

**Good:**

```csharp
interface IAdapter
{
    bool Request(string url);
}

class AjaxAdapter : IAdapter
{
    public bool Request(string url)
    {
        // request and return promise
    }
}

class NodeAdapter : IAdapter
{
    public bool Request(string url)
    {
        // request and return promise
    }
}

class HttpRequester
{
    private readonly IAdapter Adapter;

    public HttpRequester(IAdapter adapter)
    {
        Adapter = adapter;
    }

    public bool Fetch(string url)
    {
        return Adapter.Request(url);
    }
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>里氏替换原则 (LSP)</b></summary>

对于一个很简单的概念来说，这是很抽象的。它的准确表述是 "如果 S 是 T 的子类，那么类型 T 的对象可以转化为类型 S 的对象，即在无需修改程序（正确性，任务执行等）的情况下 在类型为 S 的对象可以替换类型为 T 的对象。" 这是一个相对可怕的定义。

对这一原则最好的解释是如果你有一个父类和一个子类，那么基类和子类可以相互使用，而不会得到错误答案，这可能仍然令人困惑。在数学上，正方形是一个矩形，但是使用 "is-a" 关系通过继承对它建模，你很快就会陷入麻烦。

**Bad:**

```csharp
class Rectangle
{
    protected double Width = 0;
    protected double Height = 0;

    public Drawable Render(double area)
    {
        // ...
    }

    public void SetWidth(double width)
    {
        Width = width;
    }

    public void SetHeight(double height)
    {
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }
}

class Square : Rectangle
{
    public double SetWidth(double width)
    {
        Width = Height = width;
    }

    public double SetHeight(double height)
    {
        Width = Height = height;
    }
}

Drawable RenderLargeRectangles(Rectangle rectangles)
{
    foreach (rectangle in rectangles)
    {
        rectangle.SetWidth(4);
        rectangle.SetHeight(5);
        var area = rectangle.GetArea(); // BAD: Will return 25 for Square. Should be 20.
        rectangle.Render(area);
    }
}

var rectangles = new[] { new Rectangle(), new Rectangle(), new Square() };
RenderLargeRectangles(rectangles);
```

**Good:**

```csharp
abstract class ShapeBase
{
    protected double Width = 0;
    protected double Height = 0;

    abstract public double GetArea();

    public Drawable Render(double area)
    {
        // ...
    }
}

class Rectangle : ShapeBase
{
    public void SetWidth(double width)
    {
        Width = width;
    }

    public void SetHeight(double height)
    {
        Height = height;
    }

    public double GetArea()
    {
        return Width * Height;
    }
}

class Square : ShapeBase
{
    private double Length = 0;

    public double SetLength(double length)
    {
        Length = length;
    }

    public double GetArea()
    {
        return Math.Pow(Length, 2);
    }
}

Drawable RenderLargeRectangles(Rectangle rectangles)
{
    foreach (rectangle in rectangles)
    {
        if (rectangle is Square)
        {
            rectangle.SetLength(5);
        }
        else if (rectangle is Rectangle)
        {
            rectangle.SetWidth(4);
            rectangle.SetHeight(5);
        }

        var area = rectangle.GetArea();
        rectangle.Render(area);
    }
}

var shapes = new[] { new Rectangle(), new Rectangle(), new Square() };
RenderLargeRectangles(shapes);
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>接口隔离原则 (ISP)</b></summary>

ISP 指出 "不应该强迫客户端依赖于它不使用的接口。"

一个很好的例子可以很好地证明这一点。比如需要大量的设置对象，不需要客户端创建很多的设置项是正确的，因为大多数情况下，它们并不需要所有的设置项，使它们作为可选项有助于防止出现 "胖接口"。

**Bad:**

```csharp
public interface IEmployee
{
    void Work();
    void Eat();
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }

    public void Eat()
    {
        // ...... eating in lunch break
    }
}

public class Robot : IEmployee
{
    public void Work()
    {
        //.... working much more
    }

    public void Eat()
    {
        //.... robot can't eat, but it must implement this method
    }
}
```

**Good:**

Not every worker is an employee, but every employee is an worker.

```csharp
public interface IWorkable
{
    void Work();
}

public interface IFeedable
{
    void Eat();
}

public interface IEmployee : IFeedable, IWorkable
{
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }

    public void Eat()
    {
        //.... eating in lunch break
    }
}

// robot can only work
public class Robot : IWorkable
{
    public void Work()
    {
        // ....working
    }
}
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>依赖倒置原则 (DIP)</b></summary>

这一原则指出两个基本点：

1. 高级别模块不应该依赖于低级别模块，它们都应该依赖于抽象层。
2. 抽象不应该依赖于细节，细节应该依赖于抽象。

这一点最初很难理解。但如果你已经使用 .NET/.NET Core framework，你应该已经看过 [Dependency Injection](https://martinfowler.com/articles/injection.html) (DI) 对这一原则的实现。虽然它们不是相同的概念，但 DIP 使高级模块无法了解低级模块的详细信息，也无法设置。这可以通过 DI 来实现，这样做的最大好处是减少了模块间的耦合，耦合是一种非常非常糟糕的开发模式，它会导致代码难以重构。

**Bad:**

```csharp
public abstract class EmployeeBase
{
    protected virtual void Work()
    {
        // ....working
    }
}

public class Human : EmployeeBase
{
    public override void Work()
    {
        //.... working much more
    }
}

public class Robot : EmployeeBase
{
    public override void Work()
    {
        //.... working much, much more
    }
}

public class Manager
{
    private readonly Robot _robot;
    private readonly Human _human;

    public Manager(Robot robot, Human human)
    {
        _robot = robot;
        _human = human;
    }

    public void Manage()
    {
        _robot.Work();
        _human.Work();
    }
}
```

**Good:**

```csharp
public interface IEmployee
{
    void Work();
}

public class Human : IEmployee
{
    public void Work()
    {
        // ....working
    }
}

public class Robot : IEmployee
{
    public void Work()
    {
        //.... working much more
    }
}

public class Manager
{
    private readonly IEnumerable<IEmployee> _employees;

    public Manager(IEnumerable<IEmployee> employees)
    {
        _employees = employees;
    }

    public void Manage()
    {
        foreach (var employee in _employees)
        {
            _employee.Work();
        }
    }
}
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>不要重复你自己 (DRY)</b></summary>

尝试了解  [DRY](https://en.wikipedia.org/wiki/Don%27t_repeat_yourself) 原则

尽你所能去避免重复的代码，重复代码不好，因为这意味着如果你修改某些逻辑，那么你需要在很多地方修改这些逻辑。

想象一下，如果你经营一家餐馆，并跟踪你的库存：所有的西红柿，洋葱，大蒜，香料等。如果您有多份列表，当你使用了菜与西红柿，你更新了这份列表，那么其它列表都需要更新。如果您只有一份列表，则只需要更新一个位置即可！

通常，你有重复的代码是由于你有两个或者更多略有差异的地方，它们有很多共同点，但它们的不同点迫使你不得不视图两个或多个单独的函数，这些函数也会执行许多相同的操作。删除重复的代码意味着创建一个抽象，只需一个函数/模块/类即可处理这组不同的东西。

正确抽象至关重要，这就是为什么你应该遵循 [Classes]（#classes） 一节中阐述的 SOLID 原则的原因。错误的抽象可能比重复的代码更糟糕，所以要小心！话虽如此，如果你能做出一个良好的抽象，做到这一点！不要重复自己，否则你当你想做一处修改的时候会发现自己需要更新多个地方。

**Bad:**

```csharp
public List<EmployeeData> ShowDeveloperList(Developers developers)
{
    foreach (var developers in developer)
    {
        var expectedSalary = developer.CalculateExpectedSalary();
        var experience = developer.GetExperience();
        var githubLink = developer.GetGithubLink();
        var data = new[] {
            expectedSalary,
            experience,
            githubLink
        };

        Render(data);
    }
}

public List<ManagerData> ShowManagerList(Manager managers)
{
    foreach (var manager in managers)
    {
        var expectedSalary = manager.CalculateExpectedSalary();
        var experience = manager.GetExperience();
        var githubLink = manager.GetGithubLink();
        var data =
        new[] {
            expectedSalary,
            experience,
            githubLink
        };

        render(data);
    }
}
```

**Good:**

```csharp
public List<EmployeeData> ShowList(Employee employees)
{
    foreach (var employee in employees)
    {
        var expectedSalary = employees.CalculateExpectedSalary();
        var experience = employees.GetExperience();
        var githubLink = employees.GetGithubLink();
        var data =
        new[] {
            expectedSalary,
            experience,
            githubLink
        };

        render(data);
    }
}
```

**Very good:**

It is better to use a compact version of the code.

```csharp
public List<EmployeeData> ShowList(Employee employees)
{
    foreach (var employee in employees)
    {
        render(new[] {
            employee.CalculateExpectedSalary(),
            employee.GetExperience(),
            employee.GetGithubLink()
        });
    }
}
```

**[⬆ back to top](#目录)**

</details>

</details>

## 测试

<details>
  <summary><b>测试的基本概念</b></summary>

测试比开发更重要，如果你没有测试或者测试量不够，那么每次发布的时候，你不能确保你没有引入新的 BUG，花费的金额数量取决于你的团队，但拥有 100% 的覆盖率（所有条件和分支）是你实现非常高的可信度和让开发人员安心的方式。这意味着除了拥有一个优秀的测试框架外，你也需要使用 [良好的覆盖工具](https://docs.microsoft.com/en-us/visualstudio/test/using-code-coverage-to-determine-how-much-code-is-being-tested).

没有理由不写测试，这里有 [大量的优秀 .NET 测试框架](https://github.com/thangchung/awesome-dotnet-core#testing)，选择一款你所在团队喜欢的框架。当你找到一款适合你团队使用的的测试框架时，其目的是始终为你介绍的每个新功能/模块编写测试。如果你的首选方法是测试驱动开发 （TDD），那很好，但主要目的就是确保在启动任何功能或重构现有功能之前达到覆盖目标。

</details>

<details>
  <summary><b>每个测试的单一概念</b></summary>

确保你的测试以点为中心，而不是杂乱（不相关）内容，强制使用 [AAA 模式](http://wiki.c2.com/?ArrangeActAssert) 可以然你的代码更加整洁和易读。

**Bad:**

```csharp

public class MakeDotNetGreatAgainTests
{
    [Fact]
    public void HandleDateBoundaries()
    {
        var date = new MyDateTime("1/1/2015");
        date.AddDays(30);
        Assert.Equal("1/31/2015", date);

        date = new MyDateTime("2/1/2016");
        date.AddDays(28);
        Assert.Equal("02/29/2016", date);

        date = new MyDateTime("2/1/2015");
        date.AddDays(28);
        Assert.Equal("03/01/2015", date);
    }
}

```

**Good:**

```csharp

public class MakeDotNetGreatAgainTests
{
    [Fact]
    public void Handle30DayMonths()
    {
        // Arrange
        var date = new MyDateTime("1/1/2015");

        // Act
        date.AddDays(30);

        // Assert
        Assert.Equal("1/31/2015", date);
    }

    [Fact]
    public void HandleLeapYear()
    {
        // Arrange
        var date = new MyDateTime("2/1/2016");

        // Act
        date.AddDays(28);

        // Assert
        Assert.Equal("02/29/2016", date);
    }

    [Fact]
    public void HandleNonLeapYear()
    {
        // Arrange
        var date = new MyDateTime("2/1/2015");

        // Act
        date.AddDays(28);

        // Assert
        Assert.Equal("03/01/2015", date);
    }
}

```

> Soure https://www.codingblocks.net/podcast/how-to-write-amazing-unit-tests

**[⬆ back to top](#目录)**

</details>

## 并发

<details>
  <summary><b>使用 Async/Await</b></summary>

**异步编程指南摘要**

| Name              | Description                                       | Exceptions                      |
| ----------------- | ------------------------------------------------- | ------------------------------- |
| Avoid async void  | Prefer async Task methods over async void methods | Event handlers                  |
| Async all the way | Don't mix blocking and async code                 | Console main method (C# <= 7.0) |
| Configure context | Use `ConfigureAwait(false)` when you can          | Methods that require con­text   |

**异步方式处理**

| To Do This ...                           | Instead of This ...        | Use This             |
| ---------------------------------------- | -------------------------- | -------------------- |
| Retrieve the result of a background task | `Task.Wait or Task.Result` | `await`              |
| Wait for any task to complete            | `Task.WaitAny`             | `await Task.WhenAny` |
| Retrieve the results of multiple tasks   | `Task.WaitAll`             | `await Task.WhenAll` |
| Wait a period of time                    | `Thread.Sleep`             | `await Task.Delay`   |

**最佳实践**

async/await 最适用于 IO 型任务（网络通信，数据库通信，http 请求等），但它不适用于计算型任务（遍历巨型列表，渲染处理图片等）。因为它会将保留线程释放到线程池，可用的 CPU/内核 将不涉及处理这些任务。因此，我们应该避免使用 Async/Await 进行计算型任务。

对于处理计算型任务，倾向于结合 `TaskCreationOptions` 和 `LongRunning` 来使用 `Task.Factory.CreateNew`，它将启动一个新的后台线程来处理繁重的计算型任务，而不会将其释放回线程池，直到任务完成。

**了解你的工具**

关于 async 和 await 有太多地方需要学习， 有些困惑是很自然的。以下是一些常见问题的快速解决指南。

**常见异步问题的解决方法**

| Problem                                         | Solution                                                                          |
| ----------------------------------------------- | --------------------------------------------------------------------------------- |
| Create a task to execute code                   | `Task.Run` or `TaskFactory.StartNew` (not the `Task` constructor or `Task.Start`) |
| Create a task wrapper for an operation or event | `TaskFactory.FromAsync` or `TaskCompletionSource<T>`                              |
| Support cancellation                            | `CancellationTokenSource` and `CancellationToken`                                 |
| Report progress                                 | `IProgress<T>` and `Progress<T>`                                                  |
| Handle streams of data                          | TPL Dataflow or Reactive Extensions                                               |
| Synchronize access to a shared resource         | `SemaphoreSlim`                                                                   |
| Asynchronously initialize a resource            | `AsyncLazy<T>`                                                                    |
| Async-ready producer/consumer structures        | TPL Dataflow or `AsyncCollection<T>`                                              |

阅读 [Task-based Asynchronous Pattern (TAP) document](http://www.microsoft.com/download/en/details.aspx?id=19957)。它编写得非常好，包括有关 API 设计和正确使用异步/等待（包括取消和进度报告）的指导。

应该使用新的 await-friendly 方法来替代旧的方法。如果你新的异步代码中有旧的示例，这说明你写错了。

| Old                | New                                  | Description                                                   |
| ------------------ | ------------------------------------ | ------------------------------------------------------------- |
| `task.Wait`        | `await task`                         | Wait/await for a task to complete                             |
| `task.Result`      | `await task`                         | Get the result of a completed task                            |
| `Task.WaitAny`     | `await Task.WhenAny`                 | Wait/await for one of a collection of tasks to complete       |
| `Task.WaitAll`     | `await Task.WhenAll`                 | Wait/await for every one of a collection of tasks to complete |
| `Thread.Sleep`     | `await Task.Delay`                   | Wait/await for a period of time                               |
| `Task` constructor | `Task.Run` or `TaskFactory.StartNew` | Create a code-based task                                      |

> Source https://gist.github.com/jonlabelle/841146854b23b305b50fa5542f84b20c

**[⬆ back to top](#目录)**

</details>

## 异常处理

<details>
  <summary><b>异常处理的基本概念</b></summary>

抛出异常是一件好事！这意味了程序在运行时成功识别程序中出现的问题，通过停止当前堆栈上的函数执行，终止进程 (在 .NET/.NET Core 里)，并在控制台中通过堆栈跟踪来通知你。

</details>

<details>
  <summary><b>在 catch 块中不要使用 'throw ex'</b></summary>

如果你在捕获一个异常之后需要重新抛出一个异常，仅仅使用 'throw' ，你将会保存堆栈跟踪，但在坏的情况下，你将丢失堆栈跟踪。

**Bad:**

```csharp
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw ex;
}
```

**Good:**

```csharp
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw;
}
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>不要忽略捕获的异常</b></summary>

对捕获到的错误置之不理并不能解决问题，抛出异常也好不了哪儿去，因为它们常常无法准确在控制台中显示出来。如果将一些代码放到 `try/catch` 中就意味着你认为这里可能会发生异常。因此你应该制定计划，创建代码分支，为异常发生做准备。

**Bad:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    // silent exception
}
```

**Good:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    NotifyUserOfError(error);

    // Another option
    ReportErrorToService(error);
}
```

**[⬆ back to top](#目录)**

</details>


<details>
  <summary><b>使用多个 catch 块而不是 if 条件</b></summary>

如果你需要对不同类型的异常做不同操作，你最好使用多个 catch 块来处理它们。

**Bad:**

```csharp
try
{
    // Do something..
}
catch (Exception ex)
{

    if (ex is TaskCanceledException)
    {
        // Take action for TaskCanceledException
    }
    else if (ex is TaskSchedulerException)
    {
        // Take action for TaskSchedulerException
    }
}
```

**Good:**

```csharp
try
{
    // Do something..
}
catch (TaskCanceledException ex)
{
    // Take action for TaskCanceledException
}
catch (TaskSchedulerException ex)
{
    // Take action for TaskSchedulerException
}
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>在重新引发异常时保留异常堆栈跟踪</b></summary>

C# 允许使用 "throw" 关键字在 catch 块中重新引发异常。使用 "throw e;" 抛出捕获的异常是一种不好的做法。此语句会重置堆栈跟踪。而使用 "throw;"，这将保持堆栈跟踪，并提供有关异常的更深入的信息。另一个选项是使用自定义异常。只需实例化新异常，并将其内部异常属性设置为捕获的异常，并引发 `new CustomException("some info", e);` 。向异常添加信息是一种好的做法，因为它有助于调试。但是，如果目标是记录异常，则使用 "throw;" 将降级传递给调用方。

**Bad:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    logger.LogInfo(ex);
    throw ex;
}
```

**Good:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    logger.LogInfo(error);
    throw;
}
```

**Good:**

```csharp
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    logger.LogInfo(error);
    throw new CustomException(error);
}
```

**[⬆ back to top](#目录)**

</details>

## 格式化

<details>
  <summary><b>使用 <i>.editorconfig</i> 文件</b></summary>

**Bad:**

一个项目中有一些代码格式化文件，缩进样式在项目中被 `space` 和 `tab` 混淆。

**Good:**

在代码库中使用 `.editorconfig` 文件来定义和维护一致的代码样式。

```csharp
root = true

[*]
indent_style = space
indent_size = 2
end_of_line = lf
charset = utf-8
trim_trailing_whitespace = true
insert_final_newline = true

# C# files
[*.cs]
indent_size = 4
# New line preferences
csharp_new_line_before_open_brace = all
csharp_new_line_before_else = true
csharp_new_line_before_catch = true
csharp_new_line_before_finally = true
csharp_new_line_before_members_in_object_initializers = true
csharp_new_line_before_members_in_anonymous_types = true
csharp_new_line_within_query_expression_clauses = true

# Code files
[*.{cs,csx,vb,vbx}]
indent_size = 4

# Indentation preferences
csharp_indent_block_contents = true
csharp_indent_braces = false
csharp_indent_case_contents = true
csharp_indent_switch_labels = true
csharp_indent_labels = one_less_than_current

# avoid this. unless absolutely necessary
dotnet_style_qualification_for_field = false:suggestion
dotnet_style_qualification_for_property = false:suggestion
dotnet_style_qualification_for_method = false:suggestion
dotnet_style_qualification_for_event = false:suggestion

# only use var when it's obvious what the variable type is
# csharp_style_var_for_built_in_types = false:none
# csharp_style_var_when_type_is_apparent = false:none
# csharp_style_var_elsewhere = false:suggestion

# use language keywords instead of BCL types
dotnet_style_predefined_type_for_locals_parameters_members = true:suggestion
dotnet_style_predefined_type_for_member_access = true:suggestion

# name all constant fields using PascalCase
dotnet_naming_rule.constant_fields_should_be_pascal_case.severity = suggestion
dotnet_naming_rule.constant_fields_should_be_pascal_case.symbols  = constant_fields
dotnet_naming_rule.constant_fields_should_be_pascal_case.style    = pascal_case_style

dotnet_naming_symbols.constant_fields.applicable_kinds   = field
dotnet_naming_symbols.constant_fields.required_modifiers = const

dotnet_naming_style.pascal_case_style.capitalization = pascal_case

# static fields should have s_ prefix
dotnet_naming_rule.static_fields_should_have_prefix.severity = suggestion
dotnet_naming_rule.static_fields_should_have_prefix.symbols  = static_fields
dotnet_naming_rule.static_fields_should_have_prefix.style    = static_prefix_style

dotnet_naming_symbols.static_fields.applicable_kinds   = field
dotnet_naming_symbols.static_fields.required_modifiers = static

dotnet_naming_style.static_prefix_style.required_prefix = s_
dotnet_naming_style.static_prefix_style.capitalization = camel_case

# internal and private fields should be _camelCase
dotnet_naming_rule.camel_case_for_private_internal_fields.severity = suggestion
dotnet_naming_rule.camel_case_for_private_internal_fields.symbols  = private_internal_fields
dotnet_naming_rule.camel_case_for_private_internal_fields.style    = camel_case_underscore_style

dotnet_naming_symbols.private_internal_fields.applicable_kinds = field
dotnet_naming_symbols.private_internal_fields.applicable_accessibilities = private, internal

dotnet_naming_style.camel_case_underscore_style.required_prefix = _
dotnet_naming_style.camel_case_underscore_style.capitalization = camel_case

# Code style defaults
dotnet_sort_system_directives_first = true
csharp_preserve_single_line_blocks = true
csharp_preserve_single_line_statements = false

# Expression-level preferences
dotnet_style_object_initializer = true:suggestion
dotnet_style_collection_initializer = true:suggestion
dotnet_style_explicit_tuple_names = true:suggestion
dotnet_style_coalesce_expression = true:suggestion
dotnet_style_null_propagation = true:suggestion

# Expression-bodied members
csharp_style_expression_bodied_methods = false:none
csharp_style_expression_bodied_constructors = false:none
csharp_style_expression_bodied_operators = false:none
csharp_style_expression_bodied_properties = true:none
csharp_style_expression_bodied_indexers = true:none
csharp_style_expression_bodied_accessors = true:none

# Pattern matching
csharp_style_pattern_matching_over_is_with_cast_check = true:suggestion
csharp_style_pattern_matching_over_as_with_null_check = true:suggestion
csharp_style_inlined_variable_declaration = true:suggestion

# Null checking preferences
csharp_style_throw_expression = true:suggestion
csharp_style_conditional_delegate_call = true:suggestion

# Space preferences
csharp_space_after_cast = false
csharp_space_after_colon_in_inheritance_clause = true
csharp_space_after_comma = true
csharp_space_after_dot = false
csharp_space_after_keywords_in_control_flow_statements = true
csharp_space_after_semicolon_in_for_statement = true
csharp_space_around_binary_operators = before_and_after
csharp_space_around_declaration_statements = do_not_ignore
csharp_space_before_colon_in_inheritance_clause = true
csharp_space_before_comma = false
csharp_space_before_dot = false
csharp_space_before_open_square_brackets = false
csharp_space_before_semicolon_in_for_statement = false
csharp_space_between_empty_square_brackets = false
csharp_space_between_method_call_empty_parameter_list_parentheses = false
csharp_space_between_method_call_name_and_opening_parenthesis = false
csharp_space_between_method_call_parameter_list_parentheses = false
csharp_space_between_method_declaration_empty_parameter_list_parentheses = false
csharp_space_between_method_declaration_name_and_open_parenthesis = false
csharp_space_between_method_declaration_parameter_list_parentheses = false
csharp_space_between_parentheses = false
csharp_space_between_square_brackets = false

[*.{asm,inc}]
indent_size = 8

# Xml project files
[*.{csproj,vcxproj,vcxproj.filters,proj,nativeproj,locproj}]
indent_size = 2

# Xml config files
[*.{props,targets,config,nuspec}]
indent_size = 2

[CMakeLists.txt]
indent_size = 2

[*.cmd]
indent_size = 2

```

**[⬆ back to top](#目录)**

</details>

## 注释

<details>
  <summary><b>避免位置标记</b></summary>

它们通常只会增加噪音。让函数和变量名称以及适当的缩进和格式为代码提供可视化结构。

**Bad:**

```csharp
////////////////////////////////////////////////////////////////////////////////
// Scope Model Instantiation
////////////////////////////////////////////////////////////////////////////////
var model = new[]
{
    menu: 'foo',
    nav: 'bar'
};

////////////////////////////////////////////////////////////////////////////////
// Action setup
////////////////////////////////////////////////////////////////////////////////
void Actions()
{
    // ...
};
```

**Bad:**

```csharp

#region Scope Model Instantiation

var model = {
    menu: 'foo',
    nav: 'bar'
};

#endregion

#region Action setup

void Actions() {
    // ...
};

#endregion
```

**Good:**

```csharp
var model = new[]
{
    menu: 'foo',
    nav: 'bar'
};

void Actions()
{
    // ...
};
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>不要在代码库中留下注释代码</b></summary>

版本控制存在是有原因的。只应该在历史记录中保留旧代码。

**Bad:**

```csharp
doStuff();
// doOtherStuff();
// doSomeMoreStuff();
// doSoMuchStuff();
```

**Good:**

```csharp
doStuff();
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>不要有日志注释</b></summary>

记住，使用版本控制！不需要废弃代码、注释代码，尤其是日志注释。使用 "git log" 获取历史记录！

**Bad:**

```csharp
/**
 * 2018-12-20: Removed monads, didn't understand them (RM)
 * 2017-10-01: Improved using special monads (JP)
 * 2016-02-03: Removed type-checking (LI)
 * 2015-03-14: Added combine with type-checking (JR)
 */
public int Combine(int a,int b)
{
    return a + b;
}
```

**Good:**

```csharp
public int Combine(int a,int b)
{
    return a + b;
}
```

**[⬆ back to top](#目录)**

</details>

<details>
  <summary><b>只应该在业务逻辑较为复杂的时候才应该添加注释</b></summary>

注释是解释，不是要求，好的代码 _大部分_ 就是文档本身。

**Bad:**

```csharp
public int HashIt(string data)
{
    // The hash
    var hash = 0;

    // Length of string
    var length = data.length;

    // Loop through every character in data
    for (var i = 0; i < length; i++)
    {
        // Get character code.
        const char = data.charCodeAt(i);
        // Make the hash
        hash = ((hash << 5) - hash) + char;
        // Convert to 32-bit integer
        hash &= hash;
    }
}
```

**Better but still Bad:**

```csharp
public int HashIt(string data)
{
    var hash = 0;
    var length = data.length;
    for (var i = 0; i < length; i++)
    {
        const char = data.charCodeAt(i);
        hash = ((hash << 5) - hash) + char;

        // Convert to 32-bit integer
        hash &= hash;
    }
}
```

如果注释解释了代码正在执行的操作，它可能是一个无用的注释，可以使用一个命名良好的变量或函数来解决。前面的代码中的注释可以替换为名为 "ConvertTo32bitInt" 的函数，因此此注释仍然毫无用处。

但是，开发人员选择 djb2 哈希算法而不是 sha-1 或其他哈希函数的代码就很难表达。在这种情况下，可以添加注释。

**Good:**

```csharp
public int Hash(string data)
{
    var hash = 0;
    var length = data.length;

    for (var i = 0; i < length; i++)
    {
        var character = data[i];
        // use of djb2 hash algorithm as it has a good compromise
        // between speed and low collision with a very simple implementation
        hash = ((hash << 5) - hash) + character;

        hash = ConvertTo32BitInt(hash);
    }
    return hash;
}

private int ConvertTo32BitInt(int value)
{
    return value & value;
}
```

**[⬆ back to top](#目录)**

</details>

# 其它关于代码整洁之道的资源

## 其它代码整洁之道列表

- [clean-code-javascript](https://github.com/ryanmcdermott/clean-code-javascript) - Clean Code concepts adapted for JavaScript
- [clean-code-php](https://github.com/jupeter/clean-code-php) - Clean Code concepts adapted for PHP
- [clean-code-ruby](https://github.com/uohzxela/clean-code-ruby) - Clean Code concepts adapted for Ruby
- [clean-code-python](https://github.com/zedr/clean-code-python) - Clean Code concepts adapted for Python
- [clean-code-typescript](https://github.com/labs42io/clean-code-typescript) - Clean Code concepts adapted for TypeScript
- [clean-go-article](https://github.com/Pungyeon/clean-go-article) - Clean Code concepts adapted for Golang and an example how to apply [clean code in Golang](https://github.com/Pungyeon/clean-go)

## 工具

- [codemaid](https://github.com/codecadwallader/codemaid) - open source Visual Studio extension to cleanup and simplify our C#, C++, F#, VB, PHP, PowerShell, JSON, XAML, XML, ASP, HTML, CSS, LESS, SCSS, JavaScript and TypeScript coding
- [Sharpen](https://github.com/sharpenrocks/Sharpen) - Visual Studio extension that intelligently introduces new C# features into your existing code base
- [tslint-clean-code](https://github.com/Glavin001/tslint-clean-code) - TSLint rules for enforcing Clean Code

## 表格

- [Clean Code](cheetsheets/Clean-Code-V2.4.pdf) - The summary of [Clean Code: A Handbook of Agile Software Craftsmanship](https://www.amazon.com/dp/0132350882) book
- [Clean Architecture](cheetsheets/Clean-Architecture-V1.0.pdf) - The summary of [Clean Architecture: A Craftsman's Guide to Software Structure and Design](https://www.amazon.com/dp/0134494164) book
- [Modern JavaScript Cheatsheet](https://github.com/mbeaudru/modern-js-cheatsheet) - Cheatsheet for the JavaScript knowledge you will frequently encounter in modern projects
- [OWASP Cheat Sheet Series](https://cheatsheetseries.owasp.org) - Cheatsheet was created to provide a concise collection of high value information on specific application security topics

---

# 贡献者

感谢每位参与 `clean-code-dotnet` 项目贡献的朋友。

<a href="https://github.com/thangchung/clean-code-dotnet/graphs/contributors"><img src="https://opencollective.com/cleancodedotnet/contributors.svg?width=890" title="contributors" alt="contributors" /></a>

# 支持者

热爱我们的工作，帮助我们继续我们的活动？[[成为支持者](https://opencollective.com/cleancodedotnet#backer)]

<a href="https://opencollective.com/cleancodedotnet#backers" target="_blank"><img src="https://opencollective.com/cleancodedotnet/backers.svg?width=890"></a>

# 赞助商

成为赞助商，并在 Github 上的 README 上获取您的徽标，并链接到您的网站。[[成为赞助商](https://opencollective.com/cleancodedotnet#sponsor)]

<a href="https://opencollective.com/cleancodedotnet/sponsor/0/website" target="_blank"><img src="https://opencollective.com/cleancodedotnet/sponsor/0/avatar.svg"></a>
<a href="https://opencollective.com/cleancodedotnet/sponsor/1/website" target="_blank"><img src="https://opencollective.com/cleancodedotnet/sponsor/1/avatar.svg"></a>
<a href="https://opencollective.com/cleancodedotnet/sponsor/2/website" target="_blank"><img src="https://opencollective.com/cleancodedotnet/sponsor/2/avatar.svg"></a>
<a href="https://opencollective.com/cleancodedotnet/sponsor/3/website" target="_blank"><img src="https://opencollective.com/cleancodedotnet/sponsor/3/avatar.svg"></a>
<a href="https://opencollective.com/cleancodedotnet/sponsor/4/website" target="_blank"><img src="https://opencollective.com/cleancodedotnet/sponsor/4/avatar.svg"></a>

# 许可证

[![CC0](http://mirrors.creativecommons.org/presskit/buttons/88x31/svg/cc-zero.svg)](https://creativecommons.org/publicdomain/zero/1.0/)

To the extent possible under law, [thangchung](https://github.com/thangchung) has waived all copyright and related or neighboring rights to this work.


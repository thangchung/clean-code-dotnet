# 适用于 .NET/.NET Core 的代码整洁之道

如果您喜欢 `clean-code-dotnet` 项目，或者它对于您所帮助，请给这个仓库一个小星星 :star: 。这不仅会激励我们的 .NET 社区，也会帮助全世界的 .NET 开发者提升编写优质代码的技能。非常感谢您 :+1:

请查看我的[博客](https://medium.com/@thangchung)，或者在 [Twitter](https://twitter.com/thangchung) 上联系我！

# 目录

- [适用于 .NET/.NET Core 的代码整洁之道](#%e9%80%82%e7%94%a8%e4%ba%8e-netnet-core-%e7%9a%84%e4%bb%a3%e7%a0%81%e6%95%b4%e6%b4%81%e4%b9%8b%e9%81%93)
- [目录](#%e7%9b%ae%e5%bd%95)
- [介绍](#%e4%bb%8b%e7%bb%8d)
- [.NET 中的整洁代码](#net-%e4%b8%ad%e7%9a%84%e6%95%b4%e6%b4%81%e4%bb%a3%e7%a0%81)
  - [命名](#%e5%91%bd%e5%90%8d)

# 介绍

![Humorous image of software quality estimation as a count of how many expletives you shout when reading code](http://www.osnews.com/images/comics/wtfm.jpg)

软件工程原则，是来自于 Robert C. Martin 的一本书 [_Clean Code_](https://www.amazon.com/Clean-Code-Handbook-Software-Craftsmanship/dp/0132350882), 就 .NET/.NET Core 而言，它并不是编码风格指南，而是为了指导开发者能够编写出具有可读性、可重用性和可重构的 .NET/.NET Core 程序。

这里面描述的每一项原则并不是被严格遵守的，并且支持者也相对更少。这些仅仅是指导指南，但这些指南是 _Clean Code_. 作者们多年经验的智慧结晶。

灵感来源于 [clean-code-javascript](https://github.com/ryanmcdermott/clean-code-javascript) 和 [clean-code-php](https://github.com/jupeter/clean-code-php)。

# .NET 中的整洁代码

## 命名

<details>
  <summary><b>避免使用不优雅的命名</b></summary>

代码中采用优雅的命名方式会易于被更多的开发者使用，命名应反映出它的作用及对应的上下文关系

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
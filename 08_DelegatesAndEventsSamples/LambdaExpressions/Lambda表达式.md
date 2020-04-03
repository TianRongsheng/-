# Lambda 表达式---方法的简写（参数和方法体）
用表达式的方法写匿名函数
应用场景1，lambda表达式赋予委托实例

1. 通用格式  
(参数列表)=>{实现方法体}

2. 参数数量不同，书写方式有变化
	- 只有一个参数	  参数名=>{方法体}
	- 多个参数        （参数名1，参数名2，参数名3...)=>{方法体}

3. 方法体语句数量不同，书写方式也有变化
	- 只有一条return 语句  ，可以省略{}和return ,直接在=>后写语句
	  (参数列表)=>语句
	- 多条语句，必须使用{}
4. 只有1个参数，方法体只有一条return语句
     - 参数名=>语句

4. 闭包
	- lambda表达式中使用了外部变量--称为闭包

```C#
int someVal = 5;
Func<int, int> f = x => x + someVal;
```
编译器封装

```C#
public class AnonymousClass
{
	private int someVal;
	public AnonymousClass(int someVal)
	{
		this.someVal = someVal;
	}
	public int AnonymousMethod(int x) => x + someVal;
	}
```
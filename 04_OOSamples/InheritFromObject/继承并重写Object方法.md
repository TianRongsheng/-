1.  C#中所有类隐式继承 Object ,在 Object 类中定义的每个方法都可用于系统中的所有对象

2.  Object类的方法成员
    . Equals(Object)	 实例方法-确定指定的对象是否等于当前对象。
    . Equals(Object, Object)	 静态方法- 确定指定的对象实例是否被视为相等。
    . Finalize()	 在垃圾回收将某一对象回收前允许该对象尝试释放资源并执行其他清理操作。
    . GetHashCode()	 实例方法-作为默认哈希函数。
    . GetType()	实例方法-获取当前实例的 Type。
    . MemberwiseClone()	实例方法-创建当前 Object 的浅表副本。
    . ReferenceEquals(Object, Object)	静态方法-确定指定的 Object 实例是否是相同的实例。
    . ToString()	-实例方法-返回表示当前对象的字符串。

3.   派生类可以和重写其中一些方法（判断依据-是否virtual方法），其中包括：
    . Equals-支持对象之间的比较。
    . Finalize-在自动回收对象之前执行清理操作。
    . GetHashCode-生成与对象的值相对应的数字以支持使用哈希表。
    . ToString 制造描述类的实例的用户可读文本字符串。

4.  本例来自微软官网[隐式继承对象](https://docs.microsoft.com/zh-cn/dotnet/api/system.object?view=netcore-3.1)

5.  练习 设计一个Student类，并重写Object部分方法。
        . 设计学生类的常用属性。
        . 重写Object类的判等方法Equals，实现两个学生对象的判等。
        . 重写Object类的字符串转换方法ToString，实现学生对象的属性值转换为格式化字符串的方法。
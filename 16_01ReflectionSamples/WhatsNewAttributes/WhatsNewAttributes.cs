using System;

namespace WhatsNewAttributes
{
    /// <summary>
    /// 用于标记最后一次修改数据项的时间
    /// 有两个必选参数：修改日期和改变的内容字符串
    /// 上述两个参数传递给构造函数
    /// 可以将特性应用于类、方法、构造函数
    /// 并可以多次应用于同一项上
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method |AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class LastModifiedAttribute : Attribute
    {
        private readonly DateTime _dateModified;
        private readonly string _changes;

        public LastModifiedAttribute(string dateModified, string changes)
        {
            _dateModified = DateTime.Parse(dateModified);
            _changes = changes;
        }

        public DateTime DateModified => _dateModified;

        public string Changes => _changes;

        // 存在一个公共属性，用于描述关于该数据项的任何重要问题
        public string Issues { get; set; }
    }

    /// <summary>
    /// 不带任何参数的特性
    /// 用于把程序集标记为通过LastModifiedAttribute维护的文档
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly)]
    public class SupportsWhatsNewAttribute : Attribute
    {
     
    }
}


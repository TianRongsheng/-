
namespace Wrox.ProCSharp.Generics
{
    //IDocument接口定义
    public interface IDocument
    {
        //接口有两个成员，是两个只读属性
       //标题
        string Title { get; }
        //内容
        string Content { get; }
    }
    //定义Document类继承IDocument
    public class Document : IDocument
    {
   
         public Document(string title, string content)
          {
              Title = title;
              Content = content;
          }

          public string Title { get; }
          public string Content { get; }
       
    }
}

using static System.Console;

namespace Wrox.ProCSharp.Generics
{
    class Program
    {
        static void Main()
        {
            var dm = new DocumentManager<Document>();
            //往管理器里面加入两个元素进入队列
            dm.AddDocument(new Document("Title A", "Sample A"));
            dm.AddDocument(new Document("Title B", "Sample B"));
            //显示队列所有元素
            dm.DisplayAllDocuments();
            //如果队列不为空
            if (dm.IsDocumentAvailable)
            {
                //获取队列元素的输出内容
                Document d = dm.GetDocument();
                WriteLine(d.Content);
               
            }
        }
    }
}

using static System.Console;

namespace Wrox.ProCSharp.Generics
{
    class Program
    {
        static void Main()
        {
            //创建一个DocumentManager对象，用来以队列形式管理Document

            var dm = new DocumentManager<Document>();
            //往管理器里加两个Document元素
            //入队列
            dm.AddDocument(new Document("Title A", "Sample A"));  
            dm.AddDocument(new Document("Title B", "Sample B"));
            //显示所有队列元素
            dm.DisplayAllDocuments();
            //如果队列不为空
            if (dm.IsDocumentAvailable)
            {
                //获取队列元素输出内容--出队列
                Document d = dm.GetDocument();
                WriteLine(d.Content);
            }


        }
    }
}

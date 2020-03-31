using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Generics
{
    
    //文档类的元素管理器，所有的元素以队列形式管理
    //通过管理器实例，可以入队列出队列判空显示所有元素等操作。
    public class DocumentManager<TDocument>
        where TDocument : IDocument //类型约束
    {
        //私有变量队列documentQueue
        private readonly Queue<TDocument> documentQueue = new Queue<TDocument>();
       //私有变量--一个空的对象
        private readonly object lockQueue = new object();

        //入队列
        public void AddDocument(TDocument doc)
        {
            //lock 语句获取给定对象的互斥 lock，执行语句块，然后释放 lock
            //本列锁定队列，加入新文档
             lock (lockQueue)
            {
                documentQueue.Enqueue(doc);
            }
        }

        //IsDocumentAvailable属性，判断队列是否为空
        //如果队列不为空，IsDocumentAvailable返回true
        public bool IsDocumentAvailable => documentQueue.Count > 0;

        //显示队列上的所有节点的Title值
        public void DisplayAllDocuments()
        {
            foreach (TDocument doc in documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }

        //获取队列元素--删除队列元素
        public TDocument GetDocument()
        {
            TDocument doc = default(TDocument);
            lock (lockQueue)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
        }

    }
}
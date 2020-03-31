using System;
using System.Collections.Generic;

namespace DocumentManagerGenerics
{
    public class DocumentManager<T>
        where T: IDocument
    {
        private readonly Queue<T> _documentQueue = new Queue<T>();
        private readonly object _lockQueue = new object();

        public void AddDocument(T doc)
        {
            //lock 语句获取给定对象的互斥 lock，执行语句块，然后释放 lock
            //本列锁定队列，加入新文档
             lock (_lockQueue)
            {
                _documentQueue.Enqueue(doc);
            }
        }

        //如果队列不为空，IsDocumentAvailable返回true
        public bool IsDocumentAvailable => _documentQueue.Count > 0;

        public void DisplayAllDocuments()
        {
            foreach (T doc in _documentQueue)
            {
                Console.WriteLine(doc.Title);
            }
        }

        public T GetDocument()
        {
            //给doc添加一个默认值，由于泛型不可空，用default替代
            T doc = default;
            lock (_lockQueue)
            {
                doc = _documentQueue.Dequeue();
            }
            return doc;
        }

    }
}
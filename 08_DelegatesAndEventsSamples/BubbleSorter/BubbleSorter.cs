using System;
using System.Collections.Generic;

namespace Wrox.ProCSharp.Delegates
{
    class BubbleSorter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">需要做排序的数据类型</typeparam>
        /// <param name="sortArray">需要排序的可按照索引单独访问对象集合</param>
        /// <param name="comparison">委托变量，接受两个同类型对象的比较方法，比较结果是布尔值</param>
  
        static public void Sort<T>(IList<T> sortArray, Func<T, T, bool> comparison)
        {
            bool swapped = true;
            do
            {
                swapped = false;
                for (int i = 0; i < sortArray.Count - 1; i++)
                {
                    if (comparison(sortArray[i + 1], sortArray[i]))
                    {
                        T temp = sortArray[i];
                        sortArray[i] = sortArray[i + 1];
                        sortArray[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
        public static void Export<T>(IList<T> PrintArray, Func<T, string> func)
        {
            foreach (var item in PrintArray)
            {
                Console.WriteLine(func(item));
            }
        }
    }
}

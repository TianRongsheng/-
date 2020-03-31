using System;
using System.Collections.Generic;

namespace CopyingElements
{
    class Program
    {
        /// <summary>
        /// 拷贝列表，将指定数量的元素形成新的列表返回。
        /// 如果指定数量小于列表容量，拷贝整个列表
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="input">泛型列表</param>
        /// <param name="maxElements">整数</param>
        /// <returns>泛型列表</returns>
        public static List<T> CopyAtMost<T>(List<T> input, int maxElements)
        {
            int actualCount = Math.Min(input.Count, maxElements);
            List<T> ret = new List<T>(actualCount);
            for (int i = 0; i < actualCount; i++)
            {
                ret.Add(input[i]);
            }
            return ret;
        }
        static void Main(string[] args)
        {
           //新建一个整型列表
            List<int> numbers = new List<int>();
            //添加3个元素
            numbers.Add(5);
            numbers.Add(10);
            numbers.Add(20);
            //调用CopyAtMost（），传入类型参数int ,列表numbers,常量2
            //拷贝number2个元素到firstTwo中
            List<int> firstTwo = CopyAtMost(numbers, 2);
            Console.WriteLine(firstTwo.Count);

 
             
        }       
    }
}

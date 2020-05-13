using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;

namespace DynamicFileReader
{
    public class DynamicFileHelper
    {
        public IEnumerable<dynamic> ParseFile(string fileName)
        {
           //创建一个类型未知的新列表对象
            var retList = new List<dynamic>();
            
            //打开文件流
            var fileStream = OpenFile(fileName);
           
            //如果文件存在
            if (fileStream != null)
            {

                string[] headerLine = fileStream.ReadLine()//读取一行，来自文件数据
                                                .Split(',')//以，为间隔将字符串分隔为字符串数组---》select数据源
                                                .Select(s => s.Trim())//去掉每个字符串的无效空格
                                                .ToArray();//转换为数组

                while (fileStream.Peek() > 0)//持续读取文件直到文件尾部
                {
                    string[] dataLine = fileStream.ReadLine().Split(',');
                    //构造一个成员未知的动态对象dynamicEntity
                    dynamic dynamicEntity = new ExpandoObject();

                    for (int i = 0; i < headerLine.Length; i++)
                    {
                        //1.dynamicEntity转换为字典
                        //2.往字典里元素
                        //3.循环做完，1个完整的字典一行数据
                        ((IDictionary<string, object>)dynamicEntity).Add(headerLine[i], dataLine[i]);
                    }
                    //将数据字典添加到列表中
                    retList.Add(dynamicEntity);
                }
            }
            return retList;
        }

        private StreamReader OpenFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                return new StreamReader(File.OpenRead(fileName));
            }
            return null;
        }
    }
}

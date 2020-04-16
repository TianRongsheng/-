using System;
using System.IO;

namespace SolicitColdCall
{
    public class ColdCallFileReader : IDisposable
    {
        private FileStream _fs;
        private StreamReader _sr;
        private uint _nPeopleToRing;
        private bool _isDisposed = false;
        private bool _isOpen = false;//打开的状态初始为false

        public void Open(string fileName)
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("peopleToRing");
            }

            _fs = new FileStream(fileName, FileMode.Open);//使用指定的路径和创建模式初始化 FileStream 类的新实例。
            _sr = new StreamReader(_fs);//为指定的文件名初始化 StreamReader 类的新实例。

            try
            {
                string firstLine = _sr.ReadLine();
                _nPeopleToRing = uint.Parse(firstLine);//将数字的字符串表示形式转换为它的等效 32 位无符号整数。
                _isOpen = true;
            }
            catch (FormatException ex)
            {
                throw new ColdCallFileFormatException(
                    $"First line isn\'t an integer {ex}");
            }
        }

        public void ProcessNextPerson()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException("peopleToRing");//ObjectDisposedException使用包含已释放对象名称的字符串初始化 ObjectDisposedException 类的新实例。
            }

            if (!_isOpen)//此时状态为true
            {
                throw new UnexpectedException(
                    "Attempted to access coldcall file that is not open");
            }

            try
            {
                string name = _sr.ReadLine();
                if (name == null)
                {
                    throw new ColdCallFileFormatException("Not enough names");
                }
                if (name[0] == 'B')
                    //此处代表若是输入的内容带有“B”则抛出下面的异常
                {
                    throw new SalesSpyFoundException(name);
                }
                Console.WriteLine(name);//将文件的名字输出
            }
            catch (SalesSpyFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
            }
        }

        public uint NPeopleToRing
        {
            get
            {
                if (_isDisposed)
                {
                    throw new ObjectDisposedException("peopleToRing");
                }

                if (!_isOpen)
                {
                    throw new UnexpectedException(
                        "Attempted to access cold–call file that is not open");
                }

                return _nPeopleToRing;
            }
        }

        public void Dispose()//实现接口
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            _isOpen = false;

            _fs?.Dispose();//释放由 Stream 使用的所有资源。
            _fs = null;
        }
    }
}